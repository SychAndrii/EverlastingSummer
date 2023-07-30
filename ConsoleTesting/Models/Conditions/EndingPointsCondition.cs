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
    public class EndingPointsCondition : Condition
    {
        public int PointsRequired { get; set; }
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
