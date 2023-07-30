using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.SceneParts
{
    [NotMapped]
    public class Transition
    {
        public Condition? Condition { get; }
        public Scene TargetScene { get; }

        public Transition(Scene targetScene, Condition? condition = null)
        {
            TargetScene = targetScene;
            Condition = condition;
        }
    }
}
