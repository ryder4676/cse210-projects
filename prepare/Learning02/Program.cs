using System;


class Program
{
    static void Main(string[] args)
    {  
      
        Job job1 = new Job();
        job1._jobTitle = "Full-Stack Developer";
        job1._company = "Self Employed";
        job1._startYear = 2003;
        job1._endYear = 2007;

        Job job2 = new Job();
        job2._jobTitle = "Back-End Developer";
        job2._company = "ABC123 Webb";
        job2._startYear = 2007;
        job2._endYear = 2010;
        
                
        // Console.WriteLine($"{job1._company}");
        // Console.WriteLine($"{job2._company}");
        // job1.DisplayJobDetails();
        // job2.DisplayJobDetails();



        Resume myResume = new Resume();
        myResume._name = "Jayson Ronald";
        
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
        }
        // public class Job
        // {
        //     public string _company;
        //     public string _jobTitle;
        //     public int _startYear;
        //     public int _endYear;

        //     public void DisplayJobDetails()
        //     {
        //         Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        //     }  
        // }

        
}