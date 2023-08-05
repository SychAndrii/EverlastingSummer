using ConsoleTesting.Models.Base;
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

        public Transition CreateTransition(Scene sourceScene, Scene targetScene, IEnumerable<Condition>? conditions = null)
        {
            return new Transition()
            {
                SourceScene = sourceScene,
                TargetScene = targetScene,
                Conditions = conditions
            };
        }
    }
}
