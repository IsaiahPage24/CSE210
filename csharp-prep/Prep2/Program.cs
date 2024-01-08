using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What was your grade? (Percentage)\n");
        string GradeInput = Console.ReadLine();
        int Grade = int.Parse(GradeInput);
        string LetterGrade = "K";
        if (Grade >= 90)
        {
            LetterGrade = "A";
        }
        else if (Grade >= 80)
        {
            LetterGrade = "B";
        }
        else if (Grade >= 70)
        {
            LetterGrade = "C";
        }
        else if (Grade >= 60)
        {
            LetterGrade = "D";
        }
        else if (Grade < 60)
        {
            LetterGrade = "F";
        }
        Console.WriteLine($"Your letter grade is {LetterGrade}.");
    }
}