//Румен иска да пребоядиса хола и за целта е наел майстори. Напишете програма, която изчислява разходите за ремонта, предвид следните цени:

//⦁	Предпазен найлон - 1.50 лв. за кв. метър
//⦁	Боя - 14.50 лв. за литър
//⦁	Разредител за боя - 5.00 лв. за литър
//За всеки случай, към необходимите материали, Румен иска да добави още 10% от количеството боя и 2 кв.м. найлон, разбира се и 0.40 лв. за торбички.
//Сумата, която се заплаща на майсторите за 1 час работа, е равна на 30% от сбора на всички разходи за материали.

//Вход

//Входът се чете от конзолата и съдържа точно 4 реда:
//⦁	Необходимо количество найлон (в кв.м.) -цяло число в интервала [1... 100]
//⦁	Необходимо количество боя (в литри) -цяло число в интервала [1…100]
//⦁	Количество разредител(в литри) -цяло число в интервала [1…30]
//⦁	Часовете, за които майсторите ще свършат работата - цяло число в интервала [1…9]

//Изход

//Да се отпечата на конзолата един ред:
//⦁	"{сумата на всички разходи}"




using System;

internal class Program
{
    static void Main()
    {
        int sqmNylon = int.Parse(Console.ReadLine());
        int litresPaint = int.Parse(Console.ReadLine());
        int litresThinner = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());

        double bag = 0.4;
        int numberNylon = sqmNylon + 2;
        double nylon = numberNylon * 1.5;

        double numberPaint = litresPaint * 14.5;
        double tenPercentPaint = numberPaint * 0.1;
        double paint = tenPercentPaint + numberPaint;

        int thinner = litresThinner * 5;

        double totalBeforeWorker = nylon + paint + thinner + bag;
        double thirtyPercent = totalBeforeWorker * 0.3;
        double totalWorker = thirtyPercent * hours;

        double total = totalBeforeWorker + totalWorker;

        Console.WriteLine(total);


    }
}
