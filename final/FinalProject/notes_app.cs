using System.ComponentModel.Design;

class ProgramNotes
{
    static void Main(string[] args)
    {
        UI ui = new UI();
        ui.Menu(ui);
    }
}

public class UI
{
    private NoteManager _currentSession;

    public UI()
    {
        // Code to display here
        _currentSession = new NoteManager();
    }

    public void Menu(UI ui)
    {
        string input = "";

        while (input != "quit")
        {
            ui.PrintMenu();
            input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Please enter a title for this note:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Please enter the content of this note:");
                    string text = Console.ReadLine();

                    Note new_note = new TextNote(title, text);
                    _currentSession.AddNote(new_note);

                    Console.WriteLine("Your note has been created and saved.");
                    break;
                case "2":
                    break;
                case "3":
                    _currentSession.DisplayAllNotes();
                    Console.ReadLine();
                    break;
                case "4":
                    string note_title = Console.ReadLine();
                    _currentSession.DisplayOneNote(note_title);
                    break;
                case "5":
                    input = "quit";
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter a number.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    public void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Add a text note");
        Console.WriteLine("2. Add a checklist");
        Console.WriteLine("3. See all notes");
        Console.WriteLine("4. See one note");
        Console.WriteLine("5. Quit");
        Console.WriteLine("Please enter a single digit number. E.G.: 1, 3, 5...");
    }
}