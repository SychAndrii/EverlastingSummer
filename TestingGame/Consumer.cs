using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using GameBuilder.Helpers;
using GameConsumer.Models;
using GameConsumer.Visitors;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SceneBuilderAPIConsumer;
using System;
using UserBuilderAPIConsumer;
using VisualNovelModels.Visitors;

namespace GameBuilder
{
    public class Consumer
    {
        public static void Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            ConfigureServices(hostBuilder);
            using var host = hostBuilder.Build();

            var sceneModelService = host.Services.GetRequiredService<SceneModel>();
            sceneModelService.BuildScenes().Wait();

            Scene? currentScene = sceneModelService.GetFirstScene().Result;

            var userModel = host.Services.GetService<UserModel>()!;

            ISceneVisitor invokeViewVisitor = new InvokeViewVisitor(userModel);

            while(currentScene != null)
            {
                currentScene.AcceptVisitor(invokeViewVisitor);
                Transition? transitionToNextScene = currentScene?.GetPossibleTransition(userModel.CurrentUser);
                currentScene = transitionToNextScene?.TargetScene;
            }
        }

        private static void ConfigureServices(IHostBuilder hostBuilder)
        {
            hostBuilder.InitAPIServices();
            hostBuilder.InitSceneBuilderServices();
            hostBuilder.InitUserBuilderServices();
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<UserModel>();
                services.AddSingleton<SceneModel>();
            });
        }
    }
}