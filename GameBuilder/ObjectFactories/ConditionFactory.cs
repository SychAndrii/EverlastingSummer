using ConsoleTesting.Models.Conditions;
using DB.Models.Characters;
using GameBuilder.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameBuilderAPI.ObjectFactories
{
    internal class ConditionFactory
    {
        private static ConditionFactory _Instance;
        public static ConditionFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ConditionFactory();
                return _Instance;
            }
        }
        private ConditionFactory() { }

        public MadeChoicesCondition CreateMadeChoicesCondition(IEnumerable<Choice> choices)
        {
            return new MadeChoicesCondition
            {
                Choices = choices,
            };
        }
    }
}
