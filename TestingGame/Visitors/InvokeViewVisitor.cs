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
        public async Task Visit(StandardScene scene)
        {
            var sceneInputStrategy = new StandardSceneInputStrategy();
            var sceneShowStrategy = new StandardSceneShowStrategy();
            var sceneSwitchCanHappenStrategy = new StandardSceneSwitchCanHappen();

            var view = new View<StandardScene>(sceneSwitchCanHappenStrategy, sceneInputStrategy, sceneShowStrategy);
            await view.Show(scene);
        }

        public async Task Visit(ChoiceScene scene)
        {
            var sceneInputStrategy = new ChoiceSceneInputStrategy();
            var sceneShowStrategy = new ChoiceSceneShowStrategy();
            var sceneSwitchCanHappenStrategy = new ChoiceSceneSwitchCanHappen();

            scene.Choices = scene.Choices.OrderBy(c => c.Order).ToList();

            sceneSwitchCanHappenStrategy.OnChoiceMade += async (choice) =>
            {
                await UserModel.AddMadeChoice(
                    UserModel.CurrentUser,
                    choice
                );

                if(choice.StateModifiers != null)
                {
                    await UserModel.UpdateStateProgresses(
                        UserModel.CurrentUser,
                        choice.StateModifiers
                    );
                }
            };

            var view = new View<ChoiceScene>(sceneSwitchCanHappenStrategy, sceneInputStrategy, sceneShowStrategy);
            await view.Show(scene);
        }
    }
}
