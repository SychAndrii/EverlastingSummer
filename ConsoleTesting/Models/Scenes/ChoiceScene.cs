using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Scenes
{
    /*
    [NotMapped]
    public class ChoiceScene : Scene
    {
        public IEnumerable<Choice> Choices { get; }

        public ChoiceScene(IEnumerable<Choice> choices, IEnumerable<Transition>? transitions = null) : base(transitions)
        {
            Choices = choices;
        }

        public override void Show()
        {
            Console.WriteLine("Choose your destiny:\n");
            int index = 1;
            foreach (Choice choice in Choices)
            {
                Console.WriteLine($"\t{index++}) {choice}");
            }
        }
    }
    */
}
