using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Player
{
    /// <summary>
    /// Represents current player information. Data, which must be saved between game sessions is stored here.
    /// </summary>
    [NotMapped]
    public class SingletonPlayer
    {
        /// <summary>
        /// Choices, which player has made throughout the game.
        /// </summary>
        public ICollection<Choice> Choices { get; set; }

        /// <summary>
        /// Player's progress for various endings. See <see cref="PlayerEndingProgress"/> for more info.
        /// </summary>
        public ICollection<PlayerEndingProgress> EndingProgresses { get; set; }
    }
}
