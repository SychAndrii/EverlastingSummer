using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using VisualNovelModels.Models.Choices;

namespace GameBuilder
{
    public class SceneBuilder
    {
        private GameBuilderAPI GameBuilderAPI { get; }
        public async Task<Scene?> GetFirstScene()
        {
            return await GameBuilderAPI.GetFirstScene();
        }

        public SceneBuilder(GameBuilderAPI api)
        {
            GameBuilderAPI = api;
        }

        public async Task Build()
        {
            #region CharactersCreatiton
            var adrian = await GameBuilderAPI.CreateCharacter("Adrian");
            var mary = await GameBuilderAPI.CreateCharacter("Mary");
            var oldMan = await GameBuilderAPI.CreateCharacter("Old Man");
            var specter = await GameBuilderAPI.CreateCharacter("Specter");
            var specterMother = await GameBuilderAPI.CreateCharacter("Specter's Mother");
            var specterFather = await GameBuilderAPI.CreateCharacter("Specter's Father");
            #endregion

            #region StatesCreation
            var peopleInterest = await GameBuilderAPI.CreateState("People Interest");
            var mysticismInterest = await GameBuilderAPI.CreateState("Mysticism Interest");
            #endregion

            #region CafeScenes
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

            #endregion

            #region SecretsChoiceScenes
            Scene? scene2_1a = await GameBuilderAPI.CreateStandardScene("Well, there's one house in particular that no one seems to find. Some say it's cursed, others think it's a gateway to another world. It's become a part of the town's identity.", mary);
            
            Condition choiceScene1_conditionA = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene1_choice_1);
            
            await GameBuilderAPI.AddTransition(choiceScene1!, scene2_1a!, choiceScene1_conditionA);

            Scene? scene2_2a = await GameBuilderAPI.CreateStandardScene("A cursed house, you say? Now that's something I want to know more about. Tell me everything.", adrian);
            Scene? scene2_3a = await GameBuilderAPI.CreateStandardScene("It's a tale that has fascinated me since I moved here. Some say it appears and disappears at will, others that it's home to otherworldly creatures. It's a place of wonder and fear, enchanting yet dangerous.", mary);
            Scene? scene2_4a = await GameBuilderAPI.CreateStandardScene("Mary's words ignite a spark of mystique in my mind. The house seems to call to me, an unexplored enigma in this small, quiet town. That night, I find myself poring over local maps, planning my journey into the woods.");

            await GameBuilderAPI.AddTransition(scene2_1a!, scene2_2a!);
            await GameBuilderAPI.AddTransition(scene2_2a!, scene2_3a!);
            await GameBuilderAPI.AddTransition(scene2_3a!, scene2_4a!);
            #endregion

            #region VideChoiceScenes
            Scene? scene2_1b = await GameBuilderAPI.CreateStandardScene("It's the very essence of Somber. We have our own mysteries, our charm. But the one thing that's always fascinated me is the tale of a hidden house in the woods. Some say it's haunted; others think it's a gateway to something else entirely.", mary);

            Condition choiceScene1_conditionB = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene1_choice_2);

            await GameBuilderAPI.AddTransition(choiceScene1!, scene2_1b!, choiceScene1_conditionB);


            Scene? scene2_2b = await GameBuilderAPI.CreateStandardScene("A hidden house? That sounds intriguing. How can a house be hidden?", adrian);
            Scene? scene2_3b = await GameBuilderAPI.CreateStandardScene("That's where the legend comes into play. They say the house appears only to those who seek it, with a true purpose or desire. Many have gone looking for it, but not all have found it. It's a mystery that's always enchanted me.", mary);
            Scene? scene2_4b = await GameBuilderAPI.CreateStandardScene("Even though I like staying in Somber, the mysterious house grabs my attention. I spend the night in my room, the story stirring my thoughts. A restless curiosity grows within me, and I realize that I need to explore the house myself.");

            await GameBuilderAPI.AddTransition(scene2_1b!, scene2_2b!);
            await GameBuilderAPI.AddTransition(scene2_2b!, scene2_3b!);
            await GameBuilderAPI.AddTransition(scene2_3b!, scene2_4b!);
            #endregion

            #region ForestScenes
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
            #endregion

