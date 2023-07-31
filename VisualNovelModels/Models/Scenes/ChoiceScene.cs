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
    /// <summary>
    /// Represents a scene, which displays a list of choices to choose from. Once a choice is selected, 
    /// a transition to the next scene will happen.
    /// </summary>
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
