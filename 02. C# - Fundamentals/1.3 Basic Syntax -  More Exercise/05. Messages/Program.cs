using System;

namespace _05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string word = String.Empty;
            string tempNum = String.Empty;
            int mainNum = 0;
            int offset = 0;
            int letterIndex = 0;
            bool flag = false;

            for (int i = 1; i <= num; i++)
            {
                string numCombination = Console.ReadLine();

                if (numCombination == "0")
                {
                    flag = true;
                    word += " ";
                }

                if (flag == false)
                {
                    int numDigits = numCombination.Length;

                    if (Char.IsDigit(numCombination[0]))
                    {
                        tempNum += numCombination[0];
                        mainNum = int.Parse(tempNum);
                    }

                    offset = (mainNum - 2) * 3;

                    if (mainNum == 8 || mainNum == 9)
                    {
                        offset++;
                    }

                    letterIndex = (offset + numDigits - 1) + 97;

                    char newLetter = (char)letterIndex;

                    word += newLetter;
                    tempNum = "";
                }

                flag = false;

            }

            Console.WriteLine(word);
        }
    }
}
