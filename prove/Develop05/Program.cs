using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static void Main(string[] args)
    {
        string _saveFilePath = "progress.json";

        Player player = ProgressManager.LoadPlayerProgress(_saveFilePath);
        if (player == null)
        {
            List<Goal> list_completed = new List<Goal>();
            List<Goal> list_current = new List<Goal>();
            player = new Player(1, 0, 0, list_completed, list_current);
        }

        bool quit = false;
        while (quit!= true)
        {            
            Console.WriteLine($"Welcome {player.DisplayPlayer}");
            Console.WriteLine("1. View Current Goals");
            Console.WriteLine("2. View Completed Goals");
            Console.WriteLine("3. Add Goal");
            Console.WriteLine("4. Update Goal");
            Console.WriteLine("5. Player Progress");
            Console.WriteLine("6. Exit\n");
            Console.WriteLine("Please enter a number (ex: 3):\n");

            string input = Console.ReadLine();

            switch(input)
            {
                // View Current
                case "1":
                    Console.Clear();
                    player.DisplayCurrentGoals();
                    Console.WriteLine("Please press enter to return to menu.");
                    Console.ReadLine();
                    break;
                // View Completed
                case "2":
                    Console.Clear();
                    player.DisplayCompletedGoals();
                    Console.WriteLine("Please press enter to return to menu.");
                    Console.ReadLine();
                    break;
                // Add Goal
                case "3":
                    Console.Clear();
                    DisplayAddGoalMenu(player);
                    break;
                // Update Goal
                case "4":
                    break;
                // Player Progress
                case "5":
                    Console.Clear();
                    player.DisplayPlayerProgress();
                    Console.WriteLine("Please press enter to return to menu.");
                    Console.ReadLine();
                    break;
                // Exit and Save player
                case "6":
                    Console.Clear();
                    ProgressManager.SavePlayerProgress(player, _saveFilePath);
                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public static void DisplayAddGoalMenu(Player player)
    {
        // Menu for adding goals
        Console.WriteLine("Which type of goal would you like to add?");
        Console.WriteLine("1. A One-Time Goal");
        Console.WriteLine("2. ");
        Console.WriteLine("3. Add Goal");
        Console.WriteLine("4. Update Goal");
        Console.WriteLine("5. Player Progress");
        Console.WriteLine("6. Exit\n");
        Console.WriteLine("Please enter a number (ex: 3):\n");

        string input = Console.ReadLine();

        switch(input)
        {
            case "1":
                // Title and description for new goal
                Console.Clear();
                Console.WriteLine("Provide a title for this goal:");
                string title = Console.ReadLine();
                Console.WriteLine("Now please provide a brief desription:");
                string description = Console.ReadLine();

                // Create the instance goal and add it to the player
                InstanceGoal new_goal = new InstanceGoal(title, description);
                player.CreateGoal(new_goal);

                // returning to the main menu
                Console.Clear();
                Console.WriteLine("Please press enter to return to menu.");
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try enter a number (1, 3, etc):");
                Console.ReadLine();
                break;
        }
    }
}

public static class ProgressManager
{
    public static Player LoadPlayerProgress(string filePath)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return null;
            }

            // Read all text from the file
            string jsonString = File.ReadAllText(filePath);

            // Check if the JSON string is empty
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                Console.WriteLine("The file is empty. No player progress to load.");
                return null; // Or return a default player object if needed
            }

            // Deserialize the JSON string to a Player object
            return JsonSerializer.Deserialize<Player>(jsonString);
        }
        catch (IOException e)
        {
            Console.WriteLine("Failed to load player progress: " + e.Message);
            return null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine("Error deserializing JSON data: " + ex.Message);
            return null;
        }
    }

    public static void SavePlayerProgress(Player player, string filePath)
    {
        try
        {
            // Serialize the Player object to JSON string
            string jsonString = JsonSerializer.Serialize(player);

            // Check if the JSON string is empty
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                Console.WriteLine("Player progress is empty. Nothing to save.");
                return;
            }

            // Write the JSON string to the file
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine(jsonString);
            Console.WriteLine("Player progress saved successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine("Failed to save player progress: " + e.Message);
        }
    }
}