using System;

// https://github.com/davidwhitney/CodeDojos/tree/master/Diamond%20Kata

namespace DiamondKata
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var diamondGenerator = Startup.GetService<DiamondGenerator>();

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
    }
}
