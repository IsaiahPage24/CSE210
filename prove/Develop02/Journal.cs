using System.Text.Json.Serialization;
using System.Xml;

public class Journal {
    // Dictionary that is all of the Journal Entries
    private List<string> journalEntries = new List<string>();

    public List<string> GetList() {
        return journalEntries;
    }

    public void Display(int entryNumber) {
        Console.WriteLine($"{journalEntries[entryNumber]}");
    }

    public void DisplayAll() {
        foreach (string entry in journalEntries)
        {
            Console.WriteLine(entry);
        }
    }

    public void LoadJournal(string fileName) {
        try
        {
            string[] fileLines = File.ReadAllLines(fileName);
            journalEntries.AddRange(fileLines);
            Console.WriteLine("File loaded into Journal.");
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }

    public void SaveJournal<T>(List<T> list, string fileName) {
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(fileName, json);
    }

    public void SaveEntry(Entry entry) {
        journalEntries.Add(entry.ToString());
    }
}