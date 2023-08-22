using GameBuilder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBuilderAPIConsumer
{
    public static class ServiceExtensions
    {
        public static IHostBuilder InitUserBuilderServices(this IHostBuilder builder)
        {
            builder.ConfigureServices((hostingContext, services) =>
            {
                services.AddSingleton<UserBuilder>();
            });

            return builder;
        }
    }
}
