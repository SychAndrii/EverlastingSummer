using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.SceneParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Scenes
{
    public class ChoiceScene : SwitchableScene
    {
        public IEnumerable<Choice> Choices { get; set; }

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
}
