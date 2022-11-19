using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int carsPassed = 0;
            Queue<string> cars = new Queue<string>();
            bool flag = true;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green" && cars.Count != 0)
                {
                    string currentCar = cars.Peek();
                    string passingCar = string.Empty;
                    int counter = 0;

                    for (int i = 0; i < greenLightDuration; i++)
                    {
                        char currentChar = currentCar[counter];
                        passingCar += currentChar;

                        counter++;

                        if (passingCar == currentCar)
                        {
                            cars.Dequeue();
                            carsPassed++;

                            if (i < greenLightDuration && cars.Count != 0)
                            {
                                passingCar = string.Empty;
                                currentCar = cars.Peek();
                                counter = 0;
                            }

                            if (cars.Count == 0)
                            {
                                break;
                            }
                        }
                    }

                    if (passingCar != string.Empty && cars.Count != 0)
                    {
                        int currCarLength = passingCar.Length;

                        for (int j = 0; j < freeWindow; j++)
                        {
                            char currentChar = currentCar[currCarLength];
                            passingCar += currentChar;

                            currCarLength++;

                            if (passingCar == currentCar)
                            {
                                cars.Dequeue();
                                carsPassed++;
                                break;
                            }
                        }

                        if (passingCar != currentCar)
                        {
                            passingCar += currentCar[currCarLength];

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {passingCar.Substring(passingCar.Length - 1, 1)}.");
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            if (flag)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}
