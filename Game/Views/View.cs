using ConsoleTesting.Models.Base;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameConsumer.Views
{
    class View<T> 
        where T : Scene
    {
        private SceneInputStrategy<T> SceneInputStrategy { get; }
        private SceneShowStrategy<T> SceneShowStrategy { get; }
        private SceneSwitchCanHappenStrategy<T> SceneSwitchCanHappenStrategy { get; }


        public View(SceneSwitchCanHappenStrategy<T> sceneSwitchCanHappenStrategy, SceneInputStrategy<T> sceneInputStrategy, SceneShowStrategy<T> sceneShowStrategy)
        {
            SceneInputStrategy = sceneInputStrategy;
            SceneShowStrategy = sceneShowStrategy;
            SceneSwitchCanHappenStrategy = sceneSwitchCanHappenStrategy;
        }

        public void Show(T scene)
        {
            bool canSwitch = false;
            SceneShowStrategy?.Show(scene);

            while (!canSwitch)
            {
                string userInput = SceneInputStrategy.AskForInput(scene);
                if (SceneSwitchCanHappenStrategy.CanSwitch(userInput, scene))
                {
                    Console.WriteLine("\n");
                    break;
                }
            }

        }
    }
}
