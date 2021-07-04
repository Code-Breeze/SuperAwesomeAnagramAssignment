using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuperAwesomeAnagramAssignment.Controllers
{
    public class InputFileController : IInputFileController
    {
        private string _fileLocation;
        private int _logestWordLength;
        public int ShortestWordLength { get; set; }

        public InputFileController(string fileLocation)
        {
            _fileLocation = fileLocation;
            //given words in files are in size order, we can use the first and last line to determine where to start
            //and when to stop reading the file
            _logestWordLength = File.ReadLines(_fileLocation).Last().Length;
            ShortestWordLength = File.ReadLines(_fileLocation).First().Length;
        }

        /// <summary>
        /// Takes in an integer that is used to search through the file for words that have that many characters 
        /// and returns the matching words in an IEnumerable of strings.
        /// It assumes the file is .txt with each word on a new line and the words to be in order of size.
        /// </summary>
        public IEnumerable<string> GetWordsOfSameLengthFromFile(int wordLength, out bool fileReadComplete)
        {
            fileReadComplete = wordLength == _logestWordLength;

            try
            {
                var lines = from line in File.ReadLines(_fileLocation)
                            where line.Length == wordLength
                            select line;
                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
