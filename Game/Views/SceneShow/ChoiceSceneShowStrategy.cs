using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Views.SceneShow
{
    internal class ChoiceSceneShowStrategy : SceneShowStrategy<ChoiceScene>
    {
        public override void Show(ChoiceScene scene)
        {
            var index = 1;
            foreach (var item in scene.Choices)
            {
                Console.WriteLine($"{index++}) {item}");
            }
        }
    }
}
