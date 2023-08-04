using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Base
{
    internal abstract class SceneSwitchCanHappenStrategy<T>
        where T : Scene
    {
        public abstract bool CanSwitch(string userInput, T scene);
    }
}
