//Доставка на храна

//Ресторант отваря врати и предлага няколко менюта на преференциални цени: 
//⦁	Пилешко меню –  10.35 лв. 
//⦁	Меню с риба – 12.40 лв. 
//⦁	Вегетарианско меню  – 8.15 лв. 

//Напишете програма, която изчислява колко ще струва на група хора да си поръчат храна за вкъщи.
//Групата ще си поръча и десерт, чиято цена е равна на 20% от общата сметка (без доставката). 
//Цената на доставка е 2.50 лв и се начислява най-накрая.  

//Вход

//От конзолата се четат 3 реда:
//⦁	Брой пилешки менюта – цяло число в интервала [0 … 99]
//⦁	Брой менюта с риба – цяло число в интервала [0 … 99]
//⦁	Брой вегетариански менюта – цяло число в интервала [0 … 99]

//Изход

//Да се отпечата на конзолата един ред:  "{цена на поръчката}"







using System;

internal class Program
{
    static void Main(string[] args)
    {
        double numberChickenMenu = double.Parse(Console.ReadLine()) * 10.35;
        double numberFishMenu = double.Parse(Console.ReadLine()) * 12.4;
        double numberVegetarianMenu = double.Parse(Console.ReadLine()) * 8.15;

        double total = numberChickenMenu + numberFishMenu + numberVegetarianMenu;

        double dessert = (total) * 0.2;
        double price = total + dessert + 2.5;

        Console.WriteLine(price);

    }
}

