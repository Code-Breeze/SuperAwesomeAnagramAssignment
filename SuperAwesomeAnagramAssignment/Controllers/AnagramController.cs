using System.Collections.Generic;
using System.Linq;

namespace SuperAwesomeAnagramAssignment.Controllers
{
    public class AnagramController
    {
        private IInputFileController _inputFileController;

        public AnagramController() {}

        /// <summary>
        /// Expects a .txt file with one word per line.
        /// Will compare the words in the file to find and group together the anagrams.
        /// </summary>
        public IEnumerable<string[]> GetGroupedAnagramsFromFile(IInputFileController inputFileController)
        {
            _inputFileController = inputFileController;
            int wordLength = _inputFileController.ShortestWordLength;
            bool fileReadComplete = false;
            var result = new List<string[]>();

            while (!fileReadComplete)
            {
                var words = _inputFileController.GetWordsOfSameLengthFromFile(wordLength, out fileReadComplete);
                
                if(words != null && words.Any())
                    result.AddRange(GroupAnagrams(words));
                wordLength++;
            }

            return result;
        }

        /// <summary>
        /// Takes an IEnumerable of words and will return and IEnumerable containing string arrays.
        /// Each string array contains all the words that are anagrams of each other.
        /// </summary>
        public static IEnumerable<string[]> GroupAnagrams(IEnumerable<string> words)
        {
            //sort each word into character order to find and group by anagrams
            var groupedAnagrams = words.GroupBy(w => string.Concat(w.OrderBy(c => c)));
            return groupedAnagrams.Select(g => g.ToArray());
        }
    }
}
