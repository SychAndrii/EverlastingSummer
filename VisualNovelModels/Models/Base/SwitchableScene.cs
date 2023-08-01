using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;

namespace ConsoleTesting.Models.Base
{
    /// <summary>
    /// Represents a scene, which player can change by clicking 'next scene' button. 
    /// </summary>
    public abstract class SwitchableScene : Scene
    {
        /// <summary>
        /// Scenes are connected with each other through transitions. Previous scene points to the next 
        /// scene with a transition. A scene may have more than one transition pointing from it to
        /// the next scenes.
        /// </summary>
        /// <remarks>
        /// <see cref="Transition"/> for more concrete description of Transition class.
        /// </remarks>
        public IEnumerable<Transition>? Transitions { get; set; } = null;
        public IEnumerable<SpriteCharacter>? Characters { get; set; }
    }
}
