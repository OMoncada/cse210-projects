using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Show journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Add additional notes to the journal");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.ShowEntries();
                    break;
                case "3":
                    Console.Write("File name to save: ");
                    string fileNameSave = Console.ReadLine();
                    journal.SaveToFile(fileNameSave);
                    break;
                case "4":
                    Console.Write("File name to upload: ");
                    string fileNameLoad = Console.ReadLine();
                    journal.LoadFromFile(fileNameLoad);
                    break;
                case "5":
                    journal.WriteNotes();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }
    }
}