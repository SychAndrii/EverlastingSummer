using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTesting.EverlastingSummerModels.Base;

namespace ConsoleTesting.EverlastingSummerModels.Endings
{
    public class EndingsContainer
    {
        public IEnumerable<Ending> Endings { get; }

        public EndingsContainer(IEnumerable<Ending> endings)
        {
            Endings = endings;
        }
    }
}
