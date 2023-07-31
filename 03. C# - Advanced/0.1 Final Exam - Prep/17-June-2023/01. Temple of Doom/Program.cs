namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> substances = new(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<int> challenges = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool found = false;

            while (tools.Any() && substances.Any() && challenges.Any())
            {
                int toolAndSubstance = tools.Peek() * substances.Peek();

                for (int i = 0; i < challenges.Count; i++)
                {
                    if (challenges[i] != toolAndSubstance) continue;
                    tools.Dequeue();
                    substances.Pop();
                    challenges.RemoveAt(i);
                    found = true;
                    break;
                }

                if (found)
                {
                    found = false;
                    continue;
                }

                tools.Enqueue(tools.Dequeue() + 1);

                if (substances.Peek() - 1 > 0)
                {
                    substances.Push(substances.Pop() - 1);
                }
                else
                {
                    substances.Pop();
                }

                found = false;

            }

            Console.WriteLine(challenges.Any()
                ? "Harry is lost in the temple. Oblivion awaits him."
                : "Harry found an ostracon, which is dated to the 6th century BCE."
                );

            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }
            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }
            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}
