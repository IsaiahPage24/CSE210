public class Entry {
    private string _content {get; set;}
    private DateTime _date {get; set;}

    public Entry(string content) {
        _content = content;
        _date = DateTime.Now;

    }
    public override string ToString()
    {
        return $"{_content}<>{_date}";
    }
}