using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTesting.Models.Base;

namespace ConsoleTesting.Models.Endings
{
    [NotMapped]
    public class EndingsContainer
    {
        public IEnumerable<Ending> Endings { get; }

        public EndingsContainer(IEnumerable<Ending> endings)
        {
            Endings = endings;
        }
    }
}
