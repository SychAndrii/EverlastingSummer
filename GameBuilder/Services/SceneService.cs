using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilder.Helpers;
using GameBuilder.Visitors;
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
                eSContext.Scenes.Add(scene);
                var sceneAddedVisitor = SceneAddedVisitor.Instance;
                await scene.Accept(sceneAddedVisitor, eSContext);
                await eSContext.SaveChangesAsync();

                var firstScene = await GetFirstScene();
                if (firstScene == null)
                {
                    await AddFirstScene(scene, eSContext);
                }

                return scene;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Scene?> AddTransition(Scene modifiedScene, Transition transition)
        {
            using ESContext context = new ESContext();

            try
            {
                context.Scenes.Attach(modifiedScene);
                context.Scenes.Attach(transition.TargetScene);
                await context.Transitions.AddAsync(transition);
                await context.SaveChangesAsync();
                return modifiedScene;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        internal async Task<Scene?> GetFirstScene()
        {
            using ESContext context = new ESContext();
            return (await context
                    .FirstScene
                    .FirstOrDefaultAsync(s => s.Id == true))
                    ?.Scene;
        }
    }
}
