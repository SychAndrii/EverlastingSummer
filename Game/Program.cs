using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
using GameConstructor;

namespace GameBuilder
{
    public class GameConsumer
    {
        public static void Main(string[] args)
        {
            Scene? currentScene = GameConstructor.GameBuilder.Construct().Result;
            Transition? transitionToNextScene = null;

            while (true)
            {
                currentScene?.Show();
                transitionToNextScene = currentScene?.GetPossibleTransition(new User());
                if (transitionToNextScene == null)
                    break;
                currentScene = transitionToNextScene.TargetScene;
            }

        }
    }
}