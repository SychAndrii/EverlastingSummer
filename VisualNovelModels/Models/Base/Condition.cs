using ConsoleTesting.Database;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Visitors;

namespace ConsoleTesting.Models.Base
{
    /// <summary>
    /// Each <see cref="Transit.Transition"/> may have a condition. If condition is not satisfied by a player,
    /// a player cannot move to the <see cref="Transition.TargetScene"/> (next scene).
    /// </summary>
    /// <example>
    /// If I did not pick up an apple in the previous scene, I cannot move to the next scene, which 
    /// shows sharing this apple with my friend.
    /// </example>
    public abstract class Condition
    { 
        private readonly Guid _Id;
        public Guid Id { get => _Id; }
        public Transition Transition { get; set; }
        public Guid? TransitionId { get; set; }
        public abstract Task AcceptDBVisitor(IConditionVisitorDB visitor, ESContext context);

        /// <summary>
        /// Returns true if a user can use the <see cref="Transit.Transition"/> class to move to the 
        /// next scene.
        /// </summary>
        /// <param name="player">An instance of player.</param>
        /// <returns>True if a user can go to the next scene specified by <see cref="Transition.TargetScene"/>.
        /// False otherwise.</returns>
        public abstract bool CanTransit(User player);
    }
}
