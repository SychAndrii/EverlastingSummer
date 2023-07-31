using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilder.Controllers;
using GameBuilder.Factories;

namespace GameBuilder
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            using ESContext context = new ESContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var c1 = CreateCharacter("Adrian");
            var c2 = CreateCharacter("Mary");
            var c3 = CreateCharacter("Old Man");
            var c4 = CreateCharacter("Ghost");


        }

        private static async Task<DialogueCharacter?> CreateCharacter(string names)
        {
            return await GameBuilderController.AddDialogueCharacter(
                CharacterFactory.Instance.CreateDialogueCharacter("Old Man")
            );
        }
    }
}