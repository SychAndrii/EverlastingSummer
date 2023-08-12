using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Views.SceneShow
{
    internal class StandardSceneShowStrategy : SceneShowStrategy<StandardScene>
    {
        public void Show(StandardScene scene)
        {
            string userInput;
            if (scene.Dialogue.Character != null)
            {
                Console.WriteLine($"{scene.Dialogue.Character}:");
            }
            Console.WriteLine($"{scene.Dialogue.Text}\n");
        }
    }
}
