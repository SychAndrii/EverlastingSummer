using ConsoleTesting.Models.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    /// <summary>
    /// A choice made in choice scenes. Choice scenes are described by <see cref="Scenes.ChoiceScene"/> class.
    /// </summary>
    /// <remarks>
    /// Each time a choice is made by a player, they are stored inside of <see cref="Player.SingletonPlayer.Choices"/> 
    /// class.
    /// </remarks>
    public class Choice
    {
        public string Text { get; set; }

        private readonly Guid _Id = Guid.NewGuid();
        public Guid Id { get => _Id; }

        /// <summary>
        /// This field is required for many-to-many relationship with Choices table in the
        /// database described by <see cref="Conditions.MadeChoicesCondition"/> class.
        /// </summary>
        public IEnumerable<MadeChoicesCondition>? MadeChoicesConditions { get; set; }

        public Choice(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// Returns true if two choices are equal.
        /// </summary>
        /// <remarks>
        /// Two choices with the same text are still treated as different choices because
        /// they have different ids.
        /// </remarks>
        /// <param name="obj">Object of type Choice.</param>
        /// <returns>If object is not of type Choice, will return False.
        /// True if Ids of both objects are equal.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Choice c && c.Id == Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, Id);
        }
    }
}
