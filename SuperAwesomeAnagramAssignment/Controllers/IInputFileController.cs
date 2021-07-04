using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAwesomeAnagramAssignment.Controllers
{
    public interface IInputFileController
    {
        public int ShortestWordLength { get; set; }
        public IEnumerable<string> GetWordsOfSameLengthFromFile(int wordLength, out bool fileReadComplete);
    }
}
