using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    /// <summary>
    /// Represents different endings inside of your game. Example: Good Ending, Bad Ending.
    /// </summary>
    /// <example>
    /// Bad Ending, Good Ending, Moderate Ending etc.
    /// </example>
    public class Ending
    { 
        public string Name { get; set; }

        private readonly Guid _Id = Guid.NewGuid();
        public Guid Id  { get => _Id ; }

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
