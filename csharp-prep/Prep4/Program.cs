using System;
using System.Globalization;
using System.Transactions;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        List<int> numbers = [];
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = 1;
        int sum = 0;
        int largest = 0;
        do
        {
            Console.WriteLine("Enter number: ");
            string strnumber = Console.ReadLine();
            number = int.Parse(strnumber);
            numbers.Add(number);
            sum += number;
            if (number > largest)
            {
                largest = number;
            }

        } while (number != 0);

        Console.WriteLine("The sum is: {0}.", sum);
        Console.WriteLine("The average is: {0}.", (sum / numbers.Count));
        Console.WriteLine("The largest number is: {0}.", largest);

    }
}