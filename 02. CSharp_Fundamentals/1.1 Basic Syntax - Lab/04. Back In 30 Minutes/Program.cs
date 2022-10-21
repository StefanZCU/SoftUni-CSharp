using System;

namespace _04._Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());

            int totalTime = (hour * 60) + minute;
            int thirtyMinutes = totalTime + 30;

            double newHour = Math.Floor((double)thirtyMinutes / 60.0);
            int newMinutes = thirtyMinutes % 60;


            if (newHour == 24)
            {
                newHour = 0;
            }

            if (newMinutes <= 9)
            {
                Console.WriteLine($"{newHour}:0{newMinutes}");
            }
            else
            {
                Console.WriteLine($"{newHour}:{newMinutes}");
            }
        }
    }
}
