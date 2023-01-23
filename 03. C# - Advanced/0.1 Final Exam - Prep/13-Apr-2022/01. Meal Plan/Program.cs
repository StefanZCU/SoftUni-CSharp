using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int mealsEaten = 0;

            while (meals.Any() && caloriesPerDay.Any())
            {
                int caloriesPerMeal = 0;

                switch (meals.Peek())
                {
                    case "salad":
                        caloriesPerMeal = 350;
                        break;
                    case "soup":
                        caloriesPerMeal = 490;
                        break;
                    case "pasta":
                        caloriesPerMeal = 680;
                        break;
                    case "steak":
                        caloriesPerMeal = 790;
                        break;
                }

                if (caloriesPerDay.Peek() - caloriesPerMeal > 0)
                {
                    var totalCaloriesForDay = caloriesPerDay.Pop();
                    caloriesPerDay.Push(totalCaloriesForDay - caloriesPerMeal);
                    meals.Dequeue();
                }
                else if (caloriesPerDay.Peek() - caloriesPerMeal == 0)
                {
                    caloriesPerDay.Pop();
                    meals.Dequeue();
                }
                else
                {
                    var caloriesToTransfer = caloriesPerMeal - caloriesPerDay.Pop();
                    meals.Dequeue();
                    if (caloriesPerDay.Any())
                    {
                        var newCalories = caloriesPerDay.Pop() - caloriesToTransfer;
                        caloriesPerDay.Push(newCalories);
                    }
                }

                mealsEaten++;
            }

            if (meals.Any())
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            else
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }

        }
    }
}
