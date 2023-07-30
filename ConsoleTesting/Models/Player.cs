using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Endings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models
{
    [NotMapped]
    public class Player
    {
        public ICollection<EndingPoints> Endings { get; set; }
        public ICollection<Choice> Choices { get; set; }

    }
}
