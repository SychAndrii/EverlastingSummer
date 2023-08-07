using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using GameBuilder.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameBuilder.ObjectFactories
{
    internal class ChoiceFactory
    {
        private static ChoiceFactory _Instance;
        public static ChoiceFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ChoiceFactory();
                return _Instance;
            }
        }
        private ChoiceFactory() { }

        public Choice CreateChoice(string text, IEnumerable<StateModifier>? stateModifiers = null)
        {
            return new Choice(text)
            {
                StateModifiers = stateModifiers
            };
        }
    }
}
