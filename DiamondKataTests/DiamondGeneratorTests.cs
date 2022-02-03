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
        private DiamondGenerator sut;

        [SetUp]
        public void Setup()
        {
            var consoleReader = new ConsoleReader();
            sut = new DiamondGenerator(consoleReader);
        }

        private static List<(char, List<string>)> GetTestData()
        {
            return new List<(char,  List<string>)> 
            {
                new ('A', TestDataSetup.GetDiamondA()), 
                new ('C', TestDataSetup.GetDiamondC()), 
                new ('E', TestDataSetup.GetDiamondE()), 
                new ('Z', TestDataSetup.GetDiamondZ())   
            };
        }

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

        [TestCaseSource(nameof(GetTestData))]
        public void GenerateReturns_Correct_List_Of_Strings_For_SelectedCharacter((char selectedCharacter, List<string> expectedDiamond) testData)
        {
            // Arrange

            // Act
            var result = sut.Generate(testData.selectedCharacter);

            // Assert
            result.Should().BeEquivalentTo(testData.expectedDiamond);
        }
        
        [TestCase('!', null)]
        [TestCase('X', 'X')]
        [TestCase('x', 'x')]
        public void GetSelectedCharacter_Returns_Char_When_Alpha_Key_Pressed_Else_Null(char selectedChar, char? expectedResult )
        {
            // Arrange
            var mockConsoleReader = new Mock<IConsoleReader>();
            mockConsoleReader.Setup(x => x.ReadKey()).Returns(selectedChar);
            var diamondGenerator = new DiamondGenerator(mockConsoleReader.Object);

            // Act
            var result = diamondGenerator.GetSelectedCharacter();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}