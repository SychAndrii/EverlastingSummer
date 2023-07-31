using ConsoleTesting.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.SceneParts
{
    public abstract class SideEffect
    {

        private readonly Guid _Id;
        public Guid Id { get => _Id; }
        public abstract void Execute();
    }
}
