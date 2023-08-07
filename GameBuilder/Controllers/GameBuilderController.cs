using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
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
    internal static class GameBuilderController
    {
        private static CharacterService DialogueCharactersService = CharacterService.Instance;
        private static SceneService SceneService = SceneService.Instance;
        private static ChoiceService ChoiceService = ChoiceService.Instance;
        private static StateService StateService = StateService.Instance;
        private static ConditionService ConditionService = ConditionService.Instance;

        public static async Task<StateModifier?> AddStateModifier(Choice c, StateModifier stateModifier)
        {
            return await StateService.AddStateModifier(c, stateModifier);
        }

        public static async Task<State?> AddState(State state)
        {
            return await StateService.AddState(state);
        }

        public static async Task<DialogueCharacter?> AddDialogueCharacter(DialogueCharacter dialogueCharacter)
        {
            return await DialogueCharactersService.AddCharacter(dialogueCharacter);
        }

        public static async Task<Scene?> AddScene(Scene scene)
        {
            return await SceneService.AddScene(scene);
        }

        public static async Task<Transition?> AddTransition(Scene scene, Transition transition)
        {
            return await SceneService.AddTransition(scene, transition);
        }

        internal static async Task<Scene?> GetFirstScene()
        {
            return await SceneService.GetFirstScene();
        }

        internal static async Task<Condition?> AddCondition(Condition condition)
        {
            return await ConditionService.AddCondition(condition);
        }
    }
}
