using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.SceneParts;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilder.Controllers;
using GameBuilder.Factories;
using GameBuilder.Helpers;
using GameBuilder.ObjectFactories;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace GameBuilder
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            using ESContext context = new ESContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var c1 = CreateCharacter("Adrian").Result;
            var c2 = CreateCharacter("Mary").Result;
            var c3 = CreateCharacter("Old Man").Result;
            var c4 = CreateCharacter("Ghost").Result;

            Scene? beginningScene = CreateStandardScene(
                "Adrian arrives in the small mysterious town of Somber, where the fog seems to be eternal. Upon arrival, he checks into a local hotel, where he meets Mary, the owner of the hotel."
                ).Result;

            Scene? scene2 = CreateStandardScene(
                "You know, Adrian, there is a legend about a house in our city. The house that no one can find... It is full of secrets and mysteries. I think you will be interested.", 
                c2).Result;

            beginningScene = AddTransition(beginningScene!, scene2!).Result;

            Scene? currentScene = beginningScene;
            Transition? transitionToNextScene = null;

            while(true)
            {
                currentScene?.Show();
                transitionToNextScene = currentScene?.GetPossibleTransition(new User());
                if (transitionToNextScene == null)
                    break;
                currentScene = transitionToNextScene.TargetScene;
            }
        }

        private static async Task<DialogueCharacter?> CreateCharacter(string name)
        {
            return await GameBuilderController.AddDialogueCharacter(
                CharacterFactory.Instance.CreateDialogueCharacter(name)
            );
        }

        private static async Task<StandardScene?> CreateStandardScene(string dialogueText, DialogueCharacter? character = null, IEnumerable<SpriteCharacter>? characters = null)
        {
            return (StandardScene?)await GameBuilderController.AddScene(
                SceneFactory.Instance.CreateStandardScene(dialogueText, character, characters)
            );
        }

        private static async Task<Scene?> AddTransition(Scene modifiableScene, Scene targetScene, IEnumerable<Condition>? conditions = null, IEnumerable<SideEffect>? sideEffects = null)
        {
            var transition = TransitionFactory.Instance.CreateTransition(targetScene, conditions, sideEffects);
            return await GameBuilderController.AddTransition(modifiableScene, transition);

        }
    }
}