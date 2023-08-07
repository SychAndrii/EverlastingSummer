using ConsoleTesting.Database;
using ConsoleTesting.Models.Transit;
using DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameBuilder.Services
{
    internal class ChoiceService
    {
        private static ChoiceService _Instance;
        public static ChoiceService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ChoiceService();
                return _Instance;
            }
        }
        private ChoiceService() { }

        public async Task<Choice?> AddChoice(Choice c)
        {
            using ESContext context = new ESContext();
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
    }
}
