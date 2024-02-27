using System;

public class Resume
{
    public string _name;
    // Initilize a new List before I can use it.
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // use custom data type "Job" in thisloop.
        foreach (Job job in _jobs)
        {
            // This calls the Display method on each job
            job.Display();
        }


    }
}