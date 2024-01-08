using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?\n");
        string FirstName = Console.ReadLine();
        Console.Write("What is your last name?\n");
        string LastName = Console.ReadLine();
        Console.WriteLine($"You are {LastName}, {FirstName} {LastName}.");
    }
}