using System.Collections.Generic;

namespace DiamondKata.Interfaces
{
    public interface IDiamondGenerator
    {
        IEnumerable<string> Generate(char selectedCharacter);
        char? GetSelectedCharacter();
    }
}