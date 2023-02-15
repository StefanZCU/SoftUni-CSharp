using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int mealsEaten = 0;

            while (meals.Any() && caloriesPerDay.Any())
            {
                var calories = meals.Peek() switch
                {
                    "salad" => 350,
                    "soup" => 490,
                    "pasta" => 680,
                    "steak" => 790,
                    _ => 0
                };

                if (caloriesPerDay.Peek() > calories)
                {
                    caloriesPerDay.Push(caloriesPerDay.Pop() - calories);
                    meals.Dequeue();
                }
                else if (caloriesPerDay.Peek() == calories)
                {
                    caloriesPerDay.Pop();
                    meals.Dequeue();
                }
                else
                {
                    int caloriesLeftOver = calories - caloriesPerDay.Peek();
                    meals.Dequeue();
                    caloriesPerDay.Pop();

                    if (caloriesPerDay.Any())
                    {
                        caloriesPerDay.Push(caloriesPerDay.Pop() - caloriesLeftOver);
                    }
                }

                mealsEaten++;
            }

            Console.WriteLine(meals.Any()
                ? $"John ate enough, he had {mealsEaten} meals.\nMeals left: {string.Join(", ", meals)}."
                : $"John had {mealsEaten} meals.\nFor the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
        }
    }
}
