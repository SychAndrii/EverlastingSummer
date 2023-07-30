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
    }
}
