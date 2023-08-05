using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Views.SceneInput
{
    internal class ChoiceSceneInputStrategy : SceneInputStrategy<ChoiceScene>
    {
        public string AskForInput(ChoiceScene scene)
        {
            Console.Write("Choose: ");
            return Console.ReadLine();
        }
    }
}
