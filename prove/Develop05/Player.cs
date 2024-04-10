using System.Text.Json;
using System.Text.Json.Serialization;

public class Player
{
    private int _level;
    private int _exp;
    private string _levelTitle;
    private int _titleIndex;
    private List<string> _listOfTitles = new List<string>{"Destroyer", "Destroyer Better", "Level 3", "Champion Underpants", "Unicorn Master", "Untold Beauty", "King Queen", "Queen King", "Legend Above Legends"};
    private List<Goal> _completedGoals;
    private List<Goal> _currentGoals;

    public Player(int level, int exp, int titleIndex, List<Goal> completedGoals, List<Goal> currentGoals)
    {
        _level = level;
        _exp = exp;
        _completedGoals = completedGoals;
        _currentGoals = currentGoals;
        _titleIndex = titleIndex;
        _levelTitle = _listOfTitles[_titleIndex];
    }

    public List<string> GetStringRepresentation()
    {
        List<string> jsonString = new List<string>();
        jsonString.Add($"{_level}:{_exp}:{_titleIndex}:{_completedGoals}:{_currentGoals}");

        foreach(Goal goal in _currentGoals)
        {
            jsonString.Add(goal.GetGoalString());
        }
        foreach(Goal goal in _completedGoals)
        {
            jsonString.Add(goal.GetGoalString());
        }
        
        return jsonString;
    }

    public void CompleteGoal(Goal goal)
    {
        _currentGoals.Remove(goal);
        _completedGoals.Add(goal);

        int goalEXP = goal.GetEXP();
        _exp += goalEXP;

        if (_exp >= 1000)
        {
            _exp = 0;
            _level += 1;
            _titleIndex += 1;
            _levelTitle = _listOfTitles[_titleIndex];
        }
    }

    public void CreateGoal(Goal goal)
    {
        _currentGoals.Add(goal);
    }

    public void DisplayCurrentGoals()
    {
        foreach (Goal goal in _currentGoals)
        {
            goal.Display();
        }
    }

    public void DisplayCompletedGoals()
    {
        foreach (Goal goal in _completedGoals)
        {
            goal.Display();
        }
    }

    public void DisplayPlayer()
    {
        Console.WriteLine($"Player level {_level}: {_levelTitle}");
    }

    public void DisplayPlayerProgress()
    {
        Console.WriteLine($"You still need: {1000 - _exp} EXP to level up.");
    }

    public class PlayerConverter : JsonConverter<Player>
    {
        public override Player Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string[] values = reader.GetString().Split(':');

            int level = int.Parse(values[0]);
            int exp = int.Parse(values[1]);
            int titleIndex = int.Parse(values[2]);
            List<Goal> completedGoals = ParseGoals(values[3]);
            List<Goal> currentGoals = ParseGoals(values[4]);

            return new Player(level, exp, titleIndex, completedGoals, currentGoals);
        }
        public override void Write(Utf8JsonWriter writer, Player value, JsonSerializerOptions options)
        {
            // Write Player object to JSON
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        private List<Goal> ParseGoals(string goalString)
        {
            List<Goal> goals = new List<Goal>();

            string[] goalStrings = goalString.Split('.');

            return goals;
        }
    }
}