# Super Awesome Anagram Assignment

## Assumptions Given:
*	The words in the input file are ordered by size
* Production files will not fit into memory all at once (but all the words of the same size would)
*	The words are not necessarily actual English words, for example, “abc” and “cba” are both considered words for the sake of this exercise.

## Assumptions Made:
* File location argument will be provided with a full location path for example: "C:\Data\example1.txt"
* The input file will be a text file with each word separated by a new line
* If input words contain non alphabetic characters these will be considered part of the word (ie. not excluded)


## HOW TO

### Running The Application
* Unzip the folder
* Navigate to \SuperAwesomeAnagramAssignment\bin\Debug\net5.0
* Run the SuperAwesomeAnagramAssignment.exe (it should open in a command window)
* You will be prompted to enter the input file location (must be the full path)
* The anagrams will be output in the console window
* Press any key to close the console app


### Running The Tests
Running the tests is easiest using an IDE like Visual Studio (you can download community edition for free). NUnit do provide a command line and GUI option but I haven't been able to get them working on my machine (https://docs.nunit.org/articles/nunit/running-tests/Console-Runner.html)
Here is how to run the tests in Visual Studio:
* Open the SuperAwesomeAnagramAssignment.sln file in Visual Studio
* You can right click on either the AnagramControllerTests.cs or InputFileControllerTests.cs files and select 'Run Tests'
* This will bring up the Test Explorer panel where you can see all the tests and the results

## Tech Stack:
* C# .Net 5.0
* Console App
* NUnit for testing
* Moq for mocking objects in tests


## Big O Analysis
While I have understood the concepts of what makes code scalable (for example avoiding loops within loops), Big O notation is realtively new to me.
In my code I have attempted to ensure that there are not loops within loops but instead try to keep loops running one after the other. In most places in my code I am using Linq expressions to handle manipulating the data, I have attempted to find some Big O notation for things like 'Select', 'GroupBy', 'OrderBy' but have found very little information. I have also attempted to read the documentation about these Linq operations and found very little information about how they are iterating over the data. So here is my best attempt to give a Big O analysis based on the knowledge and experience I have:

I believe the Big O to be O(n) because while I am iterating over the data more than once, it is in succession rather than nested. 

There is one part of the code where I am unsure of the underlying workings of GroupBy and OrderBy, you can find it on line 34 in SuperAwesomeAnagramAssignment\Controllers\AnagramController.cs. The code is iterating over the words and then sorting the characters in the word, because of this, it is possible the Big O is O(n^2).


## Data Strcutures
I have primarily used the IEnumerable data structure type in most places, this is because it is interchangeble with different types of enumerable in C# such as arrays or lists. Also IEnumerable allows for functions like yield which I haven't used in this code but given more time would probably have utilised it.
Where I have specified Arrays this has been because the data is immutable.
Where I have used List, this is because it allows me to add to it as it processes the data.

## What I Would Do Given More Time
* Improve efficiency for example rather than attempting to get words of every length between shortest and the longest word, just attempt to retrieve words of lengths that are known to exist in the input file.

Most improvements would be dependant on the requirement provided but some things I would consider may be needed would be:
* Moving the anagram code into a shared class library so that other applications could use it.
* Allowing for other input formats, for example CSV, Database etc.
* Handling for non alphabetic characters, for example the need might that numbers and punctuation be exclude them from the comparison.


