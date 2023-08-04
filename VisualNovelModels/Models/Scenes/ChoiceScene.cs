using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.SceneParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Visitors;

namespace ConsoleTesting.Models.Scenes
{
    /// <summary>
    /// Represents a scene, which displays a list of choices to choose from. Once a choice is selected, 
    /// a transition to the next scene will happen.
    /// </summary>
    public class ChoiceScene : Scene
    {
        public IEnumerable<Choice> Choices { get; set; }

        public override async Task AcceptDBVisitor(ISceneVisitorDB visitor, ESContext context)
        {
            await visitor.Visit(this, context);
        }

        public override async Task AcceptVisitor(ISceneVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
