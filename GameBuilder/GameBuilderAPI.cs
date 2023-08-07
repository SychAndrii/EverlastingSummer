using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilder.Controllers;
using GameBuilder.Factories;
using GameBuilder.Helpers;
using GameBuilder.ObjectFactories;
using GameBuilderAPI.ObjectFactories;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using VisualNovelModels.Models.Choices;

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

        public static async Task<State?> CreateState(string name)
        {
            return await GameBuilderController.AddState(
                StateFactory.Instance.CreateState(name)  
            );
        }

        public static async Task<DialogueCharacter?> CreateCharacter(string name)
        {
            return await GameBuilderController.AddDialogueCharacter(
                CharacterFactory.Instance.CreateDialogueCharacter(name)
            );
        }

        public static async Task<StateModifier?> AddStateModifier(Choice choice, State state, int points)
        {
            return await GameBuilderController.AddStateModifier(
                choice,
                StateFactory.Instance.CreateStateModifier(state, points)
            );
        }

        public static async Task<ChoiceScene?> CreateChoiceScene(params string[] choices)
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

        public static async Task<Transition?> AddTransition(Scene modifiableScene, Scene targetScene, params Condition[] conditions)
        {
            var transition = TransitionFactory.Instance.CreateTransition(modifiableScene, targetScene, conditions);
            return await GameBuilderController.AddTransition(modifiableScene, transition);

        }

        public static async Task<Scene?> GetFirstScene()
        {
            return await GameBuilderController.GetFirstScene();
        }

        public static async Task<Condition?> CreateMadeChoicesCondition(params Choice[] Choices)
        {
            return await GameBuilderController.AddCondition(
                ConditionFactory.Instance.CreateMadeChoicesCondition(Choices)
            );
        }

        public static async Task<User?> GetUser()
        {
            return await GameBuilderController.GetUser();
        }
    }
}