//Магазин за детски играчки

//Петя има магазин за детски играчки. Тя получава голяма поръчка, която трябва да изпълни. С парите, които ще спечели иска да отиде на екскурзия. 

//Цени на играчките:

//•	Пъзел - 2.60 лв.
//•	Говореща кукла - 3 лв.
//•	Плюшено мече - 4.10 лв.
//•	Миньон - 8.20 лв.
//•	Камионче - 2 лв.

//Ако поръчаните играчки са 50 или повече магазинът прави отстъпка 25% от общата цена. От спечелените пари Петя трябва да даде 10% за наема на магазина. Да се пресметне дали парите ще ѝ стигнат да отиде на екскурзия.

//Вход

//От конзолата се четат 6 реда:
//1.Цена на екскурзията - реално число в интервала [1.00 … 10000.00]
//2.Брой пъзели - цяло число в интервала [0… 1000]
//3.Брой говорещи кукли - цяло число в интервала [0 … 1000]
//4.Брой плюшени мечета - цяло число в интервала [0 … 1000]
//5.Брой миньони - цяло число в интервала [0 … 1000]
//6.Брой камиончета - цяло число в интервала [0 … 1000]

//Изход

//На конзолата се отпечатва:
//•	Ако парите са достатъчни се отпечатва:
//o "Yes! {оставащите пари} lv left."
//•	Ако парите НЕ са достатъчни се отпечатва:
//o "Not enough money! {недостигащите пари} lv needed."





using System;

internal class Program
{
    static void Main()
    {
        double excursionPrice = double.Parse(Console.ReadLine());
        int puzzleAmount = int.Parse(Console.ReadLine());
        int talkingDollAmount = int.Parse(Console.ReadLine());
        int stuffedBearsAmount = int.Parse(Console.ReadLine());
        int minionsAmount = int.Parse(Console.ReadLine());
        int toytruckAmount = int.Parse(Console.ReadLine());

        double puzzlePrice = puzzleAmount * 2.6;
        double talkingDollPrice = talkingDollAmount * 3.0;
        double stuffedBearsPrice = stuffedBearsAmount * 4.1;
        double minionsPrice = minionsAmount * 8.2;
        double toyTruckPrice = toytruckAmount * 2.0;

        double totalAmount = puzzleAmount + talkingDollAmount + stuffedBearsAmount + minionsAmount + toytruckAmount;
        double totalPrice = puzzlePrice + talkingDollPrice + stuffedBearsPrice + minionsPrice + toyTruckPrice;

        if (totalAmount >= 50)
        {
            double discount = totalPrice * 0.25;
            double priceClient = totalPrice - discount;            
            double profitPetya = priceClient - (priceClient * 0.1);
            if (profitPetya >= excursionPrice)
            {
                profitPetya -= excursionPrice;
                Console.WriteLine($"Yes! {profitPetya:F2} lv left.");
            }
            else
            {
                excursionPrice -= profitPetya;
                Console.WriteLine($"Not enough money! {excursionPrice:F2} lv needed.");
                
            }

        }
        else
        {

            double profitPetyaAfterTax = totalPrice - (totalPrice * 0.1);
            double profitPetya = profitPetyaAfterTax;
            if (profitPetya >= excursionPrice)
            {
                profitPetya -= excursionPrice;
                Console.WriteLine($"Yes! {profitPetya:F2} lv left.");
            }
            else
            {
                excursionPrice -= profitPetya;
                Console.WriteLine($"Not enough money! {excursionPrice:F2} lv needed.");

            }
        }
    }
}

