using System;

namespace _08._On_Time_for_the_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hourTest = int.Parse(Console.ReadLine());
            int minuteTest = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minuteArrival = int.Parse(Console.ReadLine());

            int testTime = hourTest * 60 + minuteTest;
            int arrivalTime = hourArrival * 60 + minuteArrival;

            if (testTime == arrivalTime)
            {
                Console.WriteLine("On time");
            }
            else if (testTime > arrivalTime)
            {
                if (((testTime - arrivalTime) > 30))
                {
                    int hours = (testTime - arrivalTime) / 60;
                    int minutes = (testTime - arrivalTime) % 60;
                    if (hours == 0)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{minutes} minutes before the start");
                    }
                    else if ((minutes >= 0) && (minutes <= 9))
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{hours}:0{minutes} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{hours}:{minutes} hours before the start");
                    }
                    
                }
                else
                {
                    int minutes = (testTime - arrivalTime) % 60;
                    if ((minutes >= 0) && (minutes <= 9))
                    {
                        Console.WriteLine("On time");
                        Console.WriteLine($"{minutes} minutes before the start");
                    }
                    else
                    {
                        Console.WriteLine("On time");
                        Console.WriteLine($"{minutes} minutes before the start");
                    }
                }
            }
            else if (testTime < arrivalTime)
            {
                if (((arrivalTime - testTime) >= 1))
                {
                    int hours = (arrivalTime - testTime) / 60;
                    int minutes = (arrivalTime - testTime) % 60;

                    if (hours == 0)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{minutes} minutes after the start");
                    }
                    else if ((minutes >= 0) && (minutes <= 9))
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hours}:0{minutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hours}:{minutes} hours after the start");
                    }

                }
                
            }
        }
    }
}
