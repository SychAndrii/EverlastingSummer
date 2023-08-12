using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Views.SceneInput
{
    internal class StandardSceneInputStrategy : SceneInputStrategy<StandardScene>
    {
        public string AskForInput(StandardScene scene)
        {
            Console.Write("Press <ENTER> to continue: ");
            var input = Console.ReadLine();
            return input;
        }
    }
}
