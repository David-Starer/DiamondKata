using System;
using System.Collections.Generic;
using DiamondKata;
using DiamondKata.Interfaces;
using NUnit.Framework;
using FluentAssertions;
using Moq;

namespace DiamondKataTests
{
    public class DiamondGeneratorTests
    {
        private List<string> diamondA;
        private List<string> diamondC;
        private List<string> diamondE;
        private DiamondGenerator sut;

        [SetUp]
        public void Setup()
        {
            diamondA = new()
            {
                "A"
            };

            diamondC = new()
            {
                "  A  ",
                " B B ",
                "C   C",
                " B B ",
                "  A  "
            };
            diamondE = new()
            {
                "    A    ",
                "   B B   ",
                "  C   C  ",
                " D     D ",
                "E       E",
                " D     D ",
                "  C   C  ",
                "   B B   ",
                "    A    "
            };

            var consoleReader = new ConsoleReader();
            sut = new DiamondGenerator(consoleReader);
        }

        [Test]
        [TestCase('!')]
        [TestCase('&')]
        [TestCase('*')]
        [TestCase('+')]
        public void Generate_Throws_Exception_When_Non_Alpha_Character_Entered(char selectedChar)
        {
            // Arrange

            // Act
            Action act = () => sut.Generate(selectedChar);

            // Assert
            act.Should().Throw<ArgumentException>().Where(x => x.Message.Equals($"Invalid entry: {selectedChar}"));
        }

        [Test]
        [TestCase('D')]
        [TestCase('A')]
        [TestCase('V')]
        [TestCase('E')]
        public void Generate_Returns_List_Of_Strings_When_UpperCase_Alpha_Character_Entered(char selectedChar)
        {
            // Arrange

            // Act 
            var result = sut.Generate(selectedChar);

            // Assert
            result.Should().BeOfType<List<string>>();
        }

        [Test]
        [TestCase('s')]
        [TestCase('t')]
        [TestCase('a')]
        [TestCase('r')]
        public void Generate_Returns_List_Of_Strings_When_LowerCase_Alpha_Character_Entered(char selectedChar)
        {
            // Arrange

            // Act 
            var result = sut.Generate(selectedChar);

            // Assert
            result.Should().BeOfType<List<string>>();
        }

        [Test]
        [TestCase('P', 'p')]
        [TestCase('Q', 'q')]
        [TestCase('R', 'r')]
        [TestCase('S', 's')]
        public void Generate_Returns_Same_Output_When_Same_Upper_And_Lower_Case_Characters_Entered(char upperCaseChar, char lowerCaseChar)
        {
            // Arrange

            // Act 
            var upperCaseResult = sut.Generate(upperCaseChar);
            var lowerCaseResult = sut.Generate(lowerCaseChar);

            // Assert
            upperCaseResult.Should().BeEquivalentTo(lowerCaseResult);
        }

        [Test]
        public void GenerateReturns_Correct_List_Of_Strings_When_A_Entered()
        {
            // Arrange

            // Act
            var result = sut.Generate('A');

            // Assert
            result.Should().BeEquivalentTo(diamondA);
        }

        [Test]
        public void GenerateReturns_Correct_List_Of_Strings_When_C_Entered()
        {
            // Arrange

            // Act
            var result = sut.Generate('C');

            // Assert
            result.Should().BeEquivalentTo(diamondC);
        }

        [Test]
        public void GenerateReturns_Correct_List_Of_Strings_When_E_Entered()
        {
            // Arrange

            // Act
            var result = sut.Generate('E');

            // Assert
            result.Should().BeEquivalentTo(diamondE);
        }

        [Test]
        [TestCase('!', null)]
        [TestCase('X', 'X')]
        public void GetSelectedCharacter_Returns_Correct_Value_Depending_Whether_Alpha_Key_Pressed(char selectedChar, char? expectedResult )
        {
            // Arrange
            var mockConsoleReader = new Mock<IConsoleReader>();
            mockConsoleReader.Setup(x => x.ReadKey()).Returns(selectedChar);
            var sut = new DiamondGenerator(mockConsoleReader.Object);

            // Act
            var result = sut.GetSelectedCharacter();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}