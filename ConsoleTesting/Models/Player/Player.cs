using ConsoleTesting.EverlastingSummerModels;
using ConsoleTesting.EverlastingSummerModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Player
{
    public class Player
    {
        public ICollection<EndingPoints> Endings { get; set; }
        public ICollection<Choice> Choices { get; set; }

    }
}
