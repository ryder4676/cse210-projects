using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

// ###################################################################################################################################
// ############################################## ABOVE & BEYOND REQUIREMENTS ########################################################
// ###### Added a time stamp to the RecordEvents methods, this way the program can use the streakGoal class to check if someone ######
// ###### the program can use the streakGoal class to check if someone has done consecutive days of recording atleast one event ######
// ###################################################################################################################################