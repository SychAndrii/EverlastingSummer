using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;
using VisualNovelModels.Visitors;

namespace ConsoleTesting.Models.Conditions
{
    /// <summary>
    /// Condition, which will allow to pass through a transition to the next scene 
    /// if player has made certain choices throughout the game.
    /// </summary>
    public class MadeChoicesCondition : Condition
    {
        /// <summary>
        /// List of choices which user must have made by the time he reached current <see cref="Transit.Transition"/>
        /// transition in order to move to the next scene (<see cref="Transition.TargetScene"/>)
        /// </summary>
        public IEnumerable<Choice> Choices { get; set; }

        public MadeChoicesCondition()
        {
            Choices = new List<Choice>();
        }

        public override bool CanTransit(User player)
        {
            return Choices.Intersect(player.Choices).Count() == player.Choices.Count();
        }

        public override async Task AcceptDBVisitor(IConditionVisitorDB visitor, ESContext context)
        {
            await visitor.Visit(this, context);
        }
    }
}
