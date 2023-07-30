using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    public abstract class Scene
    {
        private readonly Guid _Id = Guid.NewGuid();
        public Guid Id { get => _Id; }
        public abstract void Show();
    }
}
