using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    public class Ending
    { 
        public string Name { get; set; }

        private readonly Guid _Id = Guid.NewGuid();
        public Guid Id  { get => _Id ; }

        public Ending(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Ending e && e.Id == Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }
    }
}
