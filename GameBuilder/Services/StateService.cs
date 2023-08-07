using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameBuilderAPI.Services
{
    internal class StateService
    {
        private static StateService _Instance;
        public static StateService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new StateService();
                return _Instance;
            }
        }
        private StateService() { }

        public async Task<State?> AddState(State state)
        {
            using ESContext context = new ESContext();
            try
            {
                await context.States.AddAsync(state);
                await context.SaveChangesAsync();
                return state;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<StateModifier?> AddStateModifier(Choice c, StateModifier stateModifier)
        {
            using ESContext context = new ESContext();
            try
            {
                context.States.Attach(stateModifier.State);
                context.Entry(c).State = EntityState.Modified;

                await context.StateModifiers.AddAsync(stateModifier);
                await context.SaveChangesAsync();

                // Convert to list, modify, and reassign
                var stateModifiersList = (c.StateModifiers ?? Enumerable.Empty<StateModifier>()).ToList();
                stateModifiersList.Add(stateModifier);
                c.StateModifiers = stateModifiersList;

                context.Choices.Update(c);
                await context.SaveChangesAsync();
                return stateModifier;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
