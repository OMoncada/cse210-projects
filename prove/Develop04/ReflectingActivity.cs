using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectingActivity : Activity
{
    // Attributes 
    private List<string> _promptList = new List<string>
    {
        "Think about a time when you are facing a major challenge in your life.",
        "Think about a time when you felt especially grateful for something or someone in your life.",
        "Think about a time when you made a difficult decision.",
        "Think about a time when you felt really proud of yourself.",
        "Think about a goal or dream that you have pursued for a long time."
    };
    private List<string> _questionList = new List<string>
    {
        "How do you think this experience has helped you grow as a person?",
        "What specific aspect of this experience inspires you to move forward in life?",
        "What was the most significant impact this experience had on your life?",
        "Can you describe the process that follows from the beginning to the end of this experience?",
        "Have you had any other similar experiences that taught you something valuable?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What was your motivation?"
    };
    private List<string> _useQuestionsList = new List<string>();

    private string _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    // Constructors
    public ReflectingActivity(string activityName, int activityTime) : base(activityName, activityTime)
    {

    }
    
    // Methods
    public void GetActivityDescription()
    {
        Console.WriteLine(_description);
    }
    
    private string GetRandomPrompt()
    {
        var random = new Random();
        int index = random.Next(_promptList.Count);
        return _promptList[index];
    }
    
    private string GetRandomQuestion()
    {
        var random = new Random();
        int index = random.Next(_useQuestionsList.Count);
        return _useQuestionsList[index];
    }
    
    public void ShowPrompt(int seconds)
    {
        Console.WriteLine();  //insert blank line to start
        var prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine($"\nWhen you have something in mind, press enter to continue.");

        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Enter)
        {
            ShowQuestion(seconds);
        }
    }
    
    public void ShowQuestion(int seconds)
    {
        _useQuestionsList.AddRange(_questionList); //creates a new list that can be destroyed each time.
        Spinner spinner = new Spinner();
        Console.WriteLine($"\nNow ponder on each of the following questions as they relate to this experience.");
        CountDown(8);
        Console.Clear();
        Stopwatch timer = new Stopwatch();
        timer.Start();
        while (timer.Elapsed.TotalSeconds < seconds)
        {
            if (_useQuestionsList.Count != 0)
            {
                var question = GetRandomQuestion();
                Console.Write($"\n>> {question}  ");
                _useQuestionsList.Remove(question);  //removes question from list so it can not be used again
            }
            spinner.ShowSpinner();
        }
        timer.Stop();
    }
}
