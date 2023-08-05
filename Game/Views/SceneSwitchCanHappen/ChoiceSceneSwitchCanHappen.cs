using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Views.SceneSwitchCanHappen
{
    internal class ChoiceSceneSwitchCanHappen : SceneSwitchCanHappenStrategy<ChoiceScene>
    {
        public bool CanSwitch(string userInput, ChoiceScene scene)
        {
            if (int.TryParse(userInput, out int choiceNumber))
            {
                var canSwitch = choiceNumber >= 1 && choiceNumber <= scene.Choices.Count();

                if(canSwitch)
                {

                }

                return canSwitch;
            }
            return false;
        }
    }
}
