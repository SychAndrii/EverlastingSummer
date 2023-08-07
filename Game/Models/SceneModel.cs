using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
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
        private static User? User { get; } = null;
        static SceneModel()
        {
            GameBuilder.Builder.Build().Wait();
            CurrentScene = GameBuilder.Builder.GetFirstScene().Result;
            User = GameBuilder.Builder.GetUser().Result;
        }

        public static Scene? GetNextScene()
        {
            Scene? tempScene = CurrentScene;
            Transition? transitionToNextScene = CurrentScene?.GetPossibleTransition(User);
            CurrentScene = transitionToNextScene?.TargetScene;
            return tempScene;
        }
    }
}
