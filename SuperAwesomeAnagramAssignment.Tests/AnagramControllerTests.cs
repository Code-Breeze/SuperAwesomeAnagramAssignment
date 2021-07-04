using NUnit.Framework;
using System.Collections.Generic;
using SuperAwesomeAnagramAssignment.Controllers;
using Moq;

namespace SuperAwesomeAnagramAssignment.Tests
{
    public class AnagramControllerTests
    {
        private AnagramController _anagramController;
        private Mock<IInputFileController> _mockFileController;
        private bool _fileReadComplete;

        [SetUp]
        public void Setup()
        {
            _anagramController = new AnagramController();

            _fileReadComplete = true;
            _mockFileController = new Mock<IInputFileController>();
            _mockFileController.SetupGet(x => x.ShortestWordLength).Returns(3);
        }

        [Test]
        public void GetGroupedAnagramsFromFileWithOneWord()
        {
            //Arrange
            var output = new List<string>() { "cba" };
            _mockFileController.Setup(x => x.GetWordsOfSameLengthFromFile(It.IsAny<int>(), out _fileReadComplete))
                .Returns(output);            

            var expected = new List<string[]>() 
            {
                new string[]{ "cba" }       
            };

            //Act
            var result =_anagramController.GetGroupedAnagramsFromFile(_mockFileController.Object);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetGroupedAnagramsFromFileWithMultipleWordAnagrams()
        {
            //Arrange            
            var output = new List<string>() { "cba", "abc", "zxy", "xyz" };
            _mockFileController.Setup(x => x.GetWordsOfSameLengthFromFile(It.IsAny<int>(), out _fileReadComplete))
                .Returns(output);

            var expected = new List<string[]>()
            {
                new string[]{ "cba", "abc" },
                new string[]{ "zxy", "xyz" }
            };

            //Act
            var result = _anagramController.GetGroupedAnagramsFromFile(_mockFileController.Object);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetGroupedAnagramsFromFileWithNonAlphabeticCharacters()
        {
            //Arrange
            var output = new List<string>() { "cba1,4", "1,4cba" };
            _mockFileController.Setup(x => x.GetWordsOfSameLengthFromFile(It.IsAny<int>(), out _fileReadComplete))
                .Returns(output);

            var expected = new List<string[]>()
            {
                new string[]{ "cba1,4", "1,4cba" }
            };

            //Act
            var result = _anagramController.GetGroupedAnagramsFromFile(_mockFileController.Object);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetGroupedAnagramsFromFileWithMultipleLengthAnagrams()
        {
            //Arrange
            var fileReadNotComplete = false;

            var output3Char = new List<string>() { "cba", "abc" };
            _mockFileController.Setup(x => x.GetWordsOfSameLengthFromFile(3, out fileReadNotComplete))
                .Returns(output3Char);

            var output4Char = new List<string>() { "azxy", "xyza" };
            _mockFileController.Setup(x => x.GetWordsOfSameLengthFromFile(4, out _fileReadComplete))
                .Returns(output4Char);

            var expected = new List<string[]>()
            {
                new string[]{ "cba", "abc" },
                new string[]{ "azxy", "xyza" }
            };

            //Act
            var result = _anagramController.GetGroupedAnagramsFromFile(_mockFileController.Object);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetGroupedAnagramsFromFileWithNoWords()
        {
            //Arrange
            var output = new List<string>();
            _mockFileController.Setup(x => x.GetWordsOfSameLengthFromFile(It.IsAny<int>(), out _fileReadComplete))
                .Returns(output);

            var expected = new List<KeyValuePair<string, string>[]>() {};

            //Act
            var result = _anagramController.GetGroupedAnagramsFromFile(_mockFileController.Object);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}