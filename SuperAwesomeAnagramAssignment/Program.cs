using System;
using SuperAwesomeAnagramAssignment.Controllers;
using System.Linq;

namespace SuperAwesomeAnagramAssignment
{
    class Program
    {
        //the main program just handles the input and output, all logic has been abstracted out
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the full file path, including filename");
            var path = Console.ReadLine();
            if(path == null || path == "")
                Console.WriteLine("Nothing entered, please try again");

            var fileController = new InputFileController(path);
            var anagramController = new AnagramController();

            foreach( var group in anagramController.GetGroupedAnagramsFromFile(fileController))
            {
                Console.WriteLine(
                    string.Join(',', group)
                );                
            }

            Console.WriteLine("Press any key to close");
            Console.ReadLine();
        }
    }
}
