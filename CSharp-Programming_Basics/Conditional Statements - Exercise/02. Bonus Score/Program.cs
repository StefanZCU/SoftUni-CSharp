//Бонус точки

//Дадено е цяло число – начален брой точки.
//Върху него се начисляват бонус точки по правилата, описани по-долу.
//Да се напише програма, която пресмята бонус точките, които получава числото и общия брой точки (числото + бонуса).

//•	Ако числото е до 100 включително, бонус точките са 5.
//•	Ако числото е по-голямо от 100, бонус точките са 20% от числото.
//•	Ако числото е по-голямо от 1000, бонус точките са 10% от числото.

//•	Допълнителни бонус точки (начисляват се отделно от предходните):

// За четно число -> + 1 т.
//	За число, което завършва на 5 -> + 2 т.



using System;

internal class Program
{
    static void Main()
    {
        int initialPoints = int.Parse(Console.ReadLine());
        double bonusPoints = 0.0;
        double totalPoints = 0.0;

        if (initialPoints <= 100)
        {
            if ((initialPoints % 2) == 0)
            {
                bonusPoints++;
            }
            else if ((initialPoints % 5) == 0)
            {
                bonusPoints += 2.0;
            }

            bonusPoints += 5.0;
            totalPoints = initialPoints + bonusPoints;

            Console.WriteLine(bonusPoints);
            Console.WriteLine(totalPoints);
        }

        else if (initialPoints < 1000)
        {
            bonusPoints = initialPoints * 0.2;
            if ((initialPoints % 2) == 0)
            {
                bonusPoints++;
            }
            else if ((initialPoints % 5) == 0)
            {
                bonusPoints += 2.0;
            }
       
            totalPoints = initialPoints + bonusPoints;

            Console.WriteLine(bonusPoints);
            Console.WriteLine(totalPoints);

        }

        else
        {
            bonusPoints = initialPoints * 0.1;
            if ((initialPoints % 2) == 0)
            {
                bonusPoints++;
            }
            else if ((initialPoints % 5) == 0)
            {
                bonusPoints += 2.0;
            }

            totalPoints = initialPoints + bonusPoints;

            Console.WriteLine(bonusPoints);
            Console.WriteLine(totalPoints);
        }
    }
}

