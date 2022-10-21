using System;

namespace _07._Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumMusala = 0;
            int sumMonBlanc = 0;
            int sumKilo = 0;
            int sumK2 = 0;
            int sumEverest = 0;
            double totalPeople = 0.0;


            for (int i = 1; i <= n; i++)
            {
                int group = int.Parse(Console.ReadLine());

                totalPeople += group;

                if (group <= 5)
                {
                    sumMusala += group;
                }
                else if (group <= 12)
                {
                    sumMonBlanc += group;
                }
                else if (group <= 25)
                {
                    sumKilo += group;
                }
                else if (group <= 40)
                {
                    sumK2 += group;
                }
                else
                {
                    sumEverest += group;
                }
            }        

            double peopleMusala = sumMusala / totalPeople * 100.0;
            double peopleMonBlanc = sumMonBlanc / totalPeople * 100.0;
            double peopleKilo = sumKilo / totalPeople * 100.0;
            double peopleK2 = sumK2 / totalPeople * 100.0;
            double peopleEverest = sumEverest / totalPeople * 100.0;

            Console.WriteLine($"{peopleMusala:F2}%");
            Console.WriteLine($"{peopleMonBlanc:F2}%");
            Console.WriteLine($"{peopleKilo:F2}%");
            Console.WriteLine($"{peopleK2:F2}%");
            Console.WriteLine($"{peopleEverest:F2}%");
        }
    }
}
