using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        RunningActivity running = new RunningActivity(4.8f,"30 Nov", 30);
        activities.Add(running);

        SwimmingActivity swimming = new SwimmingActivity(100,"1 Dec", 25);
        activities.Add(swimming);

        CyclingActivity cycling = new CyclingActivity(5.6f,"2 Dec", 48);
        activities.Add(cycling);

        foreach (Activity activity in activities)
        {
            System.Console.WriteLine(activity.GetSummary());
        }


    }
}