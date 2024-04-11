using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class NoteStorage
{
    private string _filePath;

    public NoteStorage(string FilePath)
    {
        // Decide the name of the File Path
        _filePath = FilePath;
    }

    public void SaveNotes(List<Note> note_list)
    {
        // Serialize the list of notes to JSON
        string json = JsonSerializer.Serialize(note_list);

        // Write the JSON to a file
        File.WriteAllText(_filePath, json);
    }

    public List<Note> LoadNotes()
    {
        if (File.Exists(_filePath))
        {
            // Read from file
            string json = File.ReadAllText(_filePath);
            // Deserialize into list of note classes
            return JsonSerializer.Deserialize<List<Note>>(json);
        }
        else
        {
        throw new FileNotFoundException("Notes file not found", _filePath);
        }
    }
}

public class NoteManager
{
    private List<Note> _list_of_notes;

    public NoteManager()
    {
        // instantiate storage and load note list from json
        NoteStorage storage = new NoteStorage("notes.json");
        _list_of_notes = storage.LoadNotes();
    }

    public void AddNote(Note new_note)
    {
        _list_of_notes.Add(new_note);
    }

    public List<Note> GetNotes()
    {
        return _list_of_notes;
    }

    public Note DisplayOneNote(string title)
    {
        Note note = new TextNote("Sorry", "A note by that title does not exist");
        
        foreach (Note note1 in _list_of_notes)
        {
            if (title == note1.GetTitle())
            {
                note = note1;
            }
        }

        note.Display();
        return note;
    }

    public void DisplayAllNotes()
    {
        foreach (Note note in _list_of_notes)
        {
            note.Display();
        }
    }
}