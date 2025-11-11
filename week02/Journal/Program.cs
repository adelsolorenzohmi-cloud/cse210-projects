using System;

class Program
{
    /*
    Exceeding Requirements: File Error Handling
    
    To improve the program's robustness, explicit file error handling has been 
    implemented in the Journal class methods (LoadFromFile and SaveToFile).

    Specific improvements include:
    1.  Using a try-catch block for the SaveToFile method to catch general 
        IO exceptions
    2.  Using a more specific try-catch block in LoadFromFile to handle 
        FileNotFoundException, providing a clear, user-friendly message 
        when the specified file doesn't exist.
    */

    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(randomPrompt);

                    Console.Write("> ");
                    string response = Console.ReadLine();

                    string dateText = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry
                    {
                        Date = dateText,
                        PromptText = randomPrompt,
                        EntryText = response
                    };

                    theJournal.AddEntry(newEntry);
                    break;

                case "2":
                    theJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    theJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    theJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}