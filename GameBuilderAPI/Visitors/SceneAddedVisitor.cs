using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Visitors;

namespace GameBuilder.Visitors
{
    internal class SceneAddedVisitor : ISceneVisitorDB
    {
        private static SceneAddedVisitor _Instance;

        public static SceneAddedVisitor Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SceneAddedVisitor();
                return _Instance;
            }
        }
        private SceneAddedVisitor()
        {
        }

        public async Task Visit(StandardScene scene, ESContext context)
        {
            AvoidPossibleCharacterAddition(scene, context);
        }

        public async Task Visit(ChoiceScene scene, ESContext context)
        {
            try
            {
                await context.Choices.AddRangeAsync(scene.Choices);
            }
            catch (Exception)
            {
                await Console.Out.WriteLineAsync();
                throw;
            }
        }

        private void AvoidPossibleCharacterAddition(Scene scene, ESContext context)
        {
            if (scene is StandardScene standardScene && standardScene.Dialogue.Character != null)
            {
                context.Entry(standardScene.Dialogue.Character).State = EntityState.Unchanged;
            }
        }
    }
}
