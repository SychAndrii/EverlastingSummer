using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Conditions
{
    /// <summary>
    /// Condition, which will allow to pass through a transition to the next scene 
    /// if player has collected enough ending points for an <see cref="Base.Ending"/> instance.
    /// </summary>
    public class EndingPointsCondition : Condition
    {
        /// <summary>
        /// Player must collect at least this amount of points for <see cref="Ending"/>
        /// ending to move to the next scene.
        /// </summary>
        public int PointsRequired { get; set; }

        /// <summary>
        /// Player must collect at least <see cref="PointsRequired"/> points for this ending
        /// to move to the next scene.
        /// </summary>
        public Ending Ending { get; set; }

        public override bool CanTransit(SingletonPlayer player)
        {
            var playerProgressOfEnding = player.EndingProgresses.Where(ep => ep.Ending == Ending).FirstOrDefault();
            if (playerProgressOfEnding != null)
            {
                return playerProgressOfEnding.CurrentPoints == PointsRequired;
            }
            return false;
        }
    }
}
