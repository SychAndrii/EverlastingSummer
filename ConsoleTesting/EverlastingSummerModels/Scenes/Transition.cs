using ConsoleTesting.EverlastingSummerModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.EverlastingSummerModels.Scenes
{
    public class Transition
    {
        public Condition? Condition { get; }
        public Scene TargetScene { get; }

        public Transition(Scene targetScene, Condition? condition = null)
        {
            TargetScene = targetScene;
            Condition = condition;
        }
    }
}
