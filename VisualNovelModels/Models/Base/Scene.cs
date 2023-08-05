using ConsoleTesting.Database;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Visitors;

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

        /// <summary>
        /// Function for accepting visitors defined in GameBuilderAPI and GameConsumer. This is needed to not
        /// violate separation of concerns. Models are only concerned about storing data - nothing more.
        /// </summary>
        /// <remarks>
        /// See <see cref="https://refactoring.guru/design-patterns/visitor"/>
        /// </remarks>
        /// <param name="visitor">Concrete ISceneVisitor</param>
        /// <returns>Operation may be asynchronous, so return type is Task.</returns>
        public abstract Task AcceptVisitor(ISceneVisitor visitor);

        /// <summary>
        /// Function for accepting visitors which interact with database. They are only defined inside of 
        /// GameBuilderAPI. This is needed to not violate separation of concerns. Models are only concerned about 
        /// storing data - nothing more.
        /// </summary>
        /// <remarks>
        /// See <see cref="https://refactoring.guru/design-patterns/visitor"/>
        /// </remarks>
        /// <param name="visitor">Concrete ISceneVisitorDB</param>
        /// <returns>Operation may be asynchronous, so return type is Task.</returns>
        public abstract Task AcceptDBVisitor(ISceneVisitorDB visitor, ESContext eSContext);

        /// <summary>
        /// Since a scene may have a lot of transitions to next scenes, we need to find the one, which we can use.
        /// A conditional transition is a transition, which has at least one condition. 
        /// </summary>
        /// <remarks>
        /// To understand what condition means, see <see cref="Condition"/>.
        /// </remarks>
        /// <param name="user">User instance, which has information about current user's made choices
        /// and different endings progresses. We need this information to check it against transition
        /// conditions.</param>
        /// <returns>A possible conditional transition</returns>
        private Transition? GetPossibleConditionalTransition(User user)
        {
            return (from transition in Transitions
                    from condition in transition.Conditions ?? Enumerable.Empty<Condition>()
                    where condition.CanTransit(user)
                    select transition)
                    .FirstOrDefault();
        }

        /// <summary>
        /// Since a scene may have a lot of transitions to next scenes, we need to find the one, which we can use.
        /// A general transition is a transition, which has no conditions. 
        /// </summary>
        /// <remarks>
        /// To understand what condition means, see <see cref="Condition"/>.
        /// </remarks>
        /// <returns>A possible general transition</returns>
        private Transition? GetPossibleGeneralTransition()
        {
            return (from transition in Transitions
                    where transition.Conditions == null
                    select transition)
                    .FirstOrDefault();
        }

        /// <summary>
        /// Since a scene may have a lot of transitions to next scenes, we need to find the one, which we can use.
        /// </summary>
        /// <remarks>
        /// To understand what condition means, see <see cref="Condition"/>.
        /// </remarks>
        /// <returns>A possible transition (either conditional or general). See 
        /// <see cref="GetPossibleConditionalTransition(User)"/> and <see cref="GetPossibleGeneralTransition"/>
        /// for more elaborate information. </returns>
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
        public ICollection<Transition>? Transitions { get; set; }

        /// <summary>
        /// Animatons, which are played when a scene is shown. 
        /// </summary>
        public IEnumerable<Animation>? Animations { get; set; }
    }
}
