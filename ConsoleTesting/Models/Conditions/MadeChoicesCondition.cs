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
    public class MadeChoicesCondition : Condition
    {
        public IEnumerable<Choice> Choices { get; set; }

        public MadeChoicesCondition()
        {
            Choices = new List<Choice>();
        }

        public override bool CanTransit(SingletonPlayer player)
        {
            return Choices.Intersect(player.Choices).Count() == player.Choices.Count();
        }
    }
}
