                                                                                                                                                                                                                                                        //Учебни материали

//Учебната година вече е започнала и отговорничката на 10Б клас - Ани трябва да купи определен брой пакетчета с химикали, пакетчета с маркери, както и препарат за почистване на дъска.
//Тя е редовна клиентка на една книжарница, затова има намаление за нея, което представлява някакъв процент от общата сума.
//Напишете програма, която изчислява колко пари ще трябва да събере Ани, за да плати сметката, като имате предвид следния ценоразпис: 
//⦁	Пакет химикали - 5.80 лв. 
//⦁	Пакет маркери - 7.20 лв. 
//⦁	Препарат - 1.20 лв (за литър)

//Вход

//От конзолата се четат 4 числа:
//⦁	Брой пакети химикали - цяло число в интервала [0...100]
//⦁	Брой пакети маркери - цяло число в интервала [0...100]
//⦁	Литри препарат за почистване на дъска - цяло число в интервала [0…50]
//⦁	Процент намаление - цяло число в интервала [0...100]

//Изход

//Да се отпечата на конзолата колко пари ще са нужни на Ани, за да си плати сметката.



using System;
 

internal class Program
{
    static void Main()
    {
        int packOfPens = int.Parse(Console.ReadLine());
        int packOfMarkers = int.Parse(Console.ReadLine());
        int litres = int.Parse(Console.ReadLine()); 
        decimal percentDiscount = int.Parse(Console.ReadLine()) * 0.01m;

        decimal pens = packOfPens * 5.8m;
        decimal markers = packOfMarkers * 7.2m;
        decimal cleaningSolution = litres * 1.2m;
        decimal discount = percentDiscount * (pens + markers + cleaningSolution);
        decimal price = (pens + markers + cleaningSolution) - discount;
        Console.WriteLine(price);

    }
}

