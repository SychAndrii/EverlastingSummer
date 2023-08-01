using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.SceneParts;
using ConsoleTesting.Models.Transit;
using GameBuilder.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilder.ObjectFactories
{
    public class TransitionFactory
    {
        private TransitionFactory() { }

        private static TransitionFactory instance;

        public static TransitionFactory Instance
        {
            get
            {
                if (instance == null)
                    instance = new TransitionFactory();
                return instance;
            }
        }

        public Transition CreateTransition(Scene targetScene, IEnumerable<SideEffect>? sideEffects = null, IEnumerable<Condition>? conditions = null)
        {
            return CreateTransition(targetScene, conditions, sideEffects);
        }

        public Transition CreateTransition(Scene targetScene, IEnumerable<Condition>? conditions = null, IEnumerable<SideEffect>? sideEffects = null)
        {
            return new Transition()
            {
                TargetScene = targetScene,
                SideEffects = sideEffects,
                Conditions = conditions
            };
        }
    }
}
