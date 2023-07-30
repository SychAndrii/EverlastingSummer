using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.SceneParts
{
    public class Transition
    {

        private readonly Guid _Id;
        public Guid Id { get => _Id; }
        public IEnumerable<Condition> Conditions { get; set; }
        public Scene TargetScene { get; set; }
    }
}
