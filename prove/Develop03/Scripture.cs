using System.ComponentModel.DataAnnotations;
using System.Dynamic;

public class Scripture {
    private string _reference;
    private List<string> _words = new ();

    private List<Word> _word_words = new List<Word>();

    public void IncreaseHiddenWords() {
        
    }
    
    public void Display() {
        Console.WriteLine(_reference);
        for (int i = 0; i < _word_words.Count; i++)
            _word_words[i].Display();
    }

    public Scripture(string Reference, List<string> Words) {
        _reference = Reference;
        _words = Words;
    }

    public void StringToWord() {
        Word newWord = null;
        List<Word> newWordList = new List<Word>();
        foreach (string item in _words)
            newWord = new Word(item);
            newWordList.Add(newWord);
        _word_words = newWordList;
    }
}