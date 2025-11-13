using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizerApp
{
    // Main execution logic for the Scripture Memorizer Program.
    public class Program
    {
        /*
        Exceeding Requirements
        1. Library of Scriptures: The program utilizes a Dictionary (scriptureLibrary) 
           to store multiple scriptures and selects one at random to present to the user 
           at startup.
        2. Non-Repeating Word Selection: The HideRandomWords method 
           in the Scripture class ensures that only words that are NOT already hidden 
           are selected for masking, improving the user experience.
        */

        static void Main(string[] args)
        {
            // Create a library of scriptures to choose from.
            Dictionary<Reference, string> scriptureLibrary = new Dictionary<Reference, string>
            {
                {
                    new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
                },
                {
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
                },
                {
                    new Reference("Matthew", 25, 21),
                    "Well done, good and faithful servant; you have been faithful over a few things, I will make you ruler over many things. Enter into the joy of your lord."
                },
  {
                    new Reference("Doctrine and Convenants", 10, 5),
                    "Pray always, that you may come off conqueror; yea, that you may conquer Satan, and that you may escape the hands of the servants of Satan that do uphold his work."
                },
            };

            // Select a random scripture from the library.
            Random rand = new Random();
            int index = rand.Next(scriptureLibrary.Count);
            KeyValuePair<Reference, string> selectedScripture = scriptureLibrary.ElementAt(index);

            Scripture scripture = new Scripture(selectedScripture.Key, selectedScripture.Value);

            string input = "";

            while (input.ToLower() != "quit" && !scripture.IsCompletelyHidden())
            {
                // Clear the console screen (using try-catch for environment compatibility).
                try
                {
                    Console.Clear();
                }
                catch (System.IO.IOException)
                {
                    // Print newlines if Console.Clear() fails.
                    Console.WriteLine("\n\n\n");
                }

                // Display the scripture.
                Console.WriteLine(scripture.GetDisplayText());

                // Prompt user input.
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to end the program.");
                input = Console.ReadLine() ?? "";

                if (input.ToLower() != "quit")
                {
                    // Hide 3 to 5 random words that are currently visible.
                    scripture.HideRandomWords(rand.Next(3, 6));
                }
            }

            // Final display after the loop ends.
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("\n\n\n");
            }

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden or you chose to quit. Goodbye!");
        }
    }
}