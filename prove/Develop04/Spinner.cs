using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class Spinner
{
    private string[] emoticonParts = new string[] { "\\(^_^)\\", "/(^_^)/" };
    private int currentIndex = 0;

    public void Stopwatch()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        while (timer.Elapsed.TotalSeconds < 10)
        {
            Console.Write("+");
            Thread.Sleep(500);
            Console.Write("\b \b"); // Erase the + character
            Console.Write("-"); // Replace it with the - character
        }
        timer.Stop();
    }

    private void ConsoleSpinner()
    {
        currentIndex = 0;
    }

    public void Turn()
    {
        currentIndex++;
        Console.Write(emoticonParts[currentIndex % emoticonParts.Length]);
        Console.SetCursorPosition(Console.CursorLeft - emoticonParts[0].Length, Console.CursorTop);
    }

    public void ShowSimplePercentage()
    {
        for (int i = 0; i <= 100; i++)
        {
            Console.Write($"\rGet Ready... {i}%   ");
            Thread.Sleep(75);
        }
        Console.Write("\rGet Ready...      ");
    }

    public void ShowSpinner()
    {
        for (int i = 0; i < 50; i++)
        {
            Console.Write(emoticonParts[currentIndex % emoticonParts.Length] + " ");
            currentIndex = (currentIndex + 1) % emoticonParts.Length;
            Console.SetCursorPosition(Console.CursorLeft - (emoticonParts[0].Length + 1), Console.CursorTop);
            Thread.Sleep(150);
        }
    }

    public void ShowSpinnerReady()
    {
        var counter = 0;

        Stopwatch timer = new Stopwatch();
        timer.Start();

        while (timer.Elapsed.TotalMilliseconds < 4000) // Run for 4 seconds
        {
            int left = Math.Max(0, Console.CursorLeft - 15); // Ensures that the position is not negative
            Console.SetCursorPosition(left, Console.CursorTop);

            switch (counter % 4)
            {
                case 0: Console.Write("Get ready... /"); break;
                case 1: Console.Write("Get ready... -"); break;
                case 2: Console.Write("Get ready... \\"); break;
                case 3: Console.Write("Get ready... |"); break;
            }

            counter++;
            Thread.Sleep(75); // Pause of 75 milliseconds

            // Delete the previous line
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.Write(new string(' ', "Get ready... /".Length));

            // Restaura la posición del cursor
            Console.SetCursorPosition(left, Console.CursorTop);
        }

        timer.Stop();

        Console.WriteLine("Get ready...   "); // Restore the line
    }

    public void ShowSpinnerDone()
    {
        Console.WriteLine();
        for (int i = 0; i < 50; i++)
        {
            Console.Write($"Well done!! {emoticonParts[currentIndex % emoticonParts.Length]} ");
            currentIndex = (currentIndex + 1) % emoticonParts.Length;
            Console.SetCursorPosition(Console.CursorLeft - (emoticonParts[0].Length + 13), Console.CursorTop);
            Thread.Sleep(100);
        }
    }
}