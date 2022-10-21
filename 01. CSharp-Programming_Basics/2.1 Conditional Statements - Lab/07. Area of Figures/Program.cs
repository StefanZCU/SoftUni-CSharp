//Лица на фигури

//Да се напише програма, в която потребителят въвежда вида и размерите на геометрична фигура и пресмята лицето й.
//Фигурите са четири вида: квадрат(square), правоъгълник(rectangle), кръг(circle) и триъгълник(triangle).
//На първия ред на входа се чете вида на фигурата (текст със следните възможности: square, rectangle, circle или triangle). 

//•	Ако фигурата е квадрат (square): на следващия ред се чете едно дробно число - дължина на страната му
//•	Ако фигурата е правоъгълник (rectangle): на следващите два реда четат две дробни числа - дължините на страните му
//•	Ако фигурата е кръг (circle): на следващия ред чете едно дробно число - радиусът на кръга
//•	Ако фигурата е триъгълник (triangle): на следващите два реда четат две дробни числа - дължината на страната му и дължината на височината към нея

//Резултатът да се закръгли до 3 цифри след десетичната запетая. 



using System;

internal class Program
{
    static void Main(string[] args)
    {
        string shape = Console.ReadLine();

        if (shape == "square")
        {
            double length = double.Parse(Console.ReadLine());
            double area = length * length;
            Console.WriteLine($"{area:F3}");
        }
        else if (shape == "rectangle")
        {
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = length * height;
            Console.WriteLine($"{area:F3}");
        }
        else if (shape == "circle")
        {
            double radius = double.Parse(Console.ReadLine());

            double area = Math.Pow(radius, 2) * Math.PI;
            Console.WriteLine($"{area:F3}");
        }
        else if (shape == "triangle")
        {
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = (length * height) / 2.0;

            Console.WriteLine($"{area:F3}");
        }
    }
}

