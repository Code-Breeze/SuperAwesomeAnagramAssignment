using NUnit.Framework;
using SuperAwesomeAnagramAssignment.Controllers;
using System;
using System.Collections.Generic;

namespace SuperAwesomeAnagramAssignment.Tests
{
    public class InputFileControllerTests
    {
        private InputFileController _fileController;
        private bool _fileReadComplete = false;

        [SetUp]
        public void Setup()
        {
            string current_path = Environment.CurrentDirectory;
            _fileController = new InputFileController(current_path + "\\TestFiles\\example1.txt");
        }

        [Test]
        public void InputFileConstructorSetsStateFromFile()
        {
            //Assert
            Assert.AreEqual(3, _fileController.ShortestWordLength);
        }

        [Test]
        public void InputFileControllerOnlyGetsLineOfExactLength()
        {
            //Arrange
            var expected = new List<string>() { "hello" };
            //Act

            var result =_fileController.GetWordsOfSameLengthFromFile(5, out _fileReadComplete);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void InputFileControllerSetsFileReadComplete()
        {
            //Act
            _fileController.GetWordsOfSameLengthFromFile(5, out _fileReadComplete);

            //Assert
            Assert.AreEqual(true, _fileReadComplete);
        }
    }
}