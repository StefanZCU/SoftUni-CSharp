namespace P01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> conqueredPeaks = new Queue<string>();

            Stack<int> foodPortions = new Stack<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse)
                .ToArray());
            Queue<int> stamina = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> peaks = new Dictionary<string, int>()
            {
                { "Vihren", 80},
                { "Kutelo", 90},
                { "Banski Suhodol", 100},
                { "Polezhan", 60},
                { "Kamenitza", 70}
            };

            Queue<string> peakNames = new Queue<string>();

            foreach (var peak in peaks)
            {
                peakNames.Enqueue(peak.Key);
            }

            while (foodPortions.Any() && stamina.Any() && peakNames.Any())
            {
                if (foodPortions.Peek() + stamina.Peek() >= peaks[peakNames.Peek()])
                {
                    conqueredPeaks.Enqueue(peakNames.Dequeue());
                }

                foodPortions.Pop();
                stamina.Dequeue();
            }

            Console.WriteLine(peakNames.Any()
                ? "Alex failed! He has to organize his journey better next time -> @PIRINWINS"
                : "Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");

            if (!conqueredPeaks.Any()) return;
            Console.WriteLine("Conquered peaks:");
            Console.WriteLine(string.Join("\n", conqueredPeaks));
        }
    }
}
