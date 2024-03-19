using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("George Geezman", "How to program in C#");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Ninka Inka", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeWorkList());

        WritingAssignment a3 = new WritingAssignment("Potter Stumpy", "Programming", "How to write in C#");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());

    }
}