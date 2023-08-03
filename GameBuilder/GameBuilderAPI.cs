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
    public class GameBuilderAPI
    {
        static GameBuilderAPI()
        {
            using ESContext context = new ESContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static async Task<DialogueCharacter?> CreateCharacter(string name)
        {
            return await GameBuilderController.AddDialogueCharacter(
                CharacterFactory.Instance.CreateDialogueCharacter(name)
            );
        }

        public static async Task<Choice?> CreateChoice(string text)
        {
            return await GameBuilderController.AddChoice(
                ChoiceFactory.Instance.CreateChoice(text)
            );
        }

        public static async Task<ChoiceScene?> CreateChoiceScene(params Choice[] choices)
        {
            return (ChoiceScene?)await GameBuilderController.AddScene(
                SceneFactory.Instance.CreateChoiceScene(choices)
            );
        }

        public static async Task<StandardScene?> CreateStandardScene(string dialogueText, DialogueCharacter? character = null, IEnumerable<SpriteCharacter>? characters = null)
        {
            return (StandardScene?)await GameBuilderController.AddScene(
                SceneFactory.Instance.CreateStandardScene(dialogueText, character, characters)
            );
        }

        public static async Task<Scene?> AddTransition(Scene modifiableScene, Scene targetScene, IEnumerable<Condition>? conditions = null, IEnumerable<SideEffect>? sideEffects = null)
        {
            var transition = TransitionFactory.Instance.CreateTransition(modifiableScene, targetScene, conditions, sideEffects);
            return await GameBuilderController.AddTransition(modifiableScene, transition);

        }

        public static async Task<Scene?> GetFirstScene()
        {
            return await GameBuilderController.GetFirstScene();
        }
    }
}