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
        static SceneModel()
        {
            CurrentScene = GameBuilder.Builder.Build().Result;
        }

        public static Scene? GetNextScene()
        {
            Scene? tempScene = CurrentScene;
            Transition? transitionToNextScene = CurrentScene?.GetPossibleTransition(new User());
            CurrentScene = transitionToNextScene?.TargetScene;
            return tempScene;
        }
    }
}
