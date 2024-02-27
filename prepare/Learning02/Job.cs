using System;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // add a method (member function) to display the job details. This method should not have any parameters and does not need to return anything.
    // This method should display the job details on the screen in the correct format. 
    // Remember that the method can access the member variables directly, without needing them to be passed into it.
    public void Display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }

}