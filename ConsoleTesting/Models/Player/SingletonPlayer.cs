using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Player
{
    [NotMapped]
    public class SingletonPlayer
    {
        public ICollection<Choice> Choices { get; set; }
        public ICollection<PlayerEndingProgress> EndingProgresses { get; set; }
    }
}
