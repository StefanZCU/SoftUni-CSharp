using System;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            bool flag = true;

            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        if (char.IsLetterOrDigit(username[i]))
                        {
                            continue;
                        }
                        else if (username[i] == '_' || username[i] == '-')
                        {
                            continue;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    flag = false;
                }
                
                if (flag)
                {
                    Console.WriteLine(username);
                }

                flag = true;
            }
        }
    }
}
