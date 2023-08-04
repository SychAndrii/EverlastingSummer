using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
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
    /// Represents a scene with text, characters, background. Nothing which influences a story.
    /// </summary>
    /// <remarks>
    /// Imagine a scene in Everlasting Summer with no choice.
    /// </remarks>
    public class StandardScene : Scene
    {
        public Dialogue Dialogue { get; set; }
        public override async Task AcceptDBVisitor(ISceneVisitorDB visitor, ESContext eSContext)
        {
            await visitor.Visit(this, eSContext);
        }

        public override async Task AcceptVisitor(ISceneVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
