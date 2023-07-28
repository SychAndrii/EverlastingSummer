using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTesting.EverlastingSummerModels.Scenes;

namespace ConsoleTesting.EverlastingSummerModels.Base
{
    public abstract class Scene
    {
        public IEnumerable<Transition>? Transitions { get; set; } = null;
        public abstract void Show();

        protected Scene(IEnumerable<Transition>? transitions)
        {
            Transitions = transitions;
        }
    }
}
