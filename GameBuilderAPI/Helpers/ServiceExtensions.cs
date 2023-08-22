using ConsoleTesting.Database;
using ConsoleTesting.Services;
using DB.Services;
using GameBuilder.Controllers;
using GameBuilder.Services;
using GameBuilderAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilder.Helpers
{
    public static class ServiceExtensions
    {
        public static IHostBuilder InitAPIServices(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostingContext, services) =>
            {
                services.AddSingleton<GameBuilderAPI>();
                services.AddSingleton<GameBuilderController>();
                services.AddSingleton<ChoiceService>();
                services.AddSingleton<CharacterService>();
                services.AddSingleton<ConditionService>();
                services.AddSingleton<SceneService>();
                services.AddSingleton<StateService>();
                services.AddSingleton<UserService>();
                services.AddDbContext<ESContext>();
            });

            return builder;
        }
    }
}
