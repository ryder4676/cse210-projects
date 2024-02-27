using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the DisplayMessage function
        DisplayMessage();
        // Call the DisplayPersonalMessage function and save the return value in a variable
        string userName = DisplayPersonalMessage();
        // Call the GetInteger function and save the return value in a variable
        int userNumber = GetInteger();
        // Call the SquaredNumber function with the user's number and save the result in a variable
        int squaredNumber = SquaredNumber(userNumber);
            // Call the DisplayNumberSquared function with the user's name and squared number
        DisplayNumberSquared(userName, squaredNumber);


    }
    // Function to display a welcome message
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    // Function to prompt the user for their name and return it
    static string DisplayPersonalMessage()
    {
        Console.Write("Please Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    // Function to prompt the user for their favorite number and return it
    static int GetInteger()
    {
        Console.WriteLine("What is your favorite number? ");
        string numberInput = Console.ReadLine();
        int userNumber = int.Parse(numberInput);
        return userNumber;
    }
     // Function to square a given number and return the result
    static int SquaredNumber(int userNumber)
    {
        return userNumber * userNumber;
    }
    // Function to display the user's name and squared number
    static void DisplayNumberSquared(string userName, int SquaredNumber )
    {
        Console.Write($"{userName}, the square of your number is {SquaredNumber}");
    }
}