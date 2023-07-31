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
            context.Database.EnsureCreated();

            var res = GameBuilderController.AddDialogueCharacter(
                CharacterFactory.Instance.CreateDialogueCharacter("Mary")    
            ).Result;

            var res2 = GameBuilderController.AddDialogueCharacter(
                CharacterFactory.Instance.CreateDialogueCharacter("Marina")
            ).Result;

            Console.WriteLine(res);
            Console.WriteLine(res2);
        }
    }
}