            #region KnownPathChoiceScenes
            Condition choiceScene2_conditionA = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene2_choice_1);

            Scene? scene3_1a = await GameBuilderAPI.CreateStandardScene("I choose the well-trodden trail. It's the path many have taken, and I feel it leading me to something familiar and comforting.");

            await GameBuilderAPI.AddTransition(choiceScene2!, scene3_1a!, choiceScene2_conditionA);

            Scene? scene3_2a = await GameBuilderAPI.CreateStandardScene("Rays of sun penetrate the rustling canopy, dancing on the ground in rhythm with the wind. Amidst the green, I notice something unusual — an abandoned camp of the local dwellers.");
            Scene? scene3_3a = await GameBuilderAPI.CreateStandardScene("Venturing in, I discover tents and campfires scattered by the winds, moss-covered chairs, and tables. The place seems to have once been cozy and lively. My curiosity piqued, I begin to explore.");
            Scene? scene3_4a = await GameBuilderAPI.CreateStandardScene("On one of the overturned tables, I find photographs and letters telling stories of friendship, love, and life of the people who once stayed here.");
            Scene? scene3_5a = await GameBuilderAPI.CreateStandardScene("An echo of the past lives within these things, and I spend some time immersed in their stories, feeling part of something larger and significant.");
            Scene? scene3_6a = await GameBuilderAPI.CreateStandardScene("The memories of simple pleasures and hardships in the lives of the camp's inhabitants fill me with a sense of sympathy and understanding.");
            Scene? scene3_7a = await GameBuilderAPI.CreateStandardScene("I glance over the abandoned space one more time, noticing details that previously escaped my attention: a small toy left on the ground, a piece of fabric fluttering in the wind.");
            Scene? scene3_8a = await GameBuilderAPI.CreateStandardScene("I continue my journey, leaving behind the remnants of memories but carrying them in my heart.");

            await GameBuilderAPI.AddTransition(scene3_1a!, scene3_2a!);
            await GameBuilderAPI.AddTransition(scene3_2a!, scene3_3a!);
            await GameBuilderAPI.AddTransition(scene3_3a!, scene3_4a!);
            await GameBuilderAPI.AddTransition(scene3_4a!, scene3_5a!);
            await GameBuilderAPI.AddTransition(scene3_5a!, scene3_6a!);
            await GameBuilderAPI.AddTransition(scene3_6a!, scene3_7a!);
            await GameBuilderAPI.AddTransition(scene3_7a!, scene3_8a!);
            #endregion

            #region UnknownPathChoiceScenes
            Condition choiceScene2_conditionB = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene2_choice_2);

            Scene? scene3_1b = await GameBuilderAPI.CreateStandardScene("This path beckons me with its unexplored nature. I feel there's something here that deserves my attention. It's unusual, but I'm ready to go.");

            await GameBuilderAPI.AddTransition(choiceScene2!, scene3_1b!, choiceScene2_conditionB);

            Scene? scene3_2b = await GameBuilderAPI.CreateStandardScene("I come across strange symbols on the trunks of a circle of trees. They're etched deep into the bark, forming spirals and intertwined lines.");
            Scene? scene3_3b = await GameBuilderAPI.CreateStandardScene("Some are shaped like eyes, others resemble twisted runes or glyphs. They're not random; they follow a pattern that draws me in, as if calling me to understand their meaning.");
            Scene? scene3_4b = await GameBuilderAPI.CreateStandardScene("The forest grows more mysterious. I feel a cold wind on my face, even though the trees stand still.");
            Scene? scene3_5b = await GameBuilderAPI.CreateStandardScene("Scattered around, I find old, rusted tools - an axe, a shovel, a hammer - partially buried in the ground. They seem to have been left here ages ago, covered in moss and stained with what could be dried blood.");
            Scene? scene3_6b = await GameBuilderAPI.CreateStandardScene("Reaching a clearing, I find a stone, an altar-like rock, at its center. It's engraved with an emblem glowing with an otherworldly light.");
            Scene? scene3_7b = await GameBuilderAPI.CreateStandardScene("The emblem is a circle within a circle, with intricate carvings radiating out like sunbeams. Around the clearing, I notice other stones, placed deliberately to form a foreboding ring.");
            Scene? scene3_8b = await GameBuilderAPI.CreateStandardScene("I feel an overpowering urge to touch the stone. As my hand meets the surface, it vibrates and I hear whispers I can't quite make out.");
            Scene? scene3_9b = await GameBuilderAPI.CreateStandardScene("On my way back, the sensation that the forest has imparted something special lingers. The symbols, the stone circle, the whispers - they all coalesce into a picture inside me, opening a door to a world I never knew existed.");

            await GameBuilderAPI.AddTransition(scene3_1b!, scene3_2b!);
            await GameBuilderAPI.AddTransition(scene3_2b!, scene3_3b!);
            await GameBuilderAPI.AddTransition(scene3_3b!, scene3_4b!);
            await GameBuilderAPI.AddTransition(scene3_4b!, scene3_5b!);
            await GameBuilderAPI.AddTransition(scene3_5b!, scene3_6b!);
            await GameBuilderAPI.AddTransition(scene3_6b!, scene3_7b!);
            await GameBuilderAPI.AddTransition(scene3_7b!, scene3_8b!);
            await GameBuilderAPI.AddTransition(scene3_8b!, scene3_9b!);
            #endregion

            #region OldManInteractionScenes
            Scene? scene3_10 = await GameBuilderAPI.CreateStandardScene("As I wander through the forest, the path leads me to a small clearing where an old man stands.");

            await GameBuilderAPI.AddTransition(scene3_8a!, scene3_10!);
            await GameBuilderAPI.AddTransition(scene3_9b!, scene3_10!);

            Scene? scene3_11 = await GameBuilderAPI.CreateStandardScene("He's dressed in worn-out clothes, leaning on a gnarled walking stick, his eyes hidden beneath thick, white eyebrows. His gaze seems to pierce right through me, knowing why I'm here.");
            Scene? scene3_12 = await GameBuilderAPI.CreateStandardScene("Lost your way, young traveler, or seeking something more?", oldMan);
            Scene? scene3_13 = await GameBuilderAPI.CreateStandardScene("I'm... I'm not sure. I found something in the woods, something I can't explain.", adrian);
            Scene? scene3_14 = await GameBuilderAPI.CreateStandardScene("Ah, the unexplainable often leads us to the most extraordinary discoveries. Come with me, if you dare.", oldMan);
            Scene? scene3_15 = await GameBuilderAPI.CreateStandardScene("The old man leads me to a weathered wooden door, hidden amongst the thick foliage. His hand trembles slightly as he turns the key.");

            await GameBuilderAPI.AddTransition(scene3_10!, scene3_11!);
            await GameBuilderAPI.AddTransition(scene3_11!, scene3_12!);
            await GameBuilderAPI.AddTransition(scene3_12!, scene3_13!);
            await GameBuilderAPI.AddTransition(scene3_13!, scene3_14!);
            await GameBuilderAPI.AddTransition(scene3_14!, scene3_15!);
            #endregion

            #region HighMysticismDialogueScenes
            Scene? scene3_16a = await GameBuilderAPI.CreateStandardScene("Ah, you feel it too, don't you? The pull of the unknown. You're ready for what lies behind this door.", oldMan);

            Condition scene3_15_conditionA = await GameBuilderAPI.CreateStatePointsCondition(mysticismInterest, 2);

            await GameBuilderAPI.AddTransition(scene3_15!, scene3_16a!, scene3_15_conditionA);

            Scene? scene3_17a = await GameBuilderAPI.CreateStandardScene("I feel a connection, a calling almost. What is this place?", adrian);
            Scene? scene3_18a = await GameBuilderAPI.CreateStandardScene("A gateway, young seeker. A place where the veils between worlds grow thin.", oldMan);

            await GameBuilderAPI.AddTransition(scene3_16a!, scene3_17a!);
            await GameBuilderAPI.AddTransition(scene3_17a!, scene3_18a!);
            #endregion

            #region LowMysticismDialogueScenes
            Scene? scene3_16b = await GameBuilderAPI.CreateStandardScene("Be cautious, young one. Not all that is hidden should be uncovered. Are you certain you wish to proceed?", oldMan);

            await GameBuilderAPI.AddTransition(scene3_15!, scene3_16b!);

            Scene? scene3_17b = await GameBuilderAPI.CreateStandardScene("I'm curious but unsure. What lies beyond this door?", adrian);
            Scene? scene3_18b = await GameBuilderAPI.CreateStandardScene("Mysteries, secrets, perhaps danger. Your heart will guide you. Listen to it carefully.", oldMan);

            await GameBuilderAPI.AddTransition(scene3_16b!, scene3_17b!);
            await GameBuilderAPI.AddTransition(scene3_17b!, scene3_18b!);
            #endregion

            #region HouseExplorationScenes
            Scene? scene3_20 = await GameBuilderAPI.CreateStandardScene("The door creaks open to reveal a dimly lit corridor filled with the musty scent of old books and herbs. I step in, feeling both trepidation and excitement.");

            await GameBuilderAPI.AddTransition(scene3_18a!, scene3_20!);
            await GameBuilderAPI.AddTransition(scene3_18b!, scene3_20!);

            Scene? scene3_21 = await GameBuilderAPI.CreateStandardScene("Trust in yourself, and the path will reveal itself. Remember, young seeker, the answers you seek are not only in the physical realm but in the connection between mind, spirit, and the world around you.", oldMan);
            Scene? scene3_22 = await GameBuilderAPI.CreateStandardScene("With those parting words, the door closes behind me, leaving me in the dimly lit corridor, feeling the weight of the old man's wisdom and the anticipation of the unknown.");
            Scene? scene3_23 = await GameBuilderAPI.CreateStandardScene("The corridor leads me to a room that feels alive with mystery.");
            Scene? scene3_24 = await GameBuilderAPI.CreateStandardScene("The walls are a canvas of strange symbols and haunting images, each one telling a story that I can almost understand but not quite grasp. The room pulses with an energy that feels both ancient and urgent.");
            Scene? scene3_25 = await GameBuilderAPI.CreateStandardScene("I explore the room further, trying to make sense of the drawings and the personal belongings scattered around.");
            Scene? scene3_26 = await GameBuilderAPI.CreateStandardScene("The drawings depict figures and scenes that are both earthly and otherworldly. The symbols are a language I can't read but feel an inexplicable connection to. There's a narrative here, a story waiting to be uncovered.");
            Scene? scene3_27 = await GameBuilderAPI.CreateStandardScene("In the middle of the room, an old table stands, adorned with various relics. My eyes are drawn to two particular items: a mysterious amulet and a sealed letter.");
            Scene? scene3_28 = await GameBuilderAPI.CreateStandardScene("The amulet seems to hum with energy, intricate designs weaving around a gemstone that seems to glow from within. It promises protection and power, but it also feels mysterious and potentially dangerous. My instincts warn me it could be cursed or hold a power that's not easily controlled.");
            Scene? scene3_29 = await GameBuilderAPI.CreateStandardScene("The letter, sealed with an ornate symbol, appears to be a piece of the puzzle, something that could explain the mysteries of the house and perhaps even the strange drawings on the walls.");
            Scene? scene3_30 = await GameBuilderAPI.CreateStandardScene("I feel torn between understanding and mystery, between the promise of knowledge and the thrill of the unknown.");

            await GameBuilderAPI.AddTransition(scene3_20!, scene3_21!);
            await GameBuilderAPI.AddTransition(scene3_21!, scene3_22!);
            await GameBuilderAPI.AddTransition(scene3_22!, scene3_23!);
            await GameBuilderAPI.AddTransition(scene3_23!, scene3_24!);
            await GameBuilderAPI.AddTransition(scene3_24!, scene3_25!);
            await GameBuilderAPI.AddTransition(scene3_25!, scene3_26!);
            await GameBuilderAPI.AddTransition(scene3_26!, scene3_27!);
            await GameBuilderAPI.AddTransition(scene3_27!, scene3_28!);
            await GameBuilderAPI.AddTransition(scene3_28!, scene3_29!);
            await GameBuilderAPI.AddTransition(scene3_29!, scene3_30!);

            ChoiceScene? choiceScene3 = await GameBuilderAPI.CreateChoiceScene(
                "Take the Amulet",
                "Take the Letter"
            );

            await GameBuilderAPI.AddTransition(scene3_30!, choiceScene3!);

            Choice choiceScene3_choice_1 = choiceScene3.Choices.ElementAt(0);
            Choice choiceScene3_choice_2 = choiceScene3.Choices.ElementAt(1);

            await GameBuilderAPI.AddStateModifier(choiceScene3_choice_1, mysticismInterest, 1);
            await GameBuilderAPI.AddStateModifier(choiceScene3_choice_2, peopleInterest, 1);
            #endregion

            

            #region Amulet
            Condition choiceScene3_conditionA = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene3_choice_1);
            
            Scene? scene4_1a = await GameBuilderAPI.CreateStandardScene("With a sense of trepidation and excitement, I pick up the amulet. The risks may be great, but so is the allure. I feel its energy resonate with something within me. Perhaps it's a key to something greater.");
            await GameBuilderAPI.AddTransition(choiceScene3!, scene4_1a!, choiceScene3_conditionA);

            Scene? scene4_2a = await GameBuilderAPI.CreateStandardScene("The moment I touch the amulet, a surge of energy courses through me. It's a feeling of empowerment and connection, yet also a hint of something darker, something hidden within the intricate designs and the glowing gemstone.");
            Scene? scene4_3a = await GameBuilderAPI.CreateStandardScene("The room seems to shift slightly, and the symbols on the walls resonate, as if acknowledging the amulet's presence.");
            Scene? scene4_4a = await GameBuilderAPI.CreateStandardScene("As I wear it around my neck, the amulet grows warm, pulsating gently. Visions flash before my eyes: images of rituals, shadowy figures, and a haunting face that seems trapped, crying out for release.");
            Scene? scene4_5a = await GameBuilderAPI.CreateStandardScene("The visions hint at a presence in the cellar, a being trapped in a liminal space, bound by some ancient magic.");
            Scene? scene4_6a = await GameBuilderAPI.CreateStandardScene("The amulet has unlocked something, a connection to the house's mystical past, and perhaps a link to the entity below.");
            Scene? scene4_7a = await GameBuilderAPI.CreateStandardScene("As I make my way down the dark and narrow hallway, the amulet around my neck seems to hum, guiding me towards a hidden passage.");
            Scene? scene4_8a = await GameBuilderAPI.CreateStandardScene("The energy it emanates grows stronger, and I feel an unexplainable pull towards an old, dust-covered door, nearly concealed by heavy draperies.");
            Scene? scene4_9a = await GameBuilderAPI.CreateStandardScene("I reach out, feeling the cold metal of the door handle, and the amulet responds, glowing faintly, resonating with some unseen force.");
            Scene? scene4_10a = await GameBuilderAPI.CreateStandardScene("The door creaks open, revealing a steep staircase leading down into darkness.");
            Scene? scene4_11a = await GameBuilderAPI.CreateStandardScene("The amulet's glow illuminates the way, casting eerie shadows on the damp walls. The air grows cooler as I descend, each step echoing in the silence.");
            Scene? scene4_12a = await GameBuilderAPI.CreateStandardScene("A sense of anticipation, mingled with fear, settles in my stomach.");
            Scene? scene4_13a = await GameBuilderAPI.CreateStandardScene("What awaits me in the depths of this ancient house?");
            Scene? scene4_14a = await GameBuilderAPI.CreateStandardScene("The presence I felt in the vision, the haunting face, is down there, and the amulet is leading me to it.");
            Scene? scene4_15a = await GameBuilderAPI.CreateStandardScene("This amulet... there's something about it that calls to me. I lift it from its stand, and a chill runs down my spine. The room vibrates subtly.");
            Scene? scene4_16a = await GameBuilderAPI.CreateStandardScene("You have freed me.", specter);
            Scene? scene4_17a = await GameBuilderAPI.CreateStandardScene("What are you? What's happening?", adrian);
            Scene? scene4_18a = await GameBuilderAPI.CreateStandardScene("I am a being of another dimension, caught between worlds. You have the amulet; you have the power.", specter);

            await GameBuilderAPI.AddTransition(scene4_1a!, scene4_2a!);
            await GameBuilderAPI.AddTransition(scene4_2a!, scene4_3a!);
            await GameBuilderAPI.AddTransition(scene4_3a!, scene4_4a!);
            await GameBuilderAPI.AddTransition(scene4_4a!, scene4_5a!);
            await GameBuilderAPI.AddTransition(scene4_5a!, scene4_6a!);
            await GameBuilderAPI.AddTransition(scene4_6a!, scene4_7a!);
            await GameBuilderAPI.AddTransition(scene4_7a!, scene4_8a!);
            await GameBuilderAPI.AddTransition(scene4_8a!, scene4_9a!);
            await GameBuilderAPI.AddTransition(scene4_9a!, scene4_10a!);
            await GameBuilderAPI.AddTransition(scene4_10a!, scene4_11a!);
            await GameBuilderAPI.AddTransition(scene4_11a!, scene4_12a!);
            await GameBuilderAPI.AddTransition(scene4_12a!, scene4_13a!);
            await GameBuilderAPI.AddTransition(scene4_13a!, scene4_14a!);
            await GameBuilderAPI.AddTransition(scene4_14a!, scene4_15a!);
            await GameBuilderAPI.AddTransition(scene4_15a!, scene4_16a!);
            await GameBuilderAPI.AddTransition(scene4_16a!, scene4_17a!);
            await GameBuilderAPI.AddTransition(scene4_17a!, scene4_18a!);

            #region Ritual
            Scene? ritual_1 = await GameBuilderAPI.CreateStandardScene("Then let us begin. Focus on the amulet, feel its energy, connect with the mystical forces that flow through it. Allow me to guide you...", specter);
            Scene? ritual_2 = await GameBuilderAPI.CreateStandardScene("I feel a surge of energy, visions flashing before my eyes, voices from another world whispering in my ear.");
            Scene? ritual_3 = await GameBuilderAPI.CreateStandardScene("The Specter begins to utter ancient phrases in a language I've never heard, but somehow, I'm able to repeat them.");
            Scene? ritual_4 = await GameBuilderAPI.CreateStandardScene("The amulet vibrates, glowing with a pulsating light. I feel a pull from the depths of my soul, as if something primal and powerful is awakening within me.");
            Scene? ritual_5 = await GameBuilderAPI.CreateStandardScene("The gateway is opening. Don't falter; we're almost there.", specter);
            Scene? ritual_6 = await GameBuilderAPI.CreateStandardScene("The room shakes, the walls seemingly melting away, replaced by a swirling vortex of colors and shapes.");
            Scene? ritual_7 = await GameBuilderAPI.CreateStandardScene("I feel the Specter's energy intertwining with mine, a dance of power and understanding. My heart pounds, but I trust in the process, knowing that I'm part of something profound.");
            Scene? ritual_8 = await GameBuilderAPI.CreateStandardScene("The ritual is complete. I can feel my world, the freedom that awaits.", specter);

            await GameBuilderAPI.AddTransition(ritual_1!, ritual_2!);
            await GameBuilderAPI.AddTransition(ritual_2!, ritual_3!);
            await GameBuilderAPI.AddTransition(ritual_3!, ritual_4!);
            await GameBuilderAPI.AddTransition(ritual_4!, ritual_5!);
            await GameBuilderAPI.AddTransition(ritual_5!, ritual_6!);
            await GameBuilderAPI.AddTransition(ritual_6!, ritual_7!);
            await GameBuilderAPI.AddTransition(ritual_7!, ritual_8!);
            #endregion

            #region Ending1(Mysticism)

            Condition mysticismInterestHigh1 = await GameBuilderAPI.CreateStatePointsCondition(mysticismInterest, 2);
            Condition mysticismInterestHigh2 = await GameBuilderAPI.CreateStatePointsCondition(mysticismInterest, 2);

            Scene? scene4_15a_1a = await GameBuilderAPI.CreateStandardScene("Power? What do you mean?", adrian);

            await GameBuilderAPI.AddTransition(scene4_18a!, scene4_15a_1a!, mysticismInterestHigh1);

            Scene? scene4_15a_2a = await GameBuilderAPI.CreateStandardScene("The amulet you hold, it binds me but can also be the key. I can show you the way to realms you've never imagined, mysteries beyond comprehension", specter);
            Scene? scene4_15a_3a = await GameBuilderAPI.CreateStandardScene("But I must return to my world.", specter);
            Scene? scene4_15a_4a = await GameBuilderAPI.CreateStandardScene("How can I trust you?", adrian);
            Scene? scene4_15a_5a = await GameBuilderAPI.CreateStandardScene("Your hesitation is natural. The unknown is both a lure and a terror. But think of the knowledge you crave, the secrets of the universe that have eluded your kind. I can guide you there.", specter);
            Scene? scene4_15a_6a = await GameBuilderAPI.CreateStandardScene("I feel a growing connection to the amulet, a sensation of power and curiosity.");
            Scene? scene4_15a_7a = await GameBuilderAPI.CreateStandardScene("What do you need from me? How can I help you return to your world?", adrian);
            Scene? scene4_15a_8a = await GameBuilderAPI.CreateStandardScene("A ritual must be performed, one that requires both the amulet's energy and a willing participant. You have the mystical inclination; you can be the conduit.", specter);
            Scene? scene4_15a_9a = await GameBuilderAPI.CreateStandardScene("A ritual? Is it safe?", adrian);
            Scene? scene4_15a_10a = await GameBuilderAPI.CreateStandardScene("There are always risks with the arcane. But the rewards... they are unlike anything you've ever experienced. You must decide if the pursuit of knowledge outweighs the danger.", specter);
            Scene? scene4_15a_11a = await GameBuilderAPI.CreateStandardScene("I ponder the opportunity, the risks, the sheer enormity of what's being offered, the amulet's warmth in my hand.");
            Scene? scene4_15a_12a = await GameBuilderAPI.CreateStandardScene("I'll do it.", adrian);
            Scene? scene4_15a_13a = await GameBuilderAPI.CreateStandardScene("Show me the way, and I will help you return home.", adrian);
            Scene? scene4_15a_14a = await GameBuilderAPI.CreateStandardScene("Wise and brave. Prepare yourself, human. The path you tread will challenge your very understanding of reality.", specter);
            Scene? scene4_15a_15a = await GameBuilderAPI.CreateStandardScene("I'm ready.", adrian);

            //Ritual...

            Scene? scene4_15a_16a = await GameBuilderAPI.CreateStandardScene("Thank you, human. You have done what few could. As a token of gratitude, I leave you with a glimpse of the wisdom you seek.", specter);
            Scene? scene4_15a_17a = await GameBuilderAPI.CreateStandardScene("As the ritual reaches its climax, a rush of knowledge floods my senses, focusing on the ability to bridge the gap between different planes of existence. The complexity of the information is overwhelming, yet somehow it feels natural, like a piece of a puzzle that's finally found its place.");
            Scene? scene4_15a_18a = await GameBuilderAPI.CreateStandardScene("The wisdom of interdimensional travel, once hidden and beyond reach, now lays open before me, a path to new dimensions and further exploration of the mystical arts.");
            Scene? scene4_15a_19a = await GameBuilderAPI.CreateStandardScene("The room returns to normal, the Specter's presence fading, but the knowledge remains, imprinted in my very soul.");
            Scene? scene4_15a_20a = await GameBuilderAPI.CreateStandardScene("I'm left standing, the amulet now quiet, a lingering sensation of connection still in the air. The house feels different, as if a door to new realms has been unlocked.");
            Scene? scene4_15a_21a = await GameBuilderAPI.CreateStandardScene("A burden has indeed been lifted, but in its place, an exhilarating challenge beckons. I know that I've been changed too, granted the knowledge to traverse the very fabric of existence.");
            Scene? scene4_15a_22a = await GameBuilderAPI.CreateStandardScene("The path to other dimensions has opened before me, and I'm eager, yet humbled, to explore it further. The specter's world, once a distant mystery, now feels within reach.");

            Transition t = await GameBuilderAPI.AddTransition(scene4_15a_1a!, scene4_15a_2a!);
            await GameBuilderAPI.AddTransition(scene4_15a_2a!, scene4_15a_3a!);
            await GameBuilderAPI.AddTransition(scene4_15a_3a!, scene4_15a_4a!);
            await GameBuilderAPI.AddTransition(scene4_15a_4a!, scene4_15a_5a!);
            await GameBuilderAPI.AddTransition(scene4_15a_5a!, scene4_15a_6a!);
            await GameBuilderAPI.AddTransition(scene4_15a_6a!, scene4_15a_7a!);
            await GameBuilderAPI.AddTransition(scene4_15a_7a!, scene4_15a_8a!);
            await GameBuilderAPI.AddTransition(scene4_15a_8a!, scene4_15a_9a!);
            await GameBuilderAPI.AddTransition(scene4_15a_9a!, scene4_15a_10a!);
            await GameBuilderAPI.AddTransition(scene4_15a_10a!, scene4_15a_11a!);
            await GameBuilderAPI.AddTransition(scene4_15a_11a!, scene4_15a_12a!);
            await GameBuilderAPI.AddTransition(scene4_15a_12a!, scene4_15a_13a!);
            await GameBuilderAPI.AddTransition(scene4_15a_13a!, scene4_15a_14a!);
            await GameBuilderAPI.AddTransition(scene4_15a_14a!, scene4_15a_15a!);
            await GameBuilderAPI.AddTransition(scene4_15a_15a!, ritual_1!);
            await GameBuilderAPI.AddTransition(ritual_8!, scene4_15a_16a!, mysticismInterestHigh2);
            await GameBuilderAPI.AddTransition(scene4_15a_16a!, scene4_15a_17a!);
            await GameBuilderAPI.AddTransition(scene4_15a_17a!, scene4_15a_18a!);
            await GameBuilderAPI.AddTransition(scene4_15a_18a!, scene4_15a_19a!);
            await GameBuilderAPI.AddTransition(scene4_15a_19a!, scene4_15a_20a!);
            await GameBuilderAPI.AddTransition(scene4_15a_20a!, scene4_15a_21a!);
            await GameBuilderAPI.AddTransition(scene4_15a_21a!, scene4_15a_22a!);

            #endregion

            #region Ending2(People)

            Condition peopleInterestHigh1 = await GameBuilderAPI.CreateStatePointsCondition(peopleInterest, 2);
            Condition peopleInterestHigh2 = await GameBuilderAPI.CreateStatePointsCondition(peopleInterest, 2);

            Scene? scene4_15a_1b = await GameBuilderAPI.CreateStandardScene("Why did the owners of the house lock you in this basement?", adrian);

            await GameBuilderAPI.AddTransition(scene4_18a!, scene4_15a_1b!, peopleInterestHigh1);

            Scene? scene4_15a_2b = await GameBuilderAPI.CreateStandardScene("When I first arrived in your world, I was trapped in this cellar out of fear and misunderstanding. I'm not a monster; I'm a being from another dimension.", specter);
            Scene? scene4_15a_3b = await GameBuilderAPI.CreateStandardScene("I long to return to my family, my friends... a life I left behind.", specter);
            Scene? scene4_15a_4b = await GameBuilderAPI.CreateStandardScene("I hear the pain in your voice. I'll help you return home.", adrian);
            Scene? scene4_15a_5b = await GameBuilderAPI.CreateStandardScene("Your compassion is rare, and I'm deeply grateful. Let's perform the ritual to send me home.", specter);
            Scene? scene4_15a_6b = await GameBuilderAPI.CreateStandardScene("And know this, Adrian, once there, you'll have a chance to see my family, to understand why returning home means so much to me.", specter);
            Scene? scene4_15a_7b = await GameBuilderAPI.CreateStandardScene("That's an incredible offer. I want to see your world.", adrian);

            //Ritual...

            Scene? scene4_15a_8b = await GameBuilderAPI.CreateStandardScene("The portal is open. Come, and let me introduce you to my family.", specter);
            Scene? scene4_15a_9b = await GameBuilderAPI.CreateStandardScene("I follow the Specter, stepping through the portal.");
            Scene? scene4_15a_10b = await GameBuilderAPI.CreateStandardScene("A sensation of weightlessness overcomes me as if I'm floating between dimensions. An electric thrill tingles through my veins as I enter the unknown, guided by a being I've only just met but feel a profound connection to.");
            Scene? scene4_15a_11b = await GameBuilderAPI.CreateStandardScene("I find myself in a place that defies all logic and understanding.");
            Scene? scene4_15a_12b = await GameBuilderAPI.CreateStandardScene("The sky above me shifts and dances in colors I've never seen before, forming patterns that mesmerize and enchant.");
            Scene? scene4_15a_13b = await GameBuilderAPI.CreateStandardScene("Islands float in mid-air, and waterfalls defy gravity, flowing upwards to join clouds that shimmer with inner light.");
            Scene? scene4_15a_14b = await GameBuilderAPI.CreateStandardScene("The plants around me glow with a gentle luminescence, swaying as if to a melody I can almost hear but not quite grasp.");
            Scene? scene4_15a_15b = await GameBuilderAPI.CreateStandardScene("Their world is both alien and familiar, and I feel a sense of belonging that both astonishes and humbles me.");
            Scene? scene4_15a_16b = await GameBuilderAPI.CreateStandardScene("I sense a presence, and turning, I see them — the Specter's family.");
            Scene? scene4_15a_17b = await GameBuilderAPI.CreateStandardScene("They are beings of light, their forms translucent and shimmering, their eyes filled with a wisdom that seems to span eons.");
            Scene? scene4_15a_18b = await GameBuilderAPI.CreateStandardScene("Thank you, kind soul, for bringing our child back to us. We feared the worst when he became trapped in your world.", specterMother);
            Scene? scene4_15a_19b = await GameBuilderAPI.CreateStandardScene("I only did what felt right.", adrian);
            Scene? scene4_15a_20b = await GameBuilderAPI.CreateStandardScene("Your compassion has bridged the gap between our worlds. Please, let us show you our gratitude. Walk with us, experience our home.", specterFather);
            Scene? scene4_15a_21b = await GameBuilderAPI.CreateStandardScene("I walk through landscapes that defy earthly logic, with floating gardens, crystalline structures, and harmonious melodies that seem to come from the very fabric of the world itself.");
            Scene? scene4_15a_22b = await GameBuilderAPI.CreateStandardScene("You see, our world is built on connections, love, and empathy. Your actions today have resonated with our very essence. We will remember you always.", specterMother);
            Scene? scene4_15a_23b = await GameBuilderAPI.CreateStandardScene("I'm honored to have been a part of this. Your world is beautiful, and the love you share is something I'll carry with me.", adrian);
            Scene? scene4_15a_24b = await GameBuilderAPI.CreateStandardScene("We must part now, but know that our gratitude is boundless. May the love and wisdom of our world inspire you in your own.", specterFather);
            Scene? scene4_15a_25b = await GameBuilderAPI.CreateStandardScene("Thank you for allowing me to witness this. Farewell.", adrian);
            Scene? scene4_15a_26b = await GameBuilderAPI.CreateStandardScene("I step through the portal, feeling a gentle tug as the otherworldly landscape fades from view. A moment of disorientation, and then I'm back in the cellar of the old house.");
            Scene? scene4_15a_27b = await GameBuilderAPI.CreateStandardScene("The air feels heavy, mundane, and the colors of my world seem duller somehow.");
            Scene? scene4_15a_28b = await GameBuilderAPI.CreateStandardScene("I'm left standing in the silence of the cellar, the amulet lying quiet in my hand. The house feels different, as if an old wound has healed.");
            Scene? scene4_15a_29b = await GameBuilderAPI.CreateStandardScene("The lingering sensation of connection still tingles in the air, but it's fading, leaving behind a profound sense of contentment and understanding.");
            Scene? scene4_15a_30b = await GameBuilderAPI.CreateStandardScene("I know that I've been changed, that I've experienced something extraordinary and unique.");
            Scene? scene4_15a_31b = await GameBuilderAPI.CreateStandardScene("I've touched another world, connected with beings of pure light and wisdom, and helped reunite a family separated by dimensions.");
            Scene? scene4_15a_32b = await GameBuilderAPI.CreateStandardScene("The path of empathy and understanding has opened before me, and I feel a new calling, a new purpose.");

            await GameBuilderAPI.AddTransition(scene4_15a_1b!, scene4_15a_2b!);
            await GameBuilderAPI.AddTransition(scene4_15a_2b!, scene4_15a_3b!);
            await GameBuilderAPI.AddTransition(scene4_15a_3b!, scene4_15a_4b!);
            await GameBuilderAPI.AddTransition(scene4_15a_4b!, scene4_15a_5b!);
            await GameBuilderAPI.AddTransition(scene4_15a_5b!, scene4_15a_6b!);
            await GameBuilderAPI.AddTransition(scene4_15a_6b!, scene4_15a_7b!);
            await GameBuilderAPI.AddTransition(scene4_15a_7b!, ritual_1!);
            await GameBuilderAPI.AddTransition(ritual_8!, scene4_15a_8b!, peopleInterestHigh2);
            await GameBuilderAPI.AddTransition(scene4_15a_8b!, scene4_15a_9b!);
            await GameBuilderAPI.AddTransition(scene4_15a_9b!, scene4_15a_10b!);
            await GameBuilderAPI.AddTransition(scene4_15a_10b!, scene4_15a_11b!);
            await GameBuilderAPI.AddTransition(scene4_15a_11b!, scene4_15a_12b!);
            await GameBuilderAPI.AddTransition(scene4_15a_12b!, scene4_15a_13b!);
            await GameBuilderAPI.AddTransition(scene4_15a_13b!, scene4_15a_14b!);
            await GameBuilderAPI.AddTransition(scene4_15a_14b!, scene4_15a_15b!);
            await GameBuilderAPI.AddTransition(scene4_15a_15b!, scene4_15a_16b!);
            await GameBuilderAPI.AddTransition(scene4_15a_16b!, scene4_15a_17b!);
            await GameBuilderAPI.AddTransition(scene4_15a_17b!, scene4_15a_18b!);
            await GameBuilderAPI.AddTransition(scene4_15a_18b!, scene4_15a_19b!);
            await GameBuilderAPI.AddTransition(scene4_15a_19b!, scene4_15a_20b!);
            await GameBuilderAPI.AddTransition(scene4_15a_20b!, scene4_15a_21b!);
            await GameBuilderAPI.AddTransition(scene4_15a_21b!, scene4_15a_22b!);
            await GameBuilderAPI.AddTransition(scene4_15a_22b!, scene4_15a_23b!);
            await GameBuilderAPI.AddTransition(scene4_15a_23b!, scene4_15a_24b!);
            await GameBuilderAPI.AddTransition(scene4_15a_24b!, scene4_15a_25b!);
            await GameBuilderAPI.AddTransition(scene4_15a_25b!, scene4_15a_26b!);
            await GameBuilderAPI.AddTransition(scene4_15a_26b!, scene4_15a_27b!);
            await GameBuilderAPI.AddTransition(scene4_15a_27b!, scene4_15a_28b!);
            await GameBuilderAPI.AddTransition(scene4_15a_28b!, scene4_15a_29b!);
            await GameBuilderAPI.AddTransition(scene4_15a_29b!, scene4_15a_30b!);
            await GameBuilderAPI.AddTransition(scene4_15a_30b!, scene4_15a_31b!);
            await GameBuilderAPI.AddTransition(scene4_15a_31b!, scene4_15a_32b!);

            #endregion

            #endregion

            #region Letter
            
            Condition choiceScene3_conditionB = await GameBuilderAPI.CreateMadeChoicesCondition(choiceScene3_choice_2);

            Scene? scene4_1b = await GameBuilderAPI.CreateStandardScene("I choose the letter, guided by reason and curiosity. It may not hold the magic of the amulet, but it promises answers and understanding. I carefully break the seal, feeling a connection to the past and the secrets it holds.");
            
            await GameBuilderAPI.AddTransition(choiceScene3!, scene4_1b!, choiceScene3_conditionB);

            Scene? scene4_2b = await GameBuilderAPI.CreateStandardScene("\"Dearest Margaret,\r\n");
            Scene? scene4_3b = await GameBuilderAPI.CreateStandardScene("The rituals were a mistake. We've tapped into something we cannot control. It haunts the cellar now, a specter caught between worlds, bound by the very magic we sought to wield.");
            Scene? scene4_4b = await GameBuilderAPI.CreateStandardScene("I've contained it for now, using the amulet, but I fear what might happen if it's released. The house is no longer safe. I urge you to leave, to find refuge elsewhere, but leave the amulet; it must never be removed.");
            Scene? scene4_5b = await GameBuilderAPI.CreateStandardScene("Forgive me for what I've done. I only sought to protect us, to harness a power that could ensure our future. But I was wrong. I hope you can find it in your heart to forgive me.");
            Scene? scene4_6b = await GameBuilderAPI.CreateStandardScene("Yours always,\r\nEdward\"");
            Scene? scene4_7b = await GameBuilderAPI.CreateStandardScene("The letter falls from my hand as I finish reading, the words echoing in my mind. The house's secrets are laid bare, and the weight of what I've uncovered settles heavily upon me.");
            Scene? scene4_8b = await GameBuilderAPI.CreateStandardScene("There's a specter in the cellar, trapped by an amulet I've left on the table. A chill runs down my spine.");
            Scene? scene4_9b = await GameBuilderAPI.CreateStandardScene("A specter? An amulet? The fear rose within me.");
            Scene? scene4_10b = await GameBuilderAPI.CreateStandardScene("Panic set in, and I couldn't stay in the house any longer. I needed to get out, to escape this nightmare.");
            Scene? scene4_11b = await GameBuilderAPI.CreateStandardScene("The fear was overwhelming as I burst out of the house, gasping for air. The words of Edward's letter played over and over in my mind. ");
            Scene? scene4_12b = await GameBuilderAPI.CreateStandardScene("The old man was waiting for me, and I ran to him, my body shaking with terror.");
            Scene? scene4_13b = await GameBuilderAPI.CreateStandardScene("I found a letter!", adrian);
            Scene? scene4_14b = await GameBuilderAPI.CreateStandardScene("I stammered, explaining about the specter, the amulet, and the horror in the cellar.");

            await GameBuilderAPI.AddTransition(scene4_1b!, scene4_2b!);
            await GameBuilderAPI.AddTransition(scene4_2b!, scene4_3b!);
            await GameBuilderAPI.AddTransition(scene4_3b!, scene4_4b!);
            await GameBuilderAPI.AddTransition(scene4_4b!, scene4_5b!);
            await GameBuilderAPI.AddTransition(scene4_5b!, scene4_6b!);
            await GameBuilderAPI.AddTransition(scene4_6b!, scene4_7b!);
            await GameBuilderAPI.AddTransition(scene4_7b!, scene4_8b!);
            await GameBuilderAPI.AddTransition(scene4_8b!, scene4_9b!);
            await GameBuilderAPI.AddTransition(scene4_9b!, scene4_10b!);
            await GameBuilderAPI.AddTransition(scene4_10b!, scene4_11b!);
            await GameBuilderAPI.AddTransition(scene4_11b!, scene4_12b!);
            await GameBuilderAPI.AddTransition(scene4_12b!, scene4_13b!);
            await GameBuilderAPI.AddTransition(scene4_13b!, scene4_14b!);

            #region Ending3(Mysticism)
            Scene? scene4_15b_1a = await GameBuilderAPI.CreateStandardScene("I had to leave; it's too dangerous!", adrian);

            Condition highMysticismInterestState = await GameBuilderAPI.CreateStatePointsCondition(mysticismInterest, 2);

            await GameBuilderAPI.AddTransition(scene4_14b, scene4_15b_1a, highMysticismInterestState);


            Scene? scene4_15b_2a = await GameBuilderAPI.CreateStandardScene("The old man listened, his disappointment turning to clear concern.");
            Scene? scene4_15b_3a = await GameBuilderAPI.CreateStandardScene("The more I told him, the more his eyes widened with apprehension.");
            Scene? scene4_15b_4a = await GameBuilderAPI.CreateStandardScene("He understood that I knew too much. That I might tell others about the house and its secrets.");
            Scene? scene4_15b_5a = await GameBuilderAPI.CreateStandardScene("His face hardened, and his voice grew stern.");
            Scene? scene4_15b_6a = await GameBuilderAPI.CreateStandardScene("We are now bound by this secret, Adrian.", oldMan);
            Scene? scene4_15b_7a = await GameBuilderAPI.CreateStandardScene("Something in his eyes, in his voice, sent chills down my spine. My fear intensified, and I began to realize that something was very wrong.");
            Scene? scene4_15b_8a = await GameBuilderAPI.CreateStandardScene("The old man reached out his hand, and ancient words spilled from his lips, echoing in the air around us.");
            Scene? scene4_15b_9a = await GameBuilderAPI.CreateStandardScene("I felt my body becoming transparent, weightless, and I knew what was happening.");
            Scene? scene4_15b_10a = await GameBuilderAPI.CreateStandardScene("I screamed, tried to run, but my new spectral body was tied to the house, and I couldn't leave.");
            Scene? scene4_15b_11a = await GameBuilderAPI.CreateStandardScene("It was necessary.", oldMan);
            Scene? scene4_15b_12a = await GameBuilderAPI.CreateStandardScene("His voice filled with a strange mixture of understanding and sorrow.");
            Scene? scene4_15b_13a = await GameBuilderAPI.CreateStandardScene("You must become part of this place, a guardian.", oldMan);
            Scene? scene4_15b_14a = await GameBuilderAPI.CreateStandardScene("I was pulled into the cellar, where I was met by another specter, one that had once been the guardian of the house, just like me now.");
            Scene? scene4_15b_15a = await GameBuilderAPI.CreateStandardScene("Welcome.", specter);
            Scene? scene4_15b_16a = await GameBuilderAPI.CreateStandardScene("It whispered, its voice filled with the loneliness of eternity.");
            Scene? scene4_15b_17a = await GameBuilderAPI.CreateStandardScene("We are bound to this place, forever.", specter);
            Scene? scene4_15b_18a = await GameBuilderAPI.CreateStandardScene("I was left with the other specter, a prisoner of the house, a guardian of its secrets.");
            Scene? scene4_15b_19a = await GameBuilderAPI.CreateStandardScene("The reality of my new existence settled in, a haunting reminder of the choices I had made and the price I had paid.");
            Scene? scene4_15b_20a = await GameBuilderAPI.CreateStandardScene("The house was safe, its secrets protected, but I was trapped, a ghost caught between worlds, forever bound to the mysteries of the past.");

            await GameBuilderAPI.AddTransition(scene4_15b_1a!, scene4_15b_2a!);
            await GameBuilderAPI.AddTransition(scene4_15b_2a!, scene4_15b_3a!);
            await GameBuilderAPI.AddTransition(scene4_15b_3a!, scene4_15b_4a!);
            await GameBuilderAPI.AddTransition(scene4_15b_4a!, scene4_15b_5a!);
            await GameBuilderAPI.AddTransition(scene4_15b_5a!, scene4_15b_6a!);
            await GameBuilderAPI.AddTransition(scene4_15b_6a!, scene4_15b_7a!);
            await GameBuilderAPI.AddTransition(scene4_15b_7a!, scene4_15b_8a!);
            await GameBuilderAPI.AddTransition(scene4_15b_8a!, scene4_15b_9a!);
            await GameBuilderAPI.AddTransition(scene4_15b_9a!, scene4_15b_10a!);
            await GameBuilderAPI.AddTransition(scene4_15b_10a!, scene4_15b_11a!);
            await GameBuilderAPI.AddTransition(scene4_15b_11a!, scene4_15b_12a!);
            await GameBuilderAPI.AddTransition(scene4_15b_12a!, scene4_15b_13a!);
            await GameBuilderAPI.AddTransition(scene4_15b_13a!, scene4_15b_14a!);
            await GameBuilderAPI.AddTransition(scene4_15b_14a!, scene4_15b_15a!);
            await GameBuilderAPI.AddTransition(scene4_15b_15a!, scene4_15b_16a!);
            await GameBuilderAPI.AddTransition(scene4_15b_16a!, scene4_15b_17a!);
            await GameBuilderAPI.AddTransition(scene4_15b_17a!, scene4_15b_18a!);
            await GameBuilderAPI.AddTransition(scene4_15b_18a!, scene4_15b_19a!);
            await GameBuilderAPI.AddTransition(scene4_15b_19a!, scene4_15b_20a!);

            #endregion


            #region Ending4(People)
            Scene? scene4_15b_1b = await GameBuilderAPI.CreateStandardScene("Who are you? Why are you helping me?", adrian);

            Condition highPeopleInterestState = await GameBuilderAPI.CreateStatePointsCondition(peopleInterest, 2);

            await GameBuilderAPI.AddTransition(scene4_14b, scene4_15b_1b, highPeopleInterestState);


            Scene? scene4_15b_2b = await GameBuilderAPI.CreateStandardScene("I have been waiting for someone who might understand this place and its mysteries.", oldMan);
            Scene? scene4_15b_3b = await GameBuilderAPI.CreateStandardScene("What do you mean? I am just a programmer, and this house caught my attention. How are you connected to it?", adrian);
            Scene? scene4_15b_4b = await GameBuilderAPI.CreateStandardScene("Old man sighs deeply.");
            Scene? scene4_15b_5b = await GameBuilderAPI.CreateStandardScene("The story is long and tragic.", oldMan);
            Scene? scene4_15b_6b = await GameBuilderAPI.CreateStandardScene("My friend Edward and I were fascinated by the idea of using the energy of another world to cure human diseases.", oldMan);
            Scene? scene4_15b_7b = await GameBuilderAPI.CreateStandardScene("Edward's wife was struggling with an incurable illness, and we sought to find a solution.", oldMan);
            Scene? scene4_15b_8b = await GameBuilderAPI.CreateStandardScene("You speak of healing through mysticism? Is that really possible?", adrian);
            Scene? scene4_15b_9b = await GameBuilderAPI.CreateStandardScene("Yes, but our path was fraught with mistakes and suffering. One of our rituals got out of control, and now this house is bound to a ghost that we summoned.", oldMan);
            Scene? scene4_15b_10b = await GameBuilderAPI.CreateStandardScene("What happened to Edward and his wife?", adrian);
            Scene? scene4_15b_11b = await GameBuilderAPI.CreateStandardScene("Margaret died because she could not suffer any longer. Edward went into exile, full of guilt and despair. I remained here, living with the guilt that I couldn't stop him.", oldMan);
            Scene? scene4_15b_12b = await GameBuilderAPI.CreateStandardScene("I have been looking for someone who might help me correct the mistake and possibly use our discoveries for the good of humanity.", oldMan);
            Scene? scene4_15b_13b = await GameBuilderAPI.CreateStandardScene("I'm willing to try to help.", adrian);
            Scene? scene4_15b_14b = await GameBuilderAPI.CreateStandardScene("Thank you, my friend.", oldMan);
            Scene? scene4_15b_15b = await GameBuilderAPI.CreateStandardScene("I feel that together we can accomplish something great.", oldMan);
            Scene? scene4_15b_16b = await GameBuilderAPI.CreateStandardScene("We enter the house together. The Old Man leads me through dimly lit corridors, filled with relics of past mystic experiments, until we reach a hidden door.");
            Scene? scene4_15b_17b = await GameBuilderAPI.CreateStandardScene("Behind it lies the laboratory where he and Edward once worked.");
            Scene? scene4_15b_18b = await GameBuilderAPI.CreateStandardScene("This place is amazing! What were you working on?", adrian);
            Scene? scene4_15b_19b = await GameBuilderAPI.CreateStandardScene("We were trying to contact other realms, seeking to understand them, and utilize their energy for healing. This mechanism was our creation.", oldMan);
            Scene? scene4_15b_20b = await GameBuilderAPI.CreateStandardScene("Old man points to a complex device combining mystical symbols with modern technology.");
            Scene? scene4_15b_21b = await GameBuilderAPI.CreateStandardScene("How does it work?", adrian);
            Scene? scene4_15b_22b = await GameBuilderAPI.CreateStandardScene("It creates a stable channel with the other world. But we lost control, and the specter fell into our world, so we trapped him in the basement.", oldMan);
            Scene? scene4_15b_23b = await GameBuilderAPI.CreateStandardScene("We need to understand it, find a way to harness its energy.", oldMan);
            Scene? scene4_15b_24b = await GameBuilderAPI.CreateStandardScene("Days passed as we immersed in research and experimentation.");
            Scene? scene4_15b_25b = await GameBuilderAPI.CreateStandardScene("We pore over Edward's old journals, recreated experiments, and made adjustments to the mechanism.");
            Scene? scene4_15b_26b = await GameBuilderAPI.CreateStandardScene("Finally, after endless trial and error, they initiate the mechanism.");
            Scene? scene4_15b_27b = await GameBuilderAPI.CreateStandardScene("A hum fills the air as the device powers up, and we watch in awe as it establishes a connection with the other world.");
            Scene? scene4_15b_28b = await GameBuilderAPI.CreateStandardScene("I can see tears in old man's eyes.");
            Scene? scene4_15b_29b = await GameBuilderAPI.CreateStandardScene("We've done it, Adrian! We've reestablished the link.", oldMan);
            Scene? scene4_15b_30b = await GameBuilderAPI.CreateStandardScene("And the specter's energy... It can be harnessed! Transformed into something we can use!", adrian);
            Scene? scene4_15b_31b = await GameBuilderAPI.CreateStandardScene("It's a limitless source. We must ensure it's used responsibly.", oldMan);
            Scene? scene4_15b_32b = await GameBuilderAPI.CreateStandardScene("Months later, we have not only understood the specter but have also developed a way to safely convert its energy. We know we have discovered something that could change the world.");
            Scene? scene4_15b_33b = await GameBuilderAPI.CreateStandardScene("The house, once a place of tragedy, has become a symbol of hope. The guilt that burdened the Old Man has been lifted, replaced with pride and fulfillment.");
            Scene? scene4_15b_34b = await GameBuilderAPI.CreateStandardScene("We vow to continue our work together, knowing that they we only just begun to unlock the mysteries of the other world, driven by a shared vision of healing and endless possibility.");

            await GameBuilderAPI.AddTransition(scene4_15b_1b!, scene4_15b_2b!);
            await GameBuilderAPI.AddTransition(scene4_15b_2b!, scene4_15b_3b!);
            await GameBuilderAPI.AddTransition(scene4_15b_3b!, scene4_15b_4b!);
            await GameBuilderAPI.AddTransition(scene4_15b_4b!, scene4_15b_5b!);
            await GameBuilderAPI.AddTransition(scene4_15b_5b!, scene4_15b_6b!);
            await GameBuilderAPI.AddTransition(scene4_15b_6b!, scene4_15b_7b!);
            await GameBuilderAPI.AddTransition(scene4_15b_7b!, scene4_15b_8b!);
            await GameBuilderAPI.AddTransition(scene4_15b_8b!, scene4_15b_9b!);
            await GameBuilderAPI.AddTransition(scene4_15b_9b!, scene4_15b_10b!);
            await GameBuilderAPI.AddTransition(scene4_15b_10b!, scene4_15b_11b!);
            await GameBuilderAPI.AddTransition(scene4_15b_11b!, scene4_15b_12b!);
            await GameBuilderAPI.AddTransition(scene4_15b_12b!, scene4_15b_13b!);
            await GameBuilderAPI.AddTransition(scene4_15b_13b!, scene4_15b_14b!);
            await GameBuilderAPI.AddTransition(scene4_15b_14b!, scene4_15b_15b!);
            await GameBuilderAPI.AddTransition(scene4_15b_15b!, scene4_15b_16b!);
            await GameBuilderAPI.AddTransition(scene4_15b_16b!, scene4_15b_17b!);
            await GameBuilderAPI.AddTransition(scene4_15b_17b!, scene4_15b_18b!);
            await GameBuilderAPI.AddTransition(scene4_15b_18b!, scene4_15b_19b!);
            await GameBuilderAPI.AddTransition(scene4_15b_19b!, scene4_15b_20b!);
            await GameBuilderAPI.AddTransition(scene4_15b_20b!, scene4_15b_21b!);
            await GameBuilderAPI.AddTransition(scene4_15b_21b!, scene4_15b_22b!);
            await GameBuilderAPI.AddTransition(scene4_15b_22b!, scene4_15b_23b!);
            await GameBuilderAPI.AddTransition(scene4_15b_23b!, scene4_15b_24b!);
            await GameBuilderAPI.AddTransition(scene4_15b_24b!, scene4_15b_25b!);
            await GameBuilderAPI.AddTransition(scene4_15b_25b!, scene4_15b_26b!);
            await GameBuilderAPI.AddTransition(scene4_15b_26b!, scene4_15b_27b!);
            await GameBuilderAPI.AddTransition(scene4_15b_27b!, scene4_15b_28b!);
            await GameBuilderAPI.AddTransition(scene4_15b_28b!, scene4_15b_29b!);
            await GameBuilderAPI.AddTransition(scene4_15b_29b!, scene4_15b_30b!);
            await GameBuilderAPI.AddTransition(scene4_15b_30b!, scene4_15b_31b!);
            await GameBuilderAPI.AddTransition(scene4_15b_31b!, scene4_15b_32b!);
            await GameBuilderAPI.AddTransition(scene4_15b_32b!, scene4_15b_33b!);
            await GameBuilderAPI.AddTransition(scene4_15b_33b!, scene4_15b_34b!);
            
            #endregion

            #endregion
        }

    }
}