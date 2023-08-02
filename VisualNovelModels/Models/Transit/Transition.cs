using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.SceneParts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Transit
{
    /// <summary>
    /// Represents a connection between two scenes. You can see it as an arrow, which goes from one scene to another.
    /// Scene, to which arrow is directed, is the next scene. May have conditions, which may forbid 
    /// transition to the next scene if condnitions are not satisfied.
    /// </summary>
    public class Transition
    {
        private readonly Guid _Id;
        public Guid Id { get => _Id; }

        public IEnumerable<SideEffect>? SideEffects { get; set; }

        public Guid SourceSceneId { get; set; }
        public Scene SourceScene { get; set; }

        /// <summary>
        /// Next scene.
        /// </summary>

        public Guid TargetSceneId { get; set; }
        public Scene TargetScene { get; set; }

        /// <summary>
        /// Conditions, which may prevent transition from happening.
        /// </summary>
        /// <example>
        /// My next scene displays a character shooting from a pistol.
        /// To go to the next scene, I need two conditions:
        /// 1) I have picked up a pistol at home in the previous scenes.
        /// 2) I have put ammo into my pistol in the previous scenes.
        /// </example>
        public IEnumerable<Condition>? Conditions { get; set; }
    }
}
