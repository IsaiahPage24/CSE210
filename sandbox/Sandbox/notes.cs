using System.Net.Mime;

public abstract class Note
{
    protected DateTime _creation_date;
    protected string _title;

    public abstract void Display();
}

public class TextNote : Note
{
    private string _content;

    public TextNote(string title, string content)
    {
        _title = title;
        _content = content;
    }
    public override void Display()
    {
        Console.WriteLine(_title);
        Console.WriteLine(_content);
    }
    public void EditContent(string edited_content)
    {
        _content = edited_content;
    }
    
    public void EditTitle(string new_title)
    {
        _title = new_title;
    }
}

public class Checklist : Note
{
    public override void Display()
    {
        throw new NotImplementedException();
    }
}

public class Drawing : Note
{
    public override void Display()
    {
        throw new NotImplementedException();
    }
}

public class VoiceMemo : Note
{
    public override void Display()
    {
        throw new NotImplementedException();
    }
}