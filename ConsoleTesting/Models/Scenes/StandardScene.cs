using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Scenes
{
    public class StandardScene : SwitchableScene
    {
        public string Dialogue { get; set; }

        public StandardScene(string dialogue)
        {
            Dialogue = dialogue;
        }

        public override void Show()
        {
            Console.WriteLine(Dialogue);
        }
    }
}
