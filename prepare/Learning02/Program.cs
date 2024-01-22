using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Del Taco", "Cashier", 1999, 2002);

        Job job2 = new Job("Google", "Head Cashier", 2002, 2008);
        
        Resume r = new Resume();
        r._name = "Isaiah Page";

        r._jobs.Add(job1);
        r._jobs.Add(job2);

        r.Display();
    }
}