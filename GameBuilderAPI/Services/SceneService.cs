using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilder.Helpers;
using GameBuilder.Services;
using GameBuilder.Visitors;
using GameBuilderAPI.Services;
using GameBuilderAPI.Visitors;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Scenes;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleTesting.Services
{
    internal class SceneService : DBService
    {
        private readonly ChoiceService choiceService;
        private readonly ConditionService conditionService;
        private async Task<Scene?> AddFirstScene(Scene scene, ESContext context)
        {
            try
            {
                await context.FirstScene.AddAsync(
                new FirstScene
                   {
                       Scene = scene
                   }
                );
                await context.SaveChangesAsync();
                return scene;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SceneService(ChoiceService choiceService, ConditionService conditionService, ESContext context) : base(context) 
        { 
            this.choiceService = choiceService;
            this.conditionService = conditionService;
        }

        public async Task<Scene?> AddScene(Scene scene)
        {
            try
            {
                await context.Scenes.AddAsync(scene);
                var sceneAddedVisitor = SceneAddedVisitor.Instance;
                await scene.AcceptDBVisitor(sceneAddedVisitor, context);
                await context.SaveChangesAsync();
                return scene;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Transition?> AddTransition(Scene modifiedScene, Transition transition)
        {
            try
            {
                context.Scenes.Attach(modifiedScene);
                context.Scenes.Attach(transition.TargetScene);
                if (transition.Conditions != null)
                    context.Conditions.AttachRange(transition.Conditions);

                await context.Transitions.AddAsync(transition);
                await context.SaveChangesAsync();

                var firstScene = await FindFirstScene();
                if (firstScene == null)
                {
                    await AddFirstScene(modifiedScene, context);
                }

                return transition;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private async Task<Scene?> FindFirstScene()
        {
            var scene = (await context
                    .FirstScene
                    .FromSqlRaw("SELECT * FROM FirstScene WHERE Id = 1")
                    .Include(fs => fs.Scene)
                    .FirstOrDefaultAsync())?.Scene;

            return scene;
        }

        private async Task LoadSceneDependencies()
        {
            var task1 = context.Scenes
                .Include(s => s.Transitions)
                .ThenInclude(t => t.Conditions)
                .ToListAsync();

            var task2 = context.ChoiceScenes
            .Include(s => s.Characters)
            .Include(s => s.Choices)
            .ToListAsync();


            var task3 = context.StandardScenes
                .Include(s => s.Characters)
                .Include(s => s.Dialogue)
                .ThenInclude(d => d.Character)
                .ToListAsync();

            var task4 = choiceService.LoadChoiceDependenciesTask();
            var task5 = conditionService.LoadConditionDependenciesTask();

            await Task.WhenAll(task1, task2, task3, task4, task5);

        }

        internal async Task<Scene?> GetFirstScene()
        {
            await LoadSceneDependencies();
            var scene = await FindFirstScene();

            if (scene == null)
                return null;

            return scene;
        }
    }
}
