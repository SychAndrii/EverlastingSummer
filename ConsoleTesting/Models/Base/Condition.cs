using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    /// <summary>
    /// Each <see cref="SceneParts.Transition"/> may have a condition. If condition is not satisfied by a player,
    /// a player cannot move to the <see cref="SceneParts.Transition.TargetScene"/> (next scene).
    /// </summary>
    /// <example>
    /// If I did not pick up an apple in the previous scene, I cannot move to the next scene, which 
    /// shows sharing this apple with my friend.
    /// </example>
    public abstract class Condition
    { 
        private readonly Guid _Id;
        public Guid Id { get => _Id; }

        /// <summary>
        /// Returns true if a user can use the <see cref="SceneParts.Transition"/> class to move to the 
        /// next scene.
        /// </summary>
        /// <param name="player">An instance of player.</param>
        /// <returns>True if a user can go to the next scene specified by <see cref="SceneParts.Transition.TargetScene"/>.
        /// False otherwise.</returns>
        public abstract bool CanTransit(SingletonPlayer player);
    }
}
