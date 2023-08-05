using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelModels.Models.Scenes
{
    /// <summary>
    /// To begin a game, we need to know where to start. This class is required to create a separate table
    /// in the database, to store information about the first scene in the game. 
    /// </summary>
    public class FirstScene
    {
        /// <summary>
        /// Since we can have only one first scene, we need to make sure that we have only one row in a 
        /// FirstScenes database table. Since it is not possible, we impose a UNIQUE constraint to have only
        /// one id with true value. Row with false id should ignored.
        /// Since 
        /// </summary>
        public bool Id { get; set; } = true;

        /// <summary>
        /// Reference to the actual instance of a first scene in the game.
        /// </summary>
        public Scene? Scene { get; set; }
    }
}
