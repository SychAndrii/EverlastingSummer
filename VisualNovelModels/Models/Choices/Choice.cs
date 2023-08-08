using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelModels.Models.Choices
{
    /// <summary>
    /// A choice made in choice scenes. Choice scenes are described by <see cref="Scenes.ChoiceScene"/> class.
    /// </summary>
    /// <remarks>
    /// Each time a choice is made by a player, they are stored inside of <see cref="Player.User.Choices"/> 
    /// class.
    /// </remarks>
    public class Choice
    {
        public string Text { get; set; }

        private readonly Guid _Id;
        public Guid Id { get => _Id; }
        public int Order { get; set; }

        /// <summary>
        /// This field is required for many-to-many relationship with Choices table in the
        /// database described by <see cref="MadeChoicesCondition"/> class.
        /// </summary>
        public ICollection<MadeChoicesCondition>? MadeChoicesConditions { get; set; }

        /// <summary>
        /// A choice may contain a state modifier, which influences current player's state. When a player 
        /// selects a certain choice, its state modifiers update current player's state.
        /// </summary>
        /// <remarks>
        /// To understand what a state modifer is, see <see cref="StateModifier"/>.
        /// </remarks>
        public IEnumerable<StateModifier>? StateModifiers { get; set; }


        /// <summary>
        /// This field is required for many-to-many relationship with Choices table in the
        /// database described by <see cref="MadeChoicesCondition"/> class.
        /// </summary>
        public ChoiceScene? ChoiceScene { get; set; }

        /// <summary>
        /// This field is required for many-to-many relationship with Choices table in the
        /// database described by <see cref="MadeChoicesCondition"/> class.
        /// </summary>
        public Guid? ChoiceSceneId { get; set; }

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
