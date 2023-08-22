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
    internal class SceneModel
    {
        private SceneBuilder SceneBuilder { get; }
        public SceneModel(SceneBuilder sceneBuilder)
        {
            SceneBuilder = sceneBuilder;
        }

        public async Task<Scene?> GetFirstScene()
        {
            return await SceneBuilder.GetFirstScene();
        }

        public async Task BuildScenes()
        {
            await SceneBuilder.Build();
        }
    }
}
