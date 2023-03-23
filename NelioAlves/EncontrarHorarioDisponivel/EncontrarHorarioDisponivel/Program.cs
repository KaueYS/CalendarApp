using System;
using System.Collections.Generic;

namespace FindAvailableTime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(DateTime start, DateTime end)> busyTimes = new List<(DateTime, DateTime)>
            {
                (new DateTime(2022, 1, 1, 9, 0, 0), 
                new DateTime(2022, 1, 1, 10, 0, 0)),
                (new DateTime(2022, 1, 1, 11, 0, 0), 
                new DateTime(2022, 1, 1, 12, 0, 0)),
                (new DateTime(2022, 1, 1, 13, 0, 0), 
                new DateTime(2022, 1, 1, 14, 0, 0))
            };

            Console.WriteLine("Enter the start time of the meeting:");
            DateTime start = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the end time of the meeting:");
            DateTime end = Convert.ToDateTime(Console.ReadLine());

            for (int i = 0; i < busyTimes.Count; i++)
            {
                if (start >= busyTimes[i].end)
                {
                    if (i == busyTimes.Count - 1 || end <= busyTimes[i + 1].start)
                    {
                        Console.WriteLine("The meeting can be scheduled at the requested time.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("The requested time conflicts with a previously scheduled meeting.");
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
