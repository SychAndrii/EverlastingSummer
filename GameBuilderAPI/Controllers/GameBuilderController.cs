using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using ConsoleTesting.Services;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using DB.Services;
using GameBuilder.Services;
using GameBuilderAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameBuilder.Controllers
{
    internal class GameBuilderController
    {
        private readonly CharacterService CharactersService;
        private readonly SceneService SceneService;
        private readonly ChoiceService ChoiceService;
        private readonly StateService StateService;
        private readonly ConditionService ConditionService;
        private readonly UserService UserService;

        public GameBuilderController(CharacterService charactersService, SceneService sceneService, ChoiceService choiceService, StateService stateService, ConditionService conditionService, UserService userService)
        {
            CharactersService = charactersService;
            SceneService = sceneService;
            ChoiceService = choiceService;
            StateService = stateService;
            ConditionService = conditionService;
            UserService = userService;
        }

        public async Task<StateModifier?> AddStateModifier(Choice c, StateModifier stateModifier)
        {
            return await StateService.AddStateModifier(c, stateModifier);
        }

        public async Task<State?> AddState(State state)
        {
            return await StateService.AddState(state);
        }

        public async Task<DialogueCharacter?> AddDialogueCharacter(DialogueCharacter dialogueCharacter)
        {
            return await CharactersService.AddCharacter(dialogueCharacter);
        }

        public async Task<Scene?> AddScene(Scene scene)
        {
            return await SceneService.AddScene(scene);
        }

        public async Task<Transition?> AddTransition(Scene scene, Transition transition)
        {
            return await SceneService.AddTransition(scene, transition);
        }

        internal async Task<Scene?> GetFirstScene()
        {
            return await SceneService.GetFirstScene();
        }

        internal async Task<Condition?> AddCondition(Condition condition)
        {
            return await ConditionService.AddCondition(condition);
        }

        internal async Task<User> GetUser()
        {
            return await UserService.GetUser(); 
        }

        internal async Task<User?> AddMadeUserChoice(User user, Choice c)
        {
            return await UserService.AddMadeUserChoice(user, c);
        }

        internal async Task<Condition?> AddStatePointsCondition(StatePointsCondition statePointsCondition)
        {
            return await ConditionService.AddCondition(statePointsCondition);
        }

        internal async Task<User?> UpdateUserStateProgresses(User currentUser, IEnumerable<StateModifier> stateModifiers)
        {
            return await UserService.UpdateUserStateProgresses(currentUser, stateModifiers);
        }
    }
}
