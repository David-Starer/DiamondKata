using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://github.com/davidwhitney/CodeDojos/tree/master/Diamond%20Kata

namespace DiamondKata
{
    private static class Program
    {
        private static void Main()
        {
            ConsoleKeyInfo key;
            bool isValidKey;

            do
            {
                Console.WriteLine("Enter A - Z");
                key = Console.ReadKey();
                isValidKey = char.IsLetter(key.KeyChar);
                if (!isValidKey)
                {
                    Console.WriteLine($"{Environment.NewLine}Invalid input");
                }
            }
            while(!isValidKey);

            const char whiteSpace = ' ';
            var numberOfCharacters = char.ToUpper(key.KeyChar) - 'A' + 1;

            var diamond = new List<string>();

            for (var row = 0; row < numberOfCharacters; row++)
            {
                var partLine = new StringBuilder(new string(whiteSpace, numberOfCharacters))
                {
                    [row] = (char)('A' + row)
                };

                var rightPart = partLine.ToString();
                var leftPart = new string(rightPart[1..].Reverse().ToArray());

                diamond.Add($"{leftPart}{rightPart}");
            }

            diamond.AddRange(diamond.ToArray().Reverse().Skip(1));

            Console.Clear();
            Console.WriteLine(string.Join(Environment.NewLine, diamond));
            Console.Read();
        }
    }
}
