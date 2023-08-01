using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleTesting.Services
{
    public class SceneService
    {
        private static SceneService _Instance;
        public static SceneService Instance 
        { 
            get
            {
                if(_Instance == null)
                    _Instance = new SceneService();
                return _Instance;
            }
        }
        private SceneService() { }

        /*
         * public static async Task<Dialogue?> AddDialogue(Dialogue dialogue)
        {
            using ESContext eSContext = new ESContext();

            try
            {
                var res = await eSContext.Dialogues.AddAsync(dialogue);
                await eSContext.SaveChangesAsync();
                return dialogue;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return null;
            }
        }
         */

        public async Task<Scene?> AddScene(Scene scene)
        {
            using ESContext eSContext = new ESContext();
            try
            {
                eSContext.Scenes.Add(scene);

                // Ensure the Dialogue of the scene is not considered as a new entity.
                if (scene is StandardScene standardScene && standardScene.Dialogue.Character != null)
                {
                    eSContext.Entry(standardScene.Dialogue.Character).State = EntityState.Unchanged;
                }

                await eSContext.SaveChangesAsync();
                return scene;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SwitchableScene?> AddTransition(SwitchableScene modifiedScene, Transition transition)
        {
            using ESContext eSContext = new ESContext();

            try
            {
                var dbModifiedScene = await eSContext.SwitchableScenes
                    .FirstOrDefaultAsync(s => s.Id == modifiedScene.Id);
                var dbTargetScene = await eSContext.Scenes
                    .FirstOrDefaultAsync(s => s.Id == transition.TargetScene.Id);

                transition.TargetScene = dbTargetScene;

                eSContext.Transitions.Add(transition);
                var updatedTransitions = dbModifiedScene.Transitions?.ToList() ?? new List<Transition>();
                updatedTransitions.Add(transition);
                dbModifiedScene.Transitions = updatedTransitions;

                await eSContext.SaveChangesAsync();
                return dbModifiedScene;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
