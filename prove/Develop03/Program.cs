using System;
using System.IO;
using System.Text.Json;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the name of the reference for your scripture?");
        string reference = Console.ReadLine();
        Console.WriteLine("What is the name of the file containing your scripture?");
        string fileName = Console.ReadLine();
        string jsonString = File.ReadAllText(fileName);

        List<string> words = JsonSerializer.Deserialize<List<string>>(jsonString);

        Scripture scripture = new Scripture(reference, words);

        scripture.StringToWord();

        string console = "";
        while (console != "quit")
            scripture.Display();
            Console.Clear();
            Console.WriteLine("Press enter to continue or type 'quit' to quit.");
            console = Console.ReadLine();


    }
}