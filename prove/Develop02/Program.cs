using System;
using Newtonsoft.Json;
public class Program
{
    static void Main(string[] args)
    {
        string file_name = "file_name";
        Console.WriteLine("Welcome to THE JOURNAL(tm)");
        Journal obj = new Journal();
        obj.LoadJournal(file_name);

        while(true) {
            // Print the menu options
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Create New Entry");
            Console.WriteLine("2. Change the Save File");
            Console.WriteLine("3. Display Entry");
            Console.WriteLine("4. Display All Entries");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:\n>");

            string choice = Console.ReadLine();

            switch(choice)
            {
                // Create New Entry
                case "1":
                    // Generate the question for the entry
                    QuestionGenerator question_generator = new QuestionGenerator();
                    string question = question_generator.GenerateQuestion();
                    Console.WriteLine(question);

                    // Save the response as a new entry class
                    string entry_text = Console.ReadLine();
                    Entry new_entry = new Entry(entry_text);

                    // Save the entry to the journal
                    obj.SaveEntry(new_entry);
                    break;

                // Change the File Location by changing the name
                case "2":
                    Console.WriteLine("What is the new file name?");
                    file_name = Console.ReadLine();
                    break;

                // Display Entry
                case "3":
                    Console.WriteLine("What is the entry number?");
                    int entry_number = int.Parse(Console.ReadLine());
                    obj.Display(entry_number);
                    break;

                // Display All Entries
                case "4":
                    obj.DisplayAll();
                    break;

                // Exit
                case "5":
                    Console.WriteLine("Exiting journal...");
                    obj.SaveJournal(obj.GetList(), file_name);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5");
                    break;
            }
        }

    }
}