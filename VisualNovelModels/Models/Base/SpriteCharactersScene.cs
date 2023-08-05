using ConsoleTesting.Models.Base;
using DB.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelModels.Models.Base
{
    /// <summary>
    /// Represents a scene, which may display characters. Not every scene can have characters (Video Scene, 
    /// for example). Thus, we need a separate class for this type of scene.
    /// </summary>
    public abstract class SpriteCharactersScene : Scene
    {
        /// <summary>
        /// Characters, which are displayed on the screen.
        /// </summary>
        public IEnumerable<SpriteCharacter>? Characters { get; set; }
    }
}
