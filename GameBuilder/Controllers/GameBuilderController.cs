using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using ConsoleTesting.Services;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilder.Controllers
{
    public static class GameBuilderController
    {
        private static SceneService SceneService = SceneService.Instance;
        private static CharacterService DialogueCharactersService = CharacterService.Instance;

        public static async Task<DialogueCharacter?> AddDialogueCharacter(DialogueCharacter dialogueCharacter)
        {
            return await DialogueCharactersService.AddCharacter(dialogueCharacter);
        }

        public static async Task<Scene?> AddScene(Scene scene)
        {
            return await SceneService.AddScene(scene);
        }

        public static async Task<SwitchableScene?> AddTransition(SwitchableScene scene, Transition transition)
        {
            return await SceneService.AddTransition(scene, transition);
        }
    }
}
