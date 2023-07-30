using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    public abstract class SwitchableScene : Scene
    {
        public IEnumerable<Transition>? Transitions { get; set; } = null;
        public SwitchableScene(IEnumerable<Transition>? transitions)
        {
            Transitions = transitions;
        }
    }
}
