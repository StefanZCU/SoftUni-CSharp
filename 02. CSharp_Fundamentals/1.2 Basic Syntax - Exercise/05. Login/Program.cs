using System;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int attempts = 0;
            string user = "";
            bool flag1 = true;
            bool flag2 = false;
            string reverseText = "";

            while (true)
            {
                string text = Console.ReadLine();

                attempts++;

                if (text == reverseText)
                {
                    Console.WriteLine($"User {user} logged in.");
                    break;
                }

                if (attempts == 2)
                {
                    flag2 = true;
                }

                if (attempts > 4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    break;
                }

                if (attempts == 1)
                {
                    char[] cArray = text.ToCharArray();

                    string reverse = String.Empty;

                    for (int i = cArray.Length - 1; i > -1; i--)
                    {
                        reverse += cArray[i];
                        reverseText = reverse;
                    }
                }
                

                if (flag1)
                {
                    flag1 = false;
                    user = text;
                }

                if (flag2)
                {
                    Console.WriteLine($"Incorrect password. Try again.");
                }
            }
            
        }
    }
}

