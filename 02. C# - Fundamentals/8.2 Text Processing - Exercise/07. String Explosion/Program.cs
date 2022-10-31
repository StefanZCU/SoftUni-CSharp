using System;
using System.Text;

namespace _07._String_Explosion
{
    internal class Program
    {
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            sb.Append(Console.ReadLine());
            int index = 0;
            while (index < sb.Length - 1)
            {
                if (sb[index] == '>' && char.IsDigit(sb[index + 1]))
                {
                    StringBoom(index, int.Parse(sb[index + 1].ToString()));
                }

                index++;
            }

            Console.WriteLine(sb);

            static void StringBoom(int index, int strength)
            {
                index++;

                for (int i = strength; i > 0; i--)
                {
                    if (index >= sb.Length)
                    {
                        return;
                    }

                    if (sb[index] != '>')
                    {
                        sb.Remove(index, 1);

                    }
                    else
                    {
                        i += int.Parse(sb[index + 1].ToString()) + 1;
                        index++;
                    }
                }
            }
        }
    }
}
