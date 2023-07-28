using ConsoleTesting;
using ConsoleTesting.Models.Database;
using ConsoleTesting.Models;
using Microsoft.EntityFrameworkCore;
using ConsoleTesting.EverlastingSummerModels.Base;
using ConsoleTesting.EverlastingSummerModels;
using ConsoleTesting.EverlastingSummerModels.Scenes;

namespace Program
{
    public class Testing
    {
        public static void Main(string[] args)
        {
            Player player = new Player();
            Scene lastScene;
            Scene scene1 = new StandardScene("This is the end!");
            Scene scene2 = new StandardScene("This is a scene before the end!");
            scene2.Transitions = new List<Transition>()
            {
                new Transition(scene1)
            };
            Scene scene3 = new StandardScene("This is beginning!");
            scene3.Transitions = new List<Transition>()
            {
                new Transition(scene2)
            };
            lastScene = scene1;

            Scene currentScene = scene3;

            while (true)
            {
                currentScene.Show();
                if(currentScene == lastScene)
                {
                    break;
                }
                currentScene = currentScene.Transitions.FirstOrDefault().TargetScene;
            }
        }
    }
}