﻿//Напишете програма, която чете ъгъл в радиани (десетично число) и го преобразува в градуси.
//Използвайте формулата: градус = радиан * 180 / π.
//Числото π в C# програми е достъпно чрез Math.PI.



using System;

internal class Program
{
    static void Main()
    {
        double radian = double.Parse(Console.ReadLine());
        double degrees = radian * (180 / Math.PI);
        Console.WriteLine(degrees);
    }
}

