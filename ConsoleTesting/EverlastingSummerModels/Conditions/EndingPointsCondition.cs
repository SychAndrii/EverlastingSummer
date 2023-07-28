using ConsoleTesting.EverlastingSummerModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.EverlastingSummerModels.Conditions
{
    public class EndingPointsCondition : Condition
    {
        public EndingPoints TargetEnding { get; }
        public Operation Comparison { get; }
        public enum Operation
        {
            LESS,
            BIGGER,
            EQUAL,
            NOT_EQUAL,
        }

        public EndingPointsCondition(int requiredPoints, Ending ending, Operation operation)
        {
            TargetEnding = new EndingPoints(ending, requiredPoints);
            Comparison = operation;
        }

        public override bool CanTransit(Player player)
        {
            var playerPoints = player.Endings.First(end => end.Ending.Equals(TargetEnding));

            if(playerPoints == null)
                return false;

            if (Comparison == Operation.LESS)
                return playerPoints.Points < TargetEnding.Points;
            if(Comparison == Operation.BIGGER)
                return playerPoints.Points > TargetEnding.Points;
            if (Comparison == Operation.NOT_EQUAL)
                return playerPoints.Points != TargetEnding.Points;
            return playerPoints.Points == TargetEnding.Points;
        }
    }
}
