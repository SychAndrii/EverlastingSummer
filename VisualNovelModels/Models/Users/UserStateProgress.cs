using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Player
{
    /// <summary>
    /// Represents current player's progress in achieving a specific ending. Each ending has a certain 
    /// threshold of points, which player has to pass in order to achieve the ending.
    /// </summary>
    /// <example>
    /// To get Bad Ending, you need to get at least 5 points for Bad Ending.
    /// To get Good Ending, you need to get at least 10 points for Good Ending.
    /// </example>
    public class UserStateProgress
    {
        /// <summary>
        /// Current amount of points player has collected throughout the game for <see cref="Ending"/> ending.
        /// </summary>
        public int CurrentPoints { get; set; }
        public Guid StateId { get; set; }

        /// <summary>
        /// Progress for this ending is tracked with <see cref="CurrentPoints"/>.
        /// </summary>
        public State State { get; set; }
    }
}
