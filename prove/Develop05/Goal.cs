using System.ComponentModel.DataAnnotations.Schema;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _expReward;
    protected bool _completion;
    protected int _goalKey;

    public virtual void Display()
    {
        Console.WriteLine($"{_name}: {_description}");
        if (_completion == true)
        {
            Console.WriteLine("Completed");
        }
        else
        {
            Console.WriteLine("Incomplete");
        }
    }

    public virtual int GetEXP()
    {
        return _expReward;
    }

    public virtual void Complete()
    {
        _completion = true;
    }

    public virtual string GetGoalString()
    {
        return $"<>{_goalKey}<>{_name}<>{_description}<>{_completion}";
    }
}

public class InstanceGoal : Goal
{
    public InstanceGoal(string name, string description)
    {
        _name = name;
        _description = description;
        _expReward = 400;
        _completion = false;
        _goalKey = 1;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description)
    {
        _name = name;
        _description = description;
        _expReward = 600;
        _completion = false;
        _goalKey = 2;
    }
}