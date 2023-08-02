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

            var adrian = CreateCharacter("Adrian").Result;
            var mary = CreateCharacter("Mary").Result;
            var oldMan = CreateCharacter("Old Man").Result;
            var ghost = CreateCharacter("Ghost").Result;

            Scene? scene1 = CreateStandardScene(
                "It's a small town called Somber. Always deserted streets, always the same faces. But today I'm the one who shows up."
                ).Result;

            Scene? scene2 = CreateStandardScene(
                "Hello, young man. My name is Mary. Welcome to Somber.",
                mary).Result;

            Scene? scene3 = CreateStandardScene(
                "Hello, Mary. I'm Adrian. Nice to meet you.",
                adrian).Result;

            Scene? scene4 = CreateStandardScene(
                "Mary, with genuine interest, begins to tell a story about a house that no one can find."
                ).Result;

            Scene? scene5 = CreateStandardScene(
                "You know, Adrian, there's a story about a house that lurks in the woods. Some say it's cursed...",
                mary).Result;

            AddTransition(scene1!, scene2!).Wait();
            AddTransition(scene2!, scene3!).Wait();
            AddTransition(scene3!, scene4!).Wait();
            AddTransition(scene4!, scene5!).Wait();


            Scene? currentScene = scene1;
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
            var transition = TransitionFactory.Instance.CreateTransition(modifiableScene, targetScene, conditions, sideEffects);
            return await GameBuilderController.AddTransition(modifiableScene, transition);

        }
    }
}