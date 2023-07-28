using ConsoleTesting.EverlastingSummerModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.EverlastingSummerModels.Conditions
{
    public class MadeChoicesCondition : Condition
    {
        public IEnumerable<Choice> Choices { get; }

        public MadeChoicesCondition(IEnumerable<Choice> choices)
        {
            Choices = choices;
        }

        public override bool CanTransit(Player player)
        {
            return Choices.Intersect(player.Choices).Count() == player.Choices.Count();
        }
    }
}
