using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Transit;
using GameBuilder.ObjectFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameBuilderAPI.ObjectFactories
{
    internal class StateFactory
    {
        private static StateFactory _Instance;
        public static StateFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new StateFactory();
                return _Instance;
            }
        }
        private StateFactory() { }

        public State CreateState(string name)
        {
            return new State
            {
                Name = name
            };
        }

        public StateModifier CreateStateModifier(State state, int points)
        {
            return new StateModifier
            {
                Points = points,
                State = state
            };
        }
    }
}
