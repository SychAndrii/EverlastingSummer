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
    internal class LoadDependenciesVisitor : ISceneVisitor
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
            await context.ChoiceScenes
                .Include(s => s.Choices)
                .ToListAsync();
        }
    }
}
