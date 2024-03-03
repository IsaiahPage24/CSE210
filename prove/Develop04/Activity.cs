abstract class Activity
{
    protected int _activityDuration; // Length of activity decided by each activity

    public abstract void Play();

    // Method to display loading animation
    protected virtual void LoadingAnimation(String message = "Loading")
    {
        Console.Clear();

        while (_activityDuration > 0)
        {    
            Console.Write($"{message} _\nYou have {_activityDuration} seconds left.");
            Thread.Sleep(1000);
            _activityDuration --;
            Console.Clear();
            Console.Write($"{message} >\nYou have {_activityDuration} seconds left.");
            Thread.Sleep(1000);
            _activityDuration --;
            Console.Clear();
            Console.Write($"{message} |\nYou have {_activityDuration} seconds left.");
            Thread.Sleep(1000);
            _activityDuration --;
            Console.Clear();
            Console.Write($"{message} <\nYou have {_activityDuration} seconds left.");
            Thread.Sleep(1000);
            _activityDuration --;
            Console.Clear();
        }
    }
}

class Breathing : Activity
{
    public Breathing()
    {
        Console.Clear();
        bool validInput;
        int time_length;

        do 
        {
            Console.WriteLine("For how long, in seconds, would you like to do the breathing activity?");
            string userInput = Console.ReadLine();
            validInput = int.TryParse(userInput, out time_length);

            if (!validInput)
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid integer.");

        } while (!validInput);

        _activityDuration = time_length;
    }
    public override void Play()
    {
        Console.Clear();
        Console.WriteLine("Breathing Activity"); // Instructions for breathing activity.
        Console.WriteLine("You will start breathing in on the flat line.");
        Console.WriteLine("When you get back to the flat line, start to breathe out.\nPress Enter to continue.");
        Console.ReadLine();
        LoadingAnimation("Breathe in... and Breathe out..."); // Animation is in base class.
        Console.WriteLine("Breathing activity completed! Press Enter to continue.");
        Console.ReadLine();
    }
}

class Reflection : Activity
{
    private List<string> prompts = new List<string> {"Think of a time when you stood up for someone else.", 
                                                     "Think of a time when you did something really difficult.",
                                                     "Think of a time when you helped someone in need.",
                                                     "Think of a time when you did something truly selfless."};
    public Reflection()
    {
        Console.Clear();
        bool validInput;
        int time_length;

        do 
        {
            Console.WriteLine("For how long, in seconds, would you like to reflect for?");
            string userInput = Console.ReadLine();
            validInput = int.TryParse(userInput, out time_length);

            if (!validInput)
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid integer.");

        } while (!validInput);

        _activityDuration = time_length;
    }

    public override void Play()
    {
        Console.Clear();

        Random rand = new Random();
        int randomIndex = rand.Next(0, prompts.Count);

        Console.WriteLine("Reflection Activity");
        Thread.Sleep(1000);
        LoadingAnimation(prompts[randomIndex]); // Using base class method
        Console.WriteLine("Reflection Activity completed! Press Enter to continue.");
        Console.ReadLine();
    }
}

class Writing : Activity
{
    private List<string> prompts = new List<string> {"Who are the people that appreciate you the most? Why do you think that is?", 
                                                     "Make a list of your personal strengths.",
                                                     "Write about a difficult experience you had this week.",
                                                     "Who is a personal hero of yours? Why?"};
    public Writing()
    {
        Console.Clear();
        bool validInput;
        int time_length;

        do 
        {
            Console.WriteLine("How long (in seconds) would you like to write for?");
            string userInput = Console.ReadLine();
            validInput = int.TryParse(userInput, out time_length);

            if (!validInput)
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid integer.");

        } while (!validInput);

        _activityDuration = time_length;
    }

    public override void Play()
    {
        Console.Clear();

        Random rand = new Random();
        int randomIndex = rand.Next(0, prompts.Count);

        Console.WriteLine("Writing Activity");
        LoadingAnimation(prompts[randomIndex]); // Using countdown timer instead of loading animation
        Console.Clear();
        Console.WriteLine("Writing Activity completed! Press [Enter] to continue.");
        Console.ReadLine();
    }
}