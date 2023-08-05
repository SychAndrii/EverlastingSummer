using ConsoleTesting.Models.Base;
using GameBuilder;
using VisualNovelModels.Models.Choices;
using static System.Formats.Asn1.AsnWriter;

namespace GameBuilder
{
    public class Builder
    {
        public static async Task<Scene?> Build()
        {
            var adrian = await GameBuilderAPI.CreateCharacter("Adrian");
            var mary = await GameBuilderAPI.CreateCharacter("Mary");
            var oldMan = await GameBuilderAPI.CreateCharacter("Old Man");
            var ghost = await GameBuilderAPI.CreateCharacter("Ghost");

            Scene? scene1 = await GameBuilderAPI.CreateStandardScene(
                "It's a small town called Somber. Always deserted streets, always the same faces. But today I'm the one who shows up."
            );

            Scene? scene2 = await GameBuilderAPI.CreateStandardScene("Hello, young man. My name is Mary. Welcome to Somber.", mary);

            Scene? scene3 = await GameBuilderAPI.CreateStandardScene("Hello, Mary. I'm Adrian. Nice to meet you.", adrian);

            Scene? scene4 = await GameBuilderAPI.CreateStandardScene("Mary, with genuine interest, begins to tell a story about a house that no one can find.");

            Scene? scene5 = await GameBuilderAPI.CreateStandardScene("You know, Adrian, there's a story about a house that lurks in the woods. Some say it's cursed...", mary);

            await GameBuilderAPI.AddTransition(scene1!, scene2!);
            await GameBuilderAPI.AddTransition(scene2!, scene3!);
            await GameBuilderAPI.AddTransition(scene3!, scene4!);
            await GameBuilderAPI.AddTransition(scene4!, scene5!);

            Choice scene6Choice1 = await GameBuilderAPI.CreateChoice("That sounds fascinating, Mary. Tell me more.");
            Choice scene6Choice2 = await GameBuilderAPI.CreateChoice("Interesting... But I'd like to know more about the city and its people.");

            Scene? scene6 = await GameBuilderAPI.CreateChoiceScene(scene6Choice1, scene6Choice2);

            await GameBuilderAPI.AddTransition(scene5!, scene6!);

            return await GameBuilderAPI.GetFirstScene();
        }
    }
}