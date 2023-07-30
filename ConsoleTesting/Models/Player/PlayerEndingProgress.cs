using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Player
{
    public class PlayerEndingProgress
    {
        public int CurrentPoints { get; set; }
        public Guid EndingId { get; set; } // Foreign key for Ending
        public Ending Ending { get; set; }
    }
}
