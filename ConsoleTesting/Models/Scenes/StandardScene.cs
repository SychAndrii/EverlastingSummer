using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Scenes
{
    /// <summary>
    /// Represents a scene with text, characters, background. Nothing which influences a story.
    /// </summary>
    /// <remarks>
    /// Imagine a scene in Everlasting Summer with no choice.
    /// </remarks>
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
