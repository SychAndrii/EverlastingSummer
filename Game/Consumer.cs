using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;

namespace GameBuilder
{
    public class Consumer
    {
        public static void Main(string[] args)
        {
            Scene? currentScene = Builder.Build().Result;
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