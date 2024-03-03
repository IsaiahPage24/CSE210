using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit) 
        {
            Console.Clear(); // Menu Options
            Console.WriteLine("Welcome to Mindfulness Activities!");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Writing");
            Console.WriteLine("4. Quit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Breathing breathing = new Breathing();
                    breathing.Play();
                    break;
                case "2":
                    Reflection reflection = new Reflection();
                    reflection.Play();
                    break;
                case "3":
                    Writing writing = new Writing();
                    writing.Play();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("I hope you had a great session, and have a great day! Press Enter to quit.");
                    Console.ReadLine();
                    Console.Clear();
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}