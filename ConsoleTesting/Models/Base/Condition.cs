using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    public abstract class Condition
    { 
        private readonly Guid _Id;
        public Guid Id { get => _Id; }
        public abstract bool CanTransit(SingletonPlayer player);
    }
}
