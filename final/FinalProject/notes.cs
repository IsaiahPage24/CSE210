using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Mime;

public abstract class Note
{
    protected DateTime _creation_date;
    protected string _title;

    public abstract void Display();
    public string GetTitle()
    {
        return _title;
    }
}

public class TextNote : Note, ISerializable
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

    protected TextNote(SerializationInfo info, StreamingContext context)
    {
        _title = info.GetString("Title");
        _content = info.GetString("Content");
    }

    public void EditContent(string edited_content)
    {
        _content = edited_content;
    }
    
    public void EditTitle(string new_title)
    {
        _title = new_title;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Title", _title);
        info.AddValue("Content", _content);
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