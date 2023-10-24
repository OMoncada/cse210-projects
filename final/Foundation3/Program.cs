using System;

class Program
{
    static void Main(string[] args)
    {
        Address addy = new Address("123 Main St", "Springfield", "IL", "USA");

        LectureEvent lectureEvent = new LectureEvent("John Doe", 50, "Workshop", "Advanced Programming", "May 15", "2:30 PM", addy);
        DisplayEvent(lectureEvent);
        DisplayFullMessage(lectureEvent);
        DisplayStandardMessage(lectureEvent);
        DisplayShortMessage(lectureEvent);

        ReceptionEvent receptionEvent = new ReceptionEvent("RSVP@email.com", "Company Party", "Annual Celebration", "July 20", "6:00 PM", addy);
        DisplayEvent(receptionEvent);
        DisplayFullMessage(receptionEvent);
        DisplayStandardMessage(receptionEvent);
        DisplayShortMessage(receptionEvent);

        OutdoorEvent outdoorEvent = new OutdoorEvent("Partly Cloudy", "Community Picnic", "Park Gathering", "June 5", "12:00 PM", addy);
        DisplayEvent(outdoorEvent);
        DisplayFullMessage(outdoorEvent);
        DisplayStandardMessage(outdoorEvent);
        DisplayShortMessage(outdoorEvent);
    }

    static void DisplayEvent(Event eventObj)
    {
        Console.WriteLine($"***{eventObj.GetType().Name}***");
        Console.WriteLine("___________________________");
    }

    static void DisplayFullMessage(Event eventObj)
    {
        Console.WriteLine("-------------              |");
        Console.WriteLine("Full Message");
        Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯");
        Console.WriteLine(eventObj.GetTitle());
        Console.WriteLine(eventObj.GetDescription());
        Console.WriteLine($"{eventObj.GetDate()} {eventObj.GetTime()}");
        Console.WriteLine(eventObj.GetAddress().FullAddress());

        if (eventObj is LectureEvent lectureEvent)
        {
            Console.WriteLine($"Speaker: {lectureEvent.GetSpeaker()}");
            Console.WriteLine($"Capacity: {lectureEvent.GetCapacity()}");
        }
        else if (eventObj is ReceptionEvent receptionEvent)
        {
            Console.WriteLine($"RSVP: {receptionEvent.GetRsvpEmail()}");
        }
        else if (eventObj is OutdoorEvent outdoorEvent)
        {
            Console.WriteLine($"Weather: {outdoorEvent.GetWeatherForecast()}");
        }

        Console.WriteLine("___________________________|");
    }

    static void DisplayStandardMessage(Event eventObj)
    {
        Console.WriteLine("----------------           |");
        Console.WriteLine("Standard Message");
        Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
        Console.WriteLine(eventObj.GetTitle());
        Console.WriteLine(eventObj.GetDescription());
        Console.WriteLine($"{eventObj.GetDate()} {eventObj.GetTime()}");
        Console.WriteLine(eventObj.GetAddress().FullAddress());
        Console.WriteLine("___________________________|");
    }

    static void DisplayShortMessage(Event eventObj)
    {
        Console.WriteLine("-------------              |");
        Console.WriteLine("Short Message");
        Console.WriteLine("-------------");
        Console.WriteLine(eventObj.GetType().Name);
        Console.WriteLine(eventObj.GetTitle());
        Console.WriteLine(eventObj.GetDate());
        Console.WriteLine("___________________________|");
        Console.WriteLine();
    }
}
