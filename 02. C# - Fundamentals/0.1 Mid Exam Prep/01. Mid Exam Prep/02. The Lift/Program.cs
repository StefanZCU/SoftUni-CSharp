using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPeopleForLift = int.Parse(Console.ReadLine());
            List<int> stateOfLift = Console.ReadLine().Split().Select(int.Parse).ToList();


            for (int i = 0; i < stateOfLift.Count; i++)
            {
                for (int j = stateOfLift[i]; j < 4; j++)
                {
                    if (numPeopleForLift > 0)
                    {
                        stateOfLift[i]++;
                        numPeopleForLift--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            int counter = 0;

            foreach (int item in stateOfLift)
            {
                if (item == 4)
                {
                    counter++;
                }
            }
            if (numPeopleForLift > 0)
            {
                Console.WriteLine($"There isn't enough space! {numPeopleForLift} people in a queue!");
                Console.WriteLine(String.Join(" ", stateOfLift));
            }
            else if (counter == stateOfLift.Count)
            {
                Console.WriteLine(String.Join(" ", stateOfLift));
            }
            else if (counter < stateOfLift.Count)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(" ", stateOfLift));
            }

        }
    }
}