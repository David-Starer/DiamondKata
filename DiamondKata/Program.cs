using System;
using DiamondKata.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// https://github.com/davidwhitney/CodeDojos/tree/master/Diamond%20Kata

namespace DiamondKata
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var diamondGenerator = GetServices().GetService<DiamondGenerator>();

            char ? selectedCharacter;

            do
            {
                Console.WriteLine("Enter A - Z");
                selectedCharacter = diamondGenerator.GetSelectedCharacter();
                if (!selectedCharacter.HasValue)
                    Console.WriteLine($"{Environment.NewLine}Invalid input");
                
            } while (!selectedCharacter.HasValue);

            try
            {
                var diamond = diamondGenerator.Generate(selectedCharacter.Value);

                Console.Clear();
                Console.WriteLine(string.Join(Environment.NewLine, diamond));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }

        private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddSingleton<IConsoleReader, ConsoleReader>();
        }

        private static IServiceProvider GetServices()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .ConfigureServices(services => services.AddSingleton<DiamondGenerator>())
                .Build()
                .Services;
        }
    }
}
