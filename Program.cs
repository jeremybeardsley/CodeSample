using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;


namespace CrosswordSolver
{
    //***********************************Instructions********************************
    /*
    *Implement a Crossword Solver
    * 1. User needs to be able to input a pattern of a combination of known letters and wildcards. 
    *  The input format should use an asterisk: '*' (U+002A) as a wildcard.
    *  Make this simple!
    *  
    * 2. The program should return all words in the dictionary that match the input pattern. 
    *  This means you won't be solving a whole crossword - just providing options for what would 
    *  fit in a crossword row or column.
    *      
    *  Example Input: b**r
    *  Output: Found 5 words in 1000 ms: Bear, Beer, Bier, Birr, Blur, Boar, Boor, Brrr, Buhr, Burr
    *   
    *  Example Input: *eel
    *  Output: Found 8 words in 1000 ms: Feel, Heel, Keel, Peel, Reel, Seel, Teel, Weel
    *   
    * 3. An example dictionary .csv is included for your convenience. You can/should use the default .NET libraries to load it.
    * 4. Using the stopwatch, be sure to indicate how long your solution takes to load its structures, and produce a result. 
    *      Hint: display the time to process a result AFTER printing them out, otherwise you won't be able to see it in large result sets.
    * 
    * A few final points:
    * 1. The order of priorities for the solution should be: Correctness, Performance, elegance, and usability.
    * 2. Startup time and memory usage are much less important than the time taken to solve the crossword pattern (which is critical).
    * 3. Error handling and input validation are nice to haves, as long as your control schemes and instructions are clear.
    * 4. Do not change the method signature or parameters of GetPossibleWords. In other words your solution should be built around this method.
    * 
    */

     /*This is the response to the above requirements by Jeremy Beardsley 4/26/2019
      *Assumptions based on open questions:
      * The crossword solver shouldnt care about case, so I coded the Regex comparison to not care, if the requirements change, this is an easy fix.
      * Was unsure if Standard Console window was a valid approach to this, if a pop up dialog is required, this could have been achieved by importing VB libraries, or writing a custom dialog window.
      * 
      */
    public class Program
    {
        static void Main(string[] args)
        {

            //Simple Greeting
            Console.WriteLine("Hello, and welcome to the Crossword Puzzle solver. \n This application is intended to let you know how many words match your search word within our dictionary");
            
            var endSearch = false;
            while (!endSearch)
            {
                var sw = new Stopwatch();

                Console.WriteLine("To perform a search just type your word you wanna search and press enter\n Note: * can be used as a wildcard, so if you wanna find all 4 letter words that start with B, you can type in B***! \n Enter your search term:");
                var input = Console.ReadLine();
                //validate the users input, we dont want any invalid characters, and skips all the real logic and restarts loop if they fail validation
                if (!Regex.IsMatch(input, @"^[a-zA-Z-*]+$"))
                {
                    Console.WriteLine("\nWe are sorry your search term contains invalid characters. \n Please try again with letters a-Z or *. Upper or Lowercase does not matter!\n\n");

                }
                else
                {
                    //Read our file, and then turn it into a list
                    var dictFile = System.IO.File.ReadAllLines("english.csv");
                    var dict = new List<string>(dictFile);
                    //Start Stopwatch, unsure if this is correct place for it, believed we wanted to just time the logic, so i put it here, we can easily move it earlier if requirements dictate. 
                    sw.Start();
                    //Magic! Store the resulting List into a variable
                    var output = GetPossibleWords(input, dict);
                    sw.Stop();

                    //Count words in list, and store it
                    var wordCount = output.Count();
                    var outputAsString = String.Join(", ", output);


                    Console.WriteLine("You searched for the word {0}.", input);
                    Console.WriteLine("Found {0} words in {1}ms: {2}", wordCount, sw.ElapsedMilliseconds, outputAsString);
                    //Give the user a chance to decide if they want to rerun the app, because honestly, who only has issues with 1 word in a crossword puzzle. 
                    Console.WriteLine("\n\n\n\n\n\nWould you like to search again?\n(Y to continue, anything else to End!)");
                    var yNInput = Console.ReadLine();
                    yNInput = yNInput.ToLower();
                    if (yNInput != "y")
                    {
                        endSearch = true;
                    }

                }
            }
        }


        public static List<string> GetPossibleWords(string template, List<string> dict)
        {
            //Convert the template string to a Regex expression we can use for comparison, replacing the wildcard char
            template = String.Format("^{0}$", template.Replace("*", "."));
            var posWords = new List<string>();
            //Loop the list doing Regex compares, and adding valid matches to the output list
            foreach (string line in dict)
            {
                //This can be changed to care about case, if the requirements dictate. 
                if (Regex.IsMatch(line, template, RegexOptions.IgnoreCase))
                {
                    posWords.Add(line);
                }
            }
            return posWords;
        }


    }
}
