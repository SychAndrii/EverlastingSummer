using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Services;
using DB.Models.Characters;
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
        private static DialogueCharactersService DialogueCharactersService = DialogueCharactersService.Instance;

        public static async Task<DialogueCharacter?> AddDialogueCharacter(DialogueCharacter dialogueCharacter)
        {
            return await DialogueCharactersService.AddCharacter(dialogueCharacter);
        }
    }
}
