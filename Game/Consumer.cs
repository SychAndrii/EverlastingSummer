using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using GameConsumer.Models;
using GameConsumer.Visitors;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VisualNovelModels.Visitors;
using static System.Formats.Asn1.AsnWriter;

namespace GameBuilder
{
    // TODO: Write docs for everything.
    public class Consumer
    {
        public static void Main(string[] args)
        {
            Scene? currentScene = SceneModel.GetFirstScene().Result;
            ISceneVisitor invokeViewVisitor = new InvokeViewVisitor();

            while(currentScene != null)
            {
                currentScene.AcceptVisitor(invokeViewVisitor);
                Transition? transitionToNextScene = currentScene?.GetPossibleTransition(UserModel.CurrentUser);
                currentScene = transitionToNextScene?.TargetScene;
            }
        }
    }
}