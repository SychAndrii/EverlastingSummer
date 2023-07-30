using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTesting.Models.SceneParts;

namespace ConsoleTesting.Models.Base
{
    public abstract class SwitchableScene : Scene
    {
        public IEnumerable<Transition>? Transitions { get; set; } = null;
    }
}
