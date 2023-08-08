using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using GameBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Models
{
    internal static class SceneModel
    {
        private static Scene? CurrentScene { get; set; } = null;
        static SceneModel()
        {
            SceneBuilder.Build().Wait();
            CurrentScene = SceneBuilder.GetFirstScene().Result;
        }

        public static Scene? GetNextScene()
        {
            Scene? tempScene = CurrentScene;
            Transition? transitionToNextScene = CurrentScene?.GetPossibleTransition(UserModel.CurrentUser);
            CurrentScene = transitionToNextScene?.TargetScene;
            return tempScene;
        }
    }
}
