using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Guessing Game!");
        Console.Write("Choose a number: ");
        string range = Console.ReadLine();
        int i = int.Parse(range);
        Console.WriteLine(string.Format("We will choose a random number between 1 and {0}", range));
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, i);
        int guess = 0;
        do
        {
            Console.Write("What is your guess?\n>");
            string guessString = Console.ReadLine();
            guess = int.Parse(guessString);
            if (guess > number)
            {
                Console.WriteLine("Too High!");
            }
            if (guess < number)
            {
                Console.WriteLine("Too Low!");
            }
        } while (guess != number);
        Console.Write("Correct!");
    }
}