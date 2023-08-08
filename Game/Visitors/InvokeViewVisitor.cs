using ConsoleTesting.Database;
using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using GameConsumer.Models;
using GameConsumer.Views;
using GameConsumer.Views.SceneInput;
using GameConsumer.Views.SceneShow;
using GameConsumer.Views.SceneSwitchCanHappen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Visitors;

namespace GameConsumer.Visitors
{
    internal class InvokeViewVisitor : ISceneVisitor
    {
        public Task Visit(StandardScene scene)
        {
            var sceneInputStrategy = new StandardSceneInputStrategy();
            var sceneShowStrategy = new StandardSceneShowStrategy();
            var sceneSwitchCanHappenStrategy = new StandardSceneSwitchCanHappen();

            var view = new View<StandardScene>(sceneSwitchCanHappenStrategy, sceneInputStrategy, sceneShowStrategy);
            view.Show(scene);
            return Task.CompletedTask;
        }

        public Task Visit(ChoiceScene scene)
        {
            var sceneInputStrategy = new ChoiceSceneInputStrategy();
            var sceneShowStrategy = new ChoiceSceneShowStrategy();
            var sceneSwitchCanHappenStrategy = new ChoiceSceneSwitchCanHappen();

            sceneSwitchCanHappenStrategy.OnChoiceMade += async (choice) =>
            {
                await UserModel.AddMadeChoice(
                    UserModel.CurrentUser,
                    choice
                );
            };

            var view = new View<ChoiceScene>(sceneSwitchCanHappenStrategy, sceneInputStrategy, sceneShowStrategy);
            view.Show(scene);
            return Task.CompletedTask;
        }
    }
}
