using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Visitors;

namespace GameBuilderAPI.Visitors
{
    internal class LoadDependenciesVisitor : ISceneVisitorDB
    {
        public async Task Visit(StandardScene scene, ESContext context)
        {
            await context.StandardScenes
                .Include(s => s.Dialogue)
                .ThenInclude(d => d.Character)
                .ToListAsync();
        }

        public async Task Visit(ChoiceScene scene, ESContext context)
        {
            var choiceScenes = await context.ChoiceScenes.ToListAsync();

            foreach (var s in choiceScenes)
            {
                scene.Choices = await context.Choices
                                .Where(c => c.ChoiceSceneId == scene.Id)
                                .OrderBy(c => c.Order)
                                .ToListAsync();
            }
        }
    }
}
