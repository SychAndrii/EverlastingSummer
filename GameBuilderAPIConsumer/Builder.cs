using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
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

            var peopleInterest = await GameBuilderAPI.CreateState("People Interest");
            var mysticismInterest = await GameBuilderAPI.CreateState("Mysticism Interest");

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
           
            ChoiceScene? scene6 = await GameBuilderAPI.CreateChoiceScene(
                "That sounds fascinating, Mary. Tell me more.", 
                "Interesting... But I'd like to know more about the city and its people."
            );
            Choice scene6Choice1 = scene6.Choices.ElementAt(0);
            Choice scene6Choice2 = scene6.Choices.ElementAt(1);

            await GameBuilderAPI.AddStateModifier(scene6Choice1, mysticismInterest, 1);
            await GameBuilderAPI.AddStateModifier(scene6Choice2, peopleInterest, 1);

            await GameBuilderAPI.AddTransition(scene5!, scene6!);

            Scene? scene7a = await GameBuilderAPI.CreateStandardScene("Decades ago, in the heart of the forest stood an abandoned house. It is said that this house was the home of one unfortunate ghost. People from the town heard strange sounds, singing songs of woe, coming from the house at night.", mary);
            Scene? scene7b = await GameBuilderAPI.CreateStandardScene("Somber is a small but very old town. Every house, every street has its own story. Some of them are beautiful, others are dark and frightening. Our town knows many secrets that are waiting to be uncovered.", mary);

            Condition scene6TransitionACondition = await GameBuilderAPI.CreateMadeChoicesCondition(scene6Choice1);
            Condition scene6TransitionBCondition = await GameBuilderAPI.CreateMadeChoicesCondition(scene6Choice2);

            Transition scene6TransitionA = await GameBuilderAPI.AddTransition(scene6!, scene7a!, scene6TransitionACondition);
            Transition scene6TransitionB = await GameBuilderAPI.AddTransition(scene6!, scene7b!, scene6TransitionBCondition);

            return await GameBuilderAPI.GetFirstScene();
        }
    }
}