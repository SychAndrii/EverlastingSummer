using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    public abstract class Animation
    {

        private readonly Guid _Id;
        public Guid Id { get => _Id; }
        public abstract void Execute();
    }
}
