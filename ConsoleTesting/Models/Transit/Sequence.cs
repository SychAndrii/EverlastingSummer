using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.SceneParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Transit
{
    public class Sequence : SideEffect
    {
        public IEnumerable<Animation> Animations { get; set; }

        public Sequence()
        {
            Animations = new List<Animation>();
        }

        public override void Execute()
        {
            foreach (var animation in Animations)
            {
                animation.Execute();
            }
        }
    }
}
