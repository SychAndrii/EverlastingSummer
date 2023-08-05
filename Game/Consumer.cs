using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
using GameConsumer.Models;
using GameConsumer.Visitors;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VisualNovelModels.Visitors;

namespace GameBuilder
{
    // TODO: Write docs for everything.
    public class Consumer
    {
        public static void Main(string[] args)
        {
            Scene? currentScene = null;
            ISceneVisitor invokeViewVisitor = new InvokeViewVisitor();

            while ((currentScene = SceneModel.GetNextScene()) != null)
            {
                currentScene.AcceptVisitor(invokeViewVisitor);
            }

        }
    }
}