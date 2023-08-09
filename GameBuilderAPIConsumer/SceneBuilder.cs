using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using VisualNovelModels.Models.Choices;

namespace GameBuilder
{
    public class SceneBuilder
    {
        public static async Task<Scene?> GetFirstScene()
        {
            return await GameBuilderAPI.GetFirstScene();
        }

        public static async Task Build()
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
            Scene? scene7b = await GameBuilderAPI.CreateStandardScene("Mary nods.");

            Condition scene6TransitionACondition = await GameBuilderAPI.CreateMadeChoicesCondition(scene6Choice1);
            Condition scene6TransitionBCondition = await GameBuilderAPI.CreateMadeChoicesCondition(scene6Choice2);

            await GameBuilderAPI.AddTransition(scene6!, scene7a!, scene6TransitionACondition);
            await GameBuilderAPI.AddTransition(scene6!, scene7b!, scene6TransitionBCondition);

            Scene? scene8a = await GameBuilderAPI.CreateStandardScene("Adrian's eyes sparkle with interest.");
            Scene? scene9a = await GameBuilderAPI.CreateStandardScene("And how can I find it?", adrian);
            Scene? scene10a = await GameBuilderAPI.CreateStandardScene("Legend has it that whoever truly believes in magic will be able to see the house.", mary);

            await GameBuilderAPI.AddTransition(scene7a!, scene8a!);
            await GameBuilderAPI.AddTransition(scene8a!, scene9a!);
            await GameBuilderAPI.AddTransition(scene9a!, scene10a!);

            Scene? scene8b = await GameBuilderAPI.CreateStandardScene("Somber is a small but very old town. Every house, every street has its own story. Some of them are beautiful, others are dark and frightening. Our town knows many secrets that are waiting to be uncovered.", mary);
            Scene? scene9b = await GameBuilderAPI.CreateStandardScene("You talk about him as if Somber is a living organism.", adrian);
            Scene? scene10b = await GameBuilderAPI.CreateStandardScene("For many of us, that's exactly what it is. We were born and grew up here, and the city has become a part of us.", mary);
            Scene? scene11b = await GameBuilderAPI.CreateStandardScene("Thank you, Mary. Your town is indeed an interesting place.", adrian);

            await GameBuilderAPI.AddTransition(scene7b!, scene8b!);
            await GameBuilderAPI.AddTransition(scene8b!, scene9b!);
            await GameBuilderAPI.AddTransition(scene9b!, scene10b!);
            await GameBuilderAPI.AddTransition(scene10b!, scene11b!);

            Scene? scene2_1 = await GameBuilderAPI.CreateStandardScene("Good night, Mary.", adrian);

            await GameBuilderAPI.AddTransition(scene10a!, scene2_1!);
            await GameBuilderAPI.AddTransition(scene11b!, scene2_1!);

            Scene? scene2_2 = await GameBuilderAPI.CreateStandardScene("Sweet dreams, young man.", mary);
            Scene? scene2_3 = await GameBuilderAPI.CreateStandardScene("Back in his room, Adrian feels excited from the anticipation of tomorrow.");
            Scene? scene2_4 = await GameBuilderAPI.CreateStandardScene("Day 2");
            Scene? scene2_5 = await GameBuilderAPI.CreateStandardScene("Sunrise greeted Adrian, his eyes sparkling with excitement. Everything he'd heard yesterday seemed so alive and real.");

            await GameBuilderAPI.AddTransition(scene2_1!, scene2_2!);
            await GameBuilderAPI.AddTransition(scene2_2!, scene2_3!);
            await GameBuilderAPI.AddTransition(scene2_3!, scene2_4!);
            await GameBuilderAPI.AddTransition(scene2_4!, scene2_5!);

            Condition? scene2_5TransitionAConditionA = await GameBuilderAPI.CreateStatePointsCondition(mysticismInterest, 1);
            Condition? scene2_5TransitionAConditionB = await GameBuilderAPI.CreateStatePointsCondition(peopleInterest, 1);

            Scene? scene2_6a = await GameBuilderAPI.CreateStandardScene("Adrian decides to go into the woods to search for the mysterious house.");
            Scene? scene2_6b = await GameBuilderAPI.CreateStandardScene("Adrian decides to explore more stories about the town and its people.");

            await GameBuilderAPI.AddTransition(scene2_5!, scene2_6a!, scene2_5TransitionAConditionA);
            await GameBuilderAPI.AddTransition(scene2_5!, scene2_6b!, scene2_5TransitionAConditionB);
        }

    }
}