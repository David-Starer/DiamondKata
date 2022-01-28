using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiamondKata.Interfaces;

namespace DiamondKata
{
    public class DiamondGenerator : IDiamondGenerator
    {
        private readonly IConsoleReader consoleReader;

        public DiamondGenerator(IConsoleReader consoleReader)
        {
            this.consoleReader = consoleReader;
        }

        public IEnumerable<string> Generate(char selectedCharacter)
        {
            if (!char.IsLetter(selectedCharacter))
                throw new ArgumentException($"Invalid entry: {selectedCharacter}");

            const char whiteSpace = ' ';
            var numberOfCharacters = char.ToUpper(selectedCharacter) - 'A' + 1;

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

            return diamond;
        }

        public char? GetSelectedCharacter()
        {
            var key = consoleReader.ReadKey();
            if (char.IsLetter(key))
                return key;

            return null;
        }
    }
}
