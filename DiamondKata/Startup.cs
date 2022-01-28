using DiamondKata.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiamondKata
{
    public static class Startup
    {
        public static T GetService<T>()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .ConfigureServices(services => services.AddSingleton<DiamondGenerator>())
                .Build()
                .Services
                .GetService<T>();
        }
        private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddSingleton<IConsoleReader, ConsoleReader>();
        }
    }
}