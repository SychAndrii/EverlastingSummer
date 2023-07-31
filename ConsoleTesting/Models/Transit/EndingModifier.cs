using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.SceneParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Transit
{
    public class EndingModifier : SideEffect
    {
        public Ending Ending { get; set; }
        public int Points { get; set; }
        public User User { get; set; }

        public override void Execute()
        {
            var playerProgressEnding = User.EndingProgresses
                .Where(progress => progress.Ending.Equals(Ending))
                .FirstOrDefault();

            if(playerProgressEnding != null)
            {
                playerProgressEnding.CurrentPoints += Points;
            }
        }
    }
}
