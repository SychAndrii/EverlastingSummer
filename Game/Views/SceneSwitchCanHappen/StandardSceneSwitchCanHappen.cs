using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Views.SceneSwitchCanHappen
{
    internal class StandardSceneSwitchCanHappen : SceneSwitchCanHappenStrategy<StandardScene>
    {
        public async Task<bool> CanSwitch(string userInput, StandardScene scene)
        {
            return userInput == "";
        }
    }
}
