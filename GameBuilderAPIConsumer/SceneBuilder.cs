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

            Scene? scene1_1 = await GameBuilderAPI.CreateStandardScene("I'm Adrian, a weary programmer who decided to take a break from the draining city life. Driven by a feeling of exhaustion and curiosity, I've come to the small town of Somber. It's where my sister Mary has been living for years. Today, I'm finally going to see her.");
            Scene? scene1_2 = await GameBuilderAPI.CreateStandardScene("Mary's chosen a quaint little café for our meeting. The place exudes a comforting charm that seems to be a reflection of the town itself. The door chimes, announcing my entrance. I spot Mary, and her face lights up with a warm, sisterly smile.");
            Scene? scene1_3 = await GameBuilderAPI.CreateStandardScene("Adrian! It's so good to see you! Come, sit down. You must be tired from the journey. You'll love Somber, I promise.", mary);
            Scene? scene1_4 = await GameBuilderAPI.CreateStandardScene("I hug Mary, feeling a connection to family that's been missing for too long.");
            Scene? scene1_5 = await GameBuilderAPI.CreateStandardScene("It's good to see you too, Mary. This town seems like just what I need.", adrian);
            Scene? scene1_6 = await GameBuilderAPI.CreateStandardScene("Over cups of tea, Mary and I begin to catch up. We talk about our lives, and the unique sense of community here. The conversation flows naturally, with the familiarity that only siblings share.");
            Scene? scene1_7 = await GameBuilderAPI.CreateStandardScene("Have you ever heard about Somber's history? This town has some intriguing legends and secrets, some of them are even mysterious. It's what makes Somber unique.", mary);

            await GameBuilderAPI.AddTransition(scene1_1!, scene1_2!);
            await GameBuilderAPI.AddTransition(scene1_2!, scene1_3!);
            await GameBuilderAPI.AddTransition(scene1_3!, scene1_4!);
            await GameBuilderAPI.AddTransition(scene1_4!, scene1_5!);
            await GameBuilderAPI.AddTransition(scene1_5!, scene1_6!);
            await GameBuilderAPI.AddTransition(scene1_6!, scene1_7!);

            ChoiceScene? choiceScene1 = await GameBuilderAPI.CreateChoiceScene(
                "Secrets? What do you mean?",
                "You know, I've noticed something different about the vibe here. It's cozy here, but in a peculiar way."
            );

            Choice choiceScene1_choice_1 = choiceScene1.Choices.ElementAt(0);
            Choice choiceScene1_choice_2 = choiceScene1.Choices.ElementAt(1);

            await GameBuilderAPI.AddStateModifier(choiceScene1_choice_1, mysticismInterest, 1);
            await GameBuilderAPI.AddStateModifier(choiceScene1_choice_2, peopleInterest, 1);

            await GameBuilderAPI.AddTransition(scene1_7!, choiceScene1!);

            Scene? scene2_1a = await GameBuilderAPI.CreateStandardScene("Well, there's one house in particular that no one seems to find. Some say it's cursed, others think it's a gateway to another world. It's become a part of the town's identity.", mary);
            Scene? scene2_1b = await GameBuilderAPI.CreateStandardScene("It's the very essence of Somber. We have our own mysteries, our charm. But the one thing that's always fascinated me is the tale of a hidden house in the woods. Some say it's haunted; others think it's a gateway to something else entirely.", mary);

            Condition choiceScene1_conditionA = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene1_choice_1);
            Condition choiceScene1_conditionB = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene1_choice_2);

            await GameBuilderAPI.AddTransition(choiceScene1!, scene2_1a!, choiceScene1_conditionA);
            await GameBuilderAPI.AddTransition(choiceScene1!, scene2_1b!, choiceScene1_conditionB);

            Scene? scene2_2a = await GameBuilderAPI.CreateStandardScene("A cursed house, you say? Now that's something I want to know more about. Tell me everything.", adrian);
            Scene? scene2_3a = await GameBuilderAPI.CreateStandardScene("It's a tale that has fascinated me since I moved here. Some say it appears and disappears at will, others that it's home to otherworldly creatures. It's a place of wonder and fear, enchanting yet dangerous.", mary);
            Scene? scene2_4a = await GameBuilderAPI.CreateStandardScene("Mary's words ignite a spark of mystique in my mind. The house seems to call to me, an unexplored enigma in this small, quiet town. That night, I find myself poring over local maps, planning my journey into the woods.");

            await GameBuilderAPI.AddTransition(scene2_1a!, scene2_2a!);
            await GameBuilderAPI.AddTransition(scene2_2a!, scene2_3a!);
            await GameBuilderAPI.AddTransition(scene2_3a!, scene2_4a!);

            Scene? scene2_2b = await GameBuilderAPI.CreateStandardScene("A hidden house? That sounds intriguing. How can a house be hidden?", adrian);
            Scene? scene2_3b = await GameBuilderAPI.CreateStandardScene("That's where the legend comes into play. They say the house appears only to those who seek it, with a true purpose or desire. Many have gone looking for it, but not all have found it. It's a mystery that's always enchanted me.", mary);
            Scene? scene2_4b = await GameBuilderAPI.CreateStandardScene("Even though I like staying in Somber, the mysterious house grabs my attention. I spend the night in my room, the story stirring my thoughts. A restless curiosity grows within me, and I realize that I need to explore the house myself.");

            await GameBuilderAPI.AddTransition(scene2_1b!, scene2_2b!);
            await GameBuilderAPI.AddTransition(scene2_2b!, scene2_3b!);
            await GameBuilderAPI.AddTransition(scene2_3b!, scene2_4b!);

            Scene? scene2_5 = await GameBuilderAPI.CreateStandardScene("The following morning, I wake with a sense of purpose. Whether it's the allure of the unknown or a need to escape the mundane, I know that I must visit the house. I pack my bag, bid Mary farewell, and set off for the woods, a mixture of excitement and trepidation in my heart.");

            await GameBuilderAPI.AddTransition(scene2_4a!, scene2_5!);
            await GameBuilderAPI.AddTransition(scene2_4b!, scene2_5!);
            
            Scene? scene2_6 = await GameBuilderAPI.CreateStandardScene("Having spent the entire night reading different legends about a haunted house in the local woods, I decided to visit it myself.");
            Scene? scene2_7 = await GameBuilderAPI.CreateStandardScene("The sunset paints the sky over the forest in golden and pink hues. I stand at the entrance, feeling something pulling me inward. The wind whispers to me, calling from the depth of the trees.");
            Scene? scene2_8 = await GameBuilderAPI.CreateStandardScene("There are two paths: the well-trodden trail taken by many, and a lesser-known path that seems mysterious and inviting. What should I choose?");

            await GameBuilderAPI.AddTransition(scene2_5!, scene2_6!);
            await GameBuilderAPI.AddTransition(scene2_6!, scene2_7!);
            await GameBuilderAPI.AddTransition(scene2_7!, scene2_8!);

            ChoiceScene? choiceScene2 = await GameBuilderAPI.CreateChoiceScene(
                "Walk down the well-trodden trail",
                "Explore the lesser-known path"
            );

            await GameBuilderAPI.AddTransition(scene2_8!, choiceScene2!);

            Choice choiceScene2_choice_1 = choiceScene2.Choices.ElementAt(0);
            Choice choiceScene2_choice_2 = choiceScene2.Choices.ElementAt(1);

            await GameBuilderAPI.AddStateModifier(choiceScene2_choice_1, peopleInterest, 1);
            await GameBuilderAPI.AddStateModifier(choiceScene2_choice_2, mysticismInterest, 1);

            Condition choiceScene2_conditionA = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene2_choice_1);
            Condition choiceScene2_conditionB = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene2_choice_2);

            Scene? scene3_1a = await GameBuilderAPI.CreateStandardScene("I choose the well-trodden trail. It's the path many have taken, and I feel it leading me to something familiar and comforting.");
            Scene? scene3_1b = await GameBuilderAPI.CreateStandardScene("This path beckons me with its unexplored nature. I feel there's something here that deserves my attention. It's unusual, but I'm ready to go.");

            var t = await GameBuilderAPI.AddTransition(choiceScene2!, scene3_1a!, choiceScene2_conditionA);
            var tt = await GameBuilderAPI.AddTransition(choiceScene2!, scene3_1b!, choiceScene2_conditionB);
            
        }

    }
}