using ConsoleTesting.Database;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    /// <summary>
    /// Represents a single scene in a visual novel. A scene is a `current moment in time`, what is currently
    /// displayed on the screen of a player.
    /// </summary>
    /// <example>
    /// Scene 1:
    /// Text - I woke up. I don't remember how I got here. 
    /// Background - Bedroom.png
    /// Characters - None
    /// 
    /// Scene 2:
    /// Text - Oh, hello there!
    /// Backgorund - Bedroom.png
    /// Characters - Unknown girl
    /// 
    /// Scene 3:
    /// Text - We went outside.
    /// Background - Street.png
    /// Characters - Unknown girl
    /// </example>
    public abstract class Scene
    {
        private readonly Guid _Id = Guid.NewGuid();
        public Guid Id { get => _Id; }
        public abstract void Show();

        private Transition? GetPossibleConditionalTransition(User user)
        {
            return (from transition in Transitions
                    from condition in transition.Conditions ?? Enumerable.Empty<Condition>()
                    where condition.CanTransit(new User())
                    select transition)
                    .FirstOrDefault();
        }

        private Transition? GetPossibleGeneralTransition()
        {
            return (from transition in Transitions
                    where transition.Conditions == null
                    select transition)
                    .FirstOrDefault();
        }

        public Transition? GetPossibleTransition(User user)
        {
            if(Transitions == null) 
                return null;

            return GetPossibleConditionalTransition(user) ?? GetPossibleGeneralTransition();
        }

        /// <summary>
        /// Scenes are connected with each other through transitions. Previous scene points to the next 
        /// scene with a transition. A scene may have more than one transition pointing from it to
        /// the next scenes.
        /// </summary>
        /// <remarks>
        /// <see cref="Transition"/> for more concrete description of Transition class.
        /// </remarks>
        public ICollection<Transition>? Transitions { get; set; } = null;
        public IEnumerable<SpriteCharacter>? Characters { get; set; }
    }
}
