using System;
using System.Linq;
using System.Text;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceKey = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int counter = 0;
            StringBuilder sb = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "find")
            {
                for (int i = 0; i < command.Length; i++)
                {
                    if (counter < sequenceKey.Length)
                    {
                        int currentChar = command[i] - sequenceKey[counter];
                        sb.Append((char)currentChar);
                    }
                    else
                    {
                        counter = 0;
                        int currentChar = command[i] - sequenceKey[counter];
                        sb.Append((char)currentChar);
                    }

                    counter++;
                }

                string word = sb.ToString();
                
                int indexTreasureStart = word.IndexOf('&');
                int indexTreasureEnd = word.LastIndexOf('&');

                int treasureLength = indexTreasureEnd - indexTreasureStart;

                string treasure = word.Substring(indexTreasureStart + 1, treasureLength - 1);

                int indexCoordinateStart = word.IndexOf('<');
                int indexCoordinateEnd = word.IndexOf('>');

                int coordinateLength = indexCoordinateEnd - indexCoordinateStart;

                string coordinate = word.Substring(indexCoordinateStart + 1, coordinateLength - 1);

                Console.WriteLine($"Found {treasure} at {coordinate}");

                sb.Clear();
                counter = 0;
            }
            
        }
    }
}
