using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their grade percentage
        Console.Write("What is your grade in percentage? ");
        string gradePercent = Console.ReadLine();
        // Convert the input to an integer
        int g = int.Parse(gradePercent);
        // Variables to store the letter grade and sign
        string letter = "";
        string sign = ""; // Variable to store the sign

         // Determine the letter grade based on the percentage
        if(g >= 90 )
        {
            letter = "A";
        }else if(g >= 80)
        {
            letter = "B";
        }else if(g >= 70)
        {
            letter = "C";
        }else if(g >= 60)
        {
            letter = "D";
        }else if(g <= 59)
        {
            letter = "F";
        }
        // Determine the sign based on the last digit
        int lastDigit = g % 10;
        if(lastDigit >= 7)
        {
            sign = "+";
        } else if(lastDigit < 3)
        {
            sign = "-";
        }

        // Display the final letter grade with sign
        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        // if(g >= 90)
        // {
        //     Console.WriteLine("Your grade is A");
        // }
        // else if(g >= 80)
        // {
        //     Console.WriteLine("Your grade is B");
        // }else if(g >= 70)
        // {
        //     Console.WriteLine("Your grade is C");
        // }else if(g >= 60)
        // {
        //     Console.WriteLine("Your grade is D");
        // }else if(g <= 59)
        // {
        //     Console.WriteLine("Your grade is F");
        // }

        // Display additional messages based on the grade
        if(g >= 70)
        {
            Console.WriteLine("Great you passed the course!");

        } else if(g <= 69)
        {
            Console.WriteLine("You did not pass the course. Good luck next time.");
        }
    }
}