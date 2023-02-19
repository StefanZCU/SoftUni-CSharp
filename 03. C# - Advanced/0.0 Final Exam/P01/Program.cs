using System.Data.Common;
using System.Security;

namespace P01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Dictionary<string, int> createdHealingItems = new Dictionary<string, int>
            {
                { "Patch", 0 },
                { "Bandage", 0 },
                { "MedKit", 0 }
            };
            
            while (textiles.Any() && medicaments.Any())
            {
                var sum = textiles.Peek() + medicaments.Peek();
                switch (sum)
                {
                    case 30:
                        createdHealingItems["Patch"]++;
                        medicaments.Pop();
                        break;
                    case 40:
                        createdHealingItems["Bandage"]++;
                        medicaments.Pop();
                        break;
                    case 100:
                        createdHealingItems["MedKit"]++;
                        medicaments.Pop();
                        break;
                    case > 100:
                        createdHealingItems["MedKit"]++;
                        medicaments.Pop();
                        medicaments.Push(medicaments.Pop() + (sum - 100));
                        break;
                    default:
                        medicaments.Push(medicaments.Pop() + 10);
                        break;
                }

                textiles.Dequeue();
            }

            if (!textiles.Any() && !medicaments.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            
            if (!textiles.Any() && medicaments.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            
            if (!medicaments.Any() && textiles.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }

            foreach (var createdHealingItem in createdHealingItems.Where(x => x.Value >= 1).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{createdHealingItem.Key} - {createdHealingItem.Value}");
            }

            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}