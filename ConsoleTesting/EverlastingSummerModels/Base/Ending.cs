using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.EverlastingSummerModels.Base
{
    public class Ending
    {
        public string Name { get; }

        public Ending(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Ending e && e.Name == Name;
        }
    }
}
