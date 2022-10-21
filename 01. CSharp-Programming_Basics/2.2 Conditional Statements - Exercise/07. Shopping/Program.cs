//Пазаруване

//Петър иска да купи N видеокарти, M процесора и P на брой рам памет. Ако броя на видеокартите е по-голям от този на процесорите получава 15% отстъпка от крайната сметка. Важат следните цени:
//•	Видеокарта – 250 лв./ бр.
//•	Процесор – 35 % от цената на закупените видеокарти/бр.
//•	Рам памет – 10% от цената на закупените видеокарти/бр.
//Да се изчисли нужната сума за закупуване на материалите и да се пресметне дали бюджета ще му стигне.

//Вход

//Входът се състои от четири реда:
//1.Бюджетът на Петър - реално число в интервала [0.0…100000.0]
//2.Броят видеокарти - цяло число в интервала [0…100]
//3.Броят процесори - цяло число в интервала [0…100]
//4.Броят рам памет - цяло число в интервала [0…100]

//Изход

//На конзолата се отпечатва 1 ред, който трябва да изглежда по следния начин:
//•	Ако бюджета е достатъчен:
//"You have {остатъчен бюджет} leva left!"
//•	Ако сумата надхвърля бюджета:
//"Not enough money! You need {нужна сума} leva more!"

//Резултатът да се форматира до втория знак след десетичната запетая.



using System;

internal class Program
{
    static void Main(string[] args)
    {
        double budgetPeter = double.Parse(Console.ReadLine());
        int videoCardNumber = int.Parse(Console.ReadLine());
        int processorNumber = int.Parse(Console.ReadLine());
        int ramNumber = int.Parse(Console.ReadLine());

        double videoCardPrice = videoCardNumber * 250.0;
        double processorPrice = processorNumber * (videoCardPrice * 0.35);
        double ramPrice = ramNumber * (videoCardPrice * 0.1);

        double totalPrice = videoCardPrice + processorPrice + ramPrice;

        if (videoCardNumber > processorNumber)
        {
            double finalPrice = totalPrice - (totalPrice * 0.15);
            if (budgetPeter >= finalPrice)
            {
                budgetPeter -= finalPrice;
                Console.WriteLine($"You have {budgetPeter:F2} leva left!");
            }
            else
            {
                finalPrice -= budgetPeter;
                Console.WriteLine($"Not enough money! You need {finalPrice:F2} leva more!");
            }
        }
        else
        {
            if (budgetPeter >= totalPrice)
            {
                budgetPeter -= totalPrice;
                Console.WriteLine($"You have {budgetPeter:F2} leva left!");
            }
            else
            {
                totalPrice -= budgetPeter;
                Console.WriteLine($"Not enough money! You need {totalPrice:F2} leva more!");
            }
        }
    }
}

