using ConsoleTesting.Models.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models.Characters
{
    /// <summary>
    /// Represents an image of a character, who is displayed on the screen.
    /// </summary>
    public class SpriteCharacter
    {
        private readonly Guid _Id;
        public Guid Id { get => _Id; }


        /// <summary>
        /// Is required for many-to-many relationship in the database.
        /// </summary>
        public IEnumerable<StandardScene> StandardScenes { get; set; }

        /// <summary>
        /// Is required for many-to-many relationship in the database.
        /// </summary>
        public IEnumerable<ChoiceScene> ChoiceScenes { get; set; }

        public string SpritePath { get; set; }
    }
}
