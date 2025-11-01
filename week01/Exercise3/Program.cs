using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Generate a random number between 1 and 100 (inclusive).
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        // Initial value to ensure the while loop starts.
        int guess = -1;

        Console.WriteLine("Welcome to the Guess My Number game!");
        Console.WriteLine("I have picked a number between 1 and 100. Start guessing!");

        // Loop continues until the user guesses the correct number.
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");

            // Use TryParse for safe input conversion.
            if (int.TryParse(Console.ReadLine(), out guess))
            {
                // Provide feedback: Higher or Lower.
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }
            else
            {
                // Handle non-numeric input.
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }

        Console.WriteLine("You guessed it!");
    }
}