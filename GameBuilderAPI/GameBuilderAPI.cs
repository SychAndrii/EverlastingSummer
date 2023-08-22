using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using ConsoleTesting.Services;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using DB.Services;
using GameBuilder.Controllers;
using GameBuilder.Factories;
using GameBuilder.Helpers;
using GameBuilder.ObjectFactories;
using GameBuilder.Services;
using GameBuilderAPI.ObjectFactories;
using GameBuilderAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using VisualNovelModels.Models.Choices;

namespace GameBuilder
{
    public class GameBuilderAPI
    {
        private readonly GameBuilderController controller;

        public GameBuilderAPI(IServiceProvider serviceProvider, ESContext context)
        {
            RecreateDatabase(context);
            controller = serviceProvider.GetRequiredService<GameBuilderController>();
        }

        private static void RecreateDatabase(ESContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public async Task<State?> CreateState(string name)
        {
            return await controller.AddState(
                StateFactory.Instance.CreateState(name)  
            );
        }

        public async Task<DialogueCharacter?> CreateCharacter(string name)
        {
            return await controller.AddDialogueCharacter(
                CharacterFactory.Instance.CreateDialogueCharacter(name)
            );
        }

        public async Task<StateModifier?> AddStateModifier(Choice choice, State state, int points)
        {
            return await controller.AddStateModifier(
                choice,
                StateFactory.Instance.CreateStateModifier(state, points)
            );
        }

        public async Task<ChoiceScene?> CreateChoiceScene(params string[] choices)
        {
            return (ChoiceScene?)await controller.AddScene(
                SceneFactory.Instance.CreateChoiceScene(choices)
            );
        }

        public async Task<StandardScene?> CreateStandardScene(string dialogueText, DialogueCharacter? character = null, IEnumerable<SpriteCharacter>? characters = null)
        {
            return (StandardScene?)await controller.AddScene(
                SceneFactory.Instance.CreateStandardScene(dialogueText, character, characters)
            );
        }

        public async Task<Transition?> AddTransition(Scene modifiableScene, Scene targetScene, params Condition[] conditions)
        {
            var transition = TransitionFactory.Instance.CreateTransition(modifiableScene, targetScene, conditions.ToList());
            return await controller.AddTransition(modifiableScene, transition);

        }

        public async Task<Scene?> GetFirstScene()
        {
            return await controller.GetFirstScene();
        }

        public async Task<Condition?> CreateMadeChoicesCondition(params Choice[] Choices)
        {
            return await controller.AddCondition(
                ConditionFactory.Instance.CreateMadeChoicesCondition(Choices)
            );
        }

        public async Task<User> GetUser()
        {
            return await controller.GetUser();
        }

        public async Task<User?> AddMadeUserChoice(User user, Choice c)
        {
            return await controller.AddMadeUserChoice(user, c);
        }

        public async Task<Condition?> CreateStatePointsCondition(State state, int minimumPointsRequired)
        {
            return await controller.AddStatePointsCondition(
                ConditionFactory.Instance.CreateStatePointsCondition(state, minimumPointsRequired)
            );
        }

        public async Task<User?> UpdateUserStateProgresses(User currentUser, IEnumerable<StateModifier> stateModifiers)
        {
            return await controller.UpdateUserStateProgresses(currentUser, stateModifiers);
        }
    }
}