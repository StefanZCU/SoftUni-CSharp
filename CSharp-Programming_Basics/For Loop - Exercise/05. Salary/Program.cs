using System;

namespace _05._Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // брой отворени табове
            int n = int.Parse(Console.ReadLine());
            //заплата
            int salary = int.Parse(Console.ReadLine());
            //пускаме цикъла, който да се върти от първия таб до последния включително
            string site;
            for (int i = 1; i <= n; i++)
            {
                // => за всеки таб четем името на сайта
                site = Console.ReadLine();
                // => ако сайта е facebook => глоба 150 лв.
                if (site == "Facebook")
                {
                    salary -= 150;
                }
                // ако е instagram => глоба 100 лв.
                else if (site == "Instagram")
                {
                    salary -= 100;
                }
                // ако е reddit => глоба 50 лв.
                else if (site == "Reddit")
                {
                    salary -= 50;
                }
                // след глобата проверяваме дали заплата е >= на заплатата
                // ако глобата е >= на заплатата спираме да четем повече сайтове и заплата е свършила
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }


            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }

            // проверяваме дали е останала някаква заплата
            // ако е: колко пари са останали

        }
    }
}
