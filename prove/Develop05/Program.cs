using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Use to convert text to title case
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        GoalManagement goals = new GoalManagement();

        Console.Clear();  // This will clear the console
        Console.Write("\n*** Welcome to the Eternal Quest Program ****\n");

        Console.Write($"\n*** You currently have {goals.GetTotalPoints()} points! ***\n");
        //Call MainMenu
        MainMenu choice = new MainMenu();
        //Call GoalMenu
        GoalMenu goalChoice = new GoalMenu();


        int action = 0;
        while (action != 6)
        // switch case for main menu
        {
            // Ask for user input (1-6)
            action = choice.UserChoice();
            switch (action)
            {
                case 1:
                    // Create New Goal
                    Console.Clear();  // This will clear the console
                    // Ask for user input (1-4)
                    int goalInput = 0;
                    while (goalInput != 5)
                    // switch case for goals menu
                    {
                        goalInput = goalChoice.GoalChoice();
                        switch (goalInput)
                        {
                            case 1:
                                // Simple Goal
                                Console.WriteLine("What is the name of your goal?  ");
                                string name = Console.ReadLine();
                                name = textInfo.ToTitleCase(name);
                                Console.WriteLine("What is a short description of your goal?  ");
                                string description = Console.ReadLine();
                                description = textInfo.ToTitleCase(description);
                                Console.Write("What is the amount of points associated with this goal?  ");
                                int points = int.Parse(Console.ReadLine());
                                SimpleGoal sGoal = new SimpleGoal("Simple Goal:", name, description, points);
                                goals.AddGoal(sGoal);
                                goalInput = 5;
                                break;
                            case 2:
                                // Eternal Goal
                                Console.WriteLine("What is the name of your goal?  ");
                                name = Console.ReadLine();
                                name = textInfo.ToTitleCase(name);
                                Console.WriteLine("What is a short description of your goal?  ");
                                description = Console.ReadLine();
                                description = textInfo.ToTitleCase(description);
                                Console.Write("What is the amount of points associated with this goal?  ");
                                points = int.Parse(Console.ReadLine());
                                EternalGoal eGoal = new EternalGoal("Eternal Goal:", name, description, points);
                                goals.AddGoal(eGoal);
                                goalInput = 5;
                                break;
                            case 3:
                                // Checklist Goal
                                Console.WriteLine("What is the name of your goal?  ");
                                name = Console.ReadLine();
                                name = textInfo.ToTitleCase(name);
                                Console.WriteLine("What is a short description of your goal?  ");
                                description = Console.ReadLine();
                                description = textInfo.ToTitleCase(description);
                                Console.Write("What is the amount of points associated with this goal?  ");
                                points = int.Parse(Console.ReadLine());
                                Console.Write("How many times does this goal need to be accomplished for a bonus?  ");
                                int numberTimes = int.Parse(Console.ReadLine());
                                Console.Write("What is the bonus for accomplishing it that many times?  ");
                                int bonusPoints = int.Parse(Console.ReadLine());
                                ChecklistGoal clGoal = new ChecklistGoal("Check List Goal:", name, description, points, numberTimes, bonusPoints);
                                goals.AddGoal(clGoal);
                                goalInput = 5;
                                break;
                            case 4:
                                // Negative Goal
                                Console.WriteLine("What is the name of your goal?  ");
                                name = Console.ReadLine();
                                name = textInfo.ToTitleCase(name);
                                Console.WriteLine("What is a short description of your goal?  ");
                                description = Console.ReadLine();
                                description = textInfo.ToTitleCase(description);
                                Console.Write("How many points should be subtracted for not meeting this goal?  ");
                                points = int.Parse(Console.ReadLine());
                                NegativeGoal nGoal = new NegativeGoal("Negative Goal:", name, description, points);
                                goals.AddGoal(nGoal);
                                goalInput = 5;
                                break;
                            case 5:
                                // Exit
                                break;
                            default:
                                Console.WriteLine($"\nSorry the option you entered is not valid.");
                                break;
                        }
                    }
                    break;
                case 2:
                    // List Goals
                    Console.Clear();  // This will clear the console
                    Console.Write($"\n*** You currently have {goals.GetTotalPoints()} points! ***\n");
                    goals.ListGoals();
                    break;
                case 3:
                    // Save Goals
                    goals.SaveGoals();
                    break;
                case 4:
                    // Load Goals
                    Console.Clear();  // This will clear the console
                    Console.Write($"\n*** You currently have {goals.GetTotalPoints()} points! ***\n");
                    goals.LoadGoals();
                    break;
                case 5:
                    // Record Event
                    Console.Clear();  // This will clear the console
                    Console.Write($"\n*** You currently have {goals.GetTotalPoints()} points! ***\n");
                    goals.RecordGoalEvent();
                    break;
                case 6:
                    // Quite
                    Console.WriteLine("\nThank you for using the Eternal Quest Program!\n");
                    break;
                default:
                    Console.WriteLine($"\nSorry the option you entered is not valid.");
                    break;
            }
        }
    }
}

//Showing Creativity and Exceeding Requirements
//1- The user selects "Create New Goal" from the main menu and chooses "Negative Goal" in the goal types menu.
//2. The user then provides a name and description for the bad habit goal.
//3. The user also needs to specify the number of points that will be deducted when they fail to meet this goal. This amount is stored in the points variable.
//4. After creating the bad habit goal, it will appear in the list of goals available for the user.
//5. When the user selects the "Record Goal Event" option from the main menu, they will be prompted to choose which of the goals they want to record as unfulfilled.
//6. The system then subtracts the number of points specified in step 3 from the user's total score.
//7. It displays a message indicating that the user has lost points due to not meeting the bad habit goal.
// The "bad habit goals" functionality allows the user to track unwanted behaviors and receive penalties in the form of points when they fail to avoid those bad habits. 
//This feature can be useful for encouraging behavior changes and improving self-discipline. 
//

