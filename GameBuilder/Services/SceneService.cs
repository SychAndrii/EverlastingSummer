using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilder.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public async Task<Scene?> AddScene(Scene scene)
        {
            using ESContext eSContext = new ESContext();
            try
            {
                eSContext.Scenes.Add(scene);

                // Ensure the Dialogue of the scene is not considered as a new entity.
                AvoidPossibleCharacterAddition(scene, eSContext);

                await eSContext.SaveChangesAsync();
                return scene;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Scene?> AddTransition(Scene modifiedScene, Transition transition)
        {
            using ESContext context = new ESContext();

            try
            {
                context.Scenes.Attach(modifiedScene);
                context.Scenes.Attach(transition.TargetScene);

                var tempTarget = DeepCopyHelper.DeepCopy(transition.TargetScene);

                // Load dependencies after setting the state
                await LoadSceneDependencies(context, modifiedScene);
                await LoadSceneDependencies(context, transition.TargetScene);

                // Add transition to modifiedScene.Transitions
                if (modifiedScene.Transitions == null)
                {
                    modifiedScene.Transitions = new List<Transition>();
                }
                modifiedScene.Transitions.Add(transition);
                await context.SaveChangesAsync();

                context.Entry(modifiedScene).State = EntityState.Detached;

                transition.TargetScene = tempTarget;

                AvoidPossibleCharacterAddition(transition.TargetScene, context);
                AvoidPossibleDialogueAddition(transition.TargetScene, context);

                await context.SaveChangesAsync();

                return modifiedScene;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void AvoidPossibleDialogueAddition(Scene scene, ESContext context)
        {
            if (scene is StandardScene standardScene && standardScene.Dialogue.Character != null)
            {
                context.Entry(standardScene.Dialogue).State = EntityState.Unchanged;
            }
        }

        private void AvoidPossibleCharacterAddition(Scene scene, ESContext context)
        {
            if (scene is StandardScene standardScene && standardScene.Dialogue.Character != null)
            {
                context.Entry(standardScene.Dialogue.Character).State = EntityState.Unchanged;
            }
        }

        private async Task LoadSceneDependencies(ESContext context, Scene scene)
        {
            if(scene is StandardScene standardScene)
            {
                await context.Entry(standardScene).Reference(s => s.Dialogue).LoadAsync();
                await context.Entry(standardScene.Dialogue).Reference(d => d.Character).LoadAsync();
            }
            else if(scene is ChoiceScene)
            {

            }
        }
    }
}
