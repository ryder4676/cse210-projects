using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        List<int> numbers = new List<int>();  // Create a list to store numbers

        while(true)
        {
            Console.Write("Enter number: ");
            string numbersList = Console.ReadLine();
            int inputNumber = int.Parse(numbersList);  // Parse user input to an integer

            if(inputNumber == 0)
            {
                break;  // Break out of the loop when user enters 0
            }
            numbers.Add(inputNumber);  // Add the entered number to the list
        }

        int numbersSum = numbers.Sum();  // Calculate the sum of all numbers in the list
        double numbersAvg = numbers.Average();  // Calculate the average of all numbers in the list
        int largestNumber = numbers.Max();  // Find the largest number in the list
        // int smallPositive = number  // (Commented out) Variable for storing the smallest positive number

        Console.WriteLine($"The sum of all numbers is: {numbersSum}");
        Console.WriteLine($"The average of all numbers is: {numbersAvg}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        // Console.WriteLine($"The smallest positive number is: {smallPositive}")  // (Commented out) Display the smallest positive number
        // Console.Write("Entered numbers are: ");
        // foreach (int number in numbers)
        // {
        //     Console.Write($"{number},");  // (Commented out) Display entered numbers using a loop
        // }
    }
}
