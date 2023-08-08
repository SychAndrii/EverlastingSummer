using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilder.Helpers;
using GameBuilder.Visitors;
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
    internal class SceneService
    {
        private static SceneService _Instance;
        public static SceneService Instance
        {
            get
            {
                if(_Instance == null )
                    _Instance = new SceneService();
                return _Instance;
            }
        }

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

        public async Task<Scene?> AddScene(Scene scene)
        {
            using ESContext eSContext = new ESContext();

            try
            {
                await eSContext.Scenes.AddAsync(scene);
                var sceneAddedVisitor = SceneAddedVisitor.Instance;
                await scene.AcceptDBVisitor(sceneAddedVisitor, eSContext);
                await eSContext.SaveChangesAsync();
                return scene;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Transition?> AddTransition(Scene modifiedScene, Transition transition)
        {
            using ESContext context = new ESContext();

            try
            {
                context.Scenes.Attach(modifiedScene);
                context.Scenes.Attach(transition.TargetScene);
                await context.Transitions.AddAsync(transition);
                await context.SaveChangesAsync();

                var firstScene = await FindFirstScene(context);
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

        private async Task<Scene?> FindFirstScene(ESContext context)
        {
            var scene = (await context
                    .FirstScene
                    .FromSqlRaw("SELECT * FROM FirstScene WHERE Id = 1")
                    .Include(fs => fs.Scene)
                    .FirstOrDefaultAsync())?.Scene;

            return scene;
        }

        private async Task LoadSceneDependencies(ESContext context)
        {
            var task1 = context.Scenes
                .Include(s => s.Transitions)
                .ThenInclude(t => t.Conditions)
                .ToListAsync();

            var task2 = context.ChoiceScenes
            .Include(s => s.Characters)
            .Include(s => s.Choices)
            .Include(s => s.Transitions)
            .ToListAsync();


            var task3 = context.StandardScenes
                .Include(s => s.Characters)
                .Include(s => s.Dialogue)
                .ThenInclude(d => d.Character)
                .ToListAsync();

            var task4 = context.MadeChoicesConditions
                .Include(s => s.Choices)
                .ToListAsync();

            await Task.WhenAll(task1, task2, task3, task4);

        }

        internal async Task<Scene?> GetFirstScene()
        {
            using ESContext context = new ESContext();

            await LoadSceneDependencies(context);
            var scene = await FindFirstScene(context);

            if (scene == null)
                return null;

            return scene;
        }
    }
}
