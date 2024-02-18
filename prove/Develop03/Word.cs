public class Word {
    private string _text;

    private bool _is_hidden;


    public Word(string Text) {
        _text = Text;
        _is_hidden = false;
    }
    public void Display() {
        if (_is_hidden)
            for (int i = 0; i < _text.Length; i++)
            {
                Console.Write("_");
            }
        else
            Console.Write(_text);
    }

    public void SetHidden() {
        _is_hidden = true;
    }
}