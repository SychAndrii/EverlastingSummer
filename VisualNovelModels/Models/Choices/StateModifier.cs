using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Transit
{
    /// <summary>
    /// State modifier is an entity, which updates current user's points for a state. 
    /// For example, a good ending modifier, which updates current user's points for good ending
    /// by increasing them by 3.
    /// </summary>
    public class StateModifier
    {
        private Guid _Id;
        public Guid Id { get { return _Id; } }

        /// <summary>
        /// A state to update.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Amount of points to add to user's state.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Updates user's points for a <see cref="State"/> state by <see cref="Points"/> points.
        /// </summary>
        /// <param name="user">Current user.</param>
        public void Execute(User user)
        {
            var playerProgressEnding = user.StateProgresses
                .Where(progress => progress.State.Equals(State))
                .FirstOrDefault();

            if(playerProgressEnding != null)
            {
                playerProgressEnding.CurrentPoints += Points;
            }
        }
    }
}
