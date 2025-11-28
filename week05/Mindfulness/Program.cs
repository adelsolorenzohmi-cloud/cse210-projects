using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        do
        {
            Console.WriteLine("Mindfulness Program Menu");
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Please select an activity: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new ReflectingActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please enter 1, 2, 3, or 4.");
                    break;
            }

            if (choice != "4")
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }

        } while (choice != "4");
    }
}