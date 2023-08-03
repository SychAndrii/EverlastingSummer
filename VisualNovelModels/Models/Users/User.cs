using ConsoleTesting.Database;
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
    /// Represents current user information. Data, which must be saved between game sessions is stored here.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Choices, which player has made throughout the game.
        /// </summary>
        public ICollection<Choice>? Choices { get; set; }

        private readonly Guid _Id;
        public Guid Id { get => _Id; }

        /// <summary>
        /// Player's progress for various states. See <see cref="UserStateProgress"/> for more info.
        /// </summary>
        public ICollection<UserStateProgress> StateProgresses { get; set; }
    }
}
