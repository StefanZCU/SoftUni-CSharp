using System;

namespace _06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int numLines = int.Parse(Console.ReadLine());

            //int balanceOne = 0;
            //int balanceTwo = 0;

            //int consecutive = 0;
            //bool flag = false;

            //for (int i = 1; i <= numLines; i++)
            //{
            //    string input = Console.ReadLine();

            //    if (input == "(")
            //    {
            //        balanceOne++;
            //        consecutive++;

            //        if (consecutive > 1)
            //        {
            //            flag = true;
            //        }
            //    }
            //    else if (input == ")")
            //    {
            //        balanceTwo++;
            //        consecutive = 0;
            //    }
            //}

            //if (flag)
            //{
            //    Console.WriteLine("UNBALANCED");
            //}
            //else if (balanceOne == balanceTwo)
            //{
            //    Console.WriteLine("BALANCED");
            //}
            //else
            //{
            //    Console.WriteLine("UNBALANCED");
            //}

            int n = int.Parse(Console.ReadLine());

            bool isBalanced = true;
            bool openedBracket = false;

            for (int line = 0; line < n; line++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    if (openedBracket)
                    {
                        isBalanced = false;
                    }
                    else
                    {
                        openedBracket = true;
                    }
                    
                }
                else if (input == ")")
                {
                    if (openedBracket)
                    {
                        openedBracket = false;
                    }
                    else
                    {
                        isBalanced = false;
                    } 
                        
                        
                }
            }

            if (openedBracket)
            {
                isBalanced = false;
            }
            Console.WriteLine(isBalanced ? "BALANCED" : "UNBALANCED");
        }
    }
}
