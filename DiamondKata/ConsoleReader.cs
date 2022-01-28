using System;
using DiamondKata.Interfaces;

namespace DiamondKata
{
    public class ConsoleReader : IConsoleReader
    {
        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}