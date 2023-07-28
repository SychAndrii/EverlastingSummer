using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTesting.Models.Player;

namespace ConsoleTesting.EverlastingSummerModels.Base
{
    public abstract class Condition
    {
        public abstract bool CanTransit(Player player);
    }
}
