using ConsoleTesting.Database;
using ConsoleTesting.Models.Transit;
using DB.Services;
using GameBuilderAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameBuilder.Services
{
    internal class ChoiceService : DBService
    {
        public ChoiceService(ESContext context) : base(context)
        {
        }

        public async Task<Choice?> AddChoice(Choice c)
        {
            try
            {
                foreach (var stateModifier in c.StateModifiers)
                {
                    context.StateModifiers.Attach(stateModifier);
                }
                await context.Choices.AddAsync(c);
                await context.SaveChangesAsync();   
                return c;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task LoadChoiceDependenciesTask()
        {
            return context.Choices
                    .Include(c => c.StateModifiers)
                        .ThenInclude(sm => sm.State) // Include the State property within each StateModifier
                    .ToListAsync();
        }
    }
}
