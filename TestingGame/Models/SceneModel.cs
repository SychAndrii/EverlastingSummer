using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using GameBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Models
{
    internal static class SceneModel
    {
        static SceneModel()
        {
            SceneBuilder.Build().Wait();
        }

        public async static Task<Scene?> GetFirstScene()
        {
            return await SceneBuilder.GetFirstScene();
        }
    }
}
