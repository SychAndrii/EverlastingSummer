using ConsoleTesting.EverlastingSummerModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.EverlastingSummerModels.Scenes
{
    public class StandardScene : Scene
    {
        public string Dialogue { get; }

        public StandardScene(string dialogue, IEnumerable<Transition>? transitions = null) : base(transitions)
        {
            Dialogue = dialogue;
        }

        public override void Show()
        {
            Console.WriteLine(Dialogue);
        }
    }
}
