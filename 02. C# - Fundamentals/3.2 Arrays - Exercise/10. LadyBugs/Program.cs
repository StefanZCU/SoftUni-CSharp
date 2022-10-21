using System;
using System.Linq;
using System.Net.Http.Headers;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * (1)
            1. Make empty field XXX
            2. Find whether initial index can be placed on field XXX
            3. If it can be placed, place ladybugs XXX
            
                (2)
            1. Read commands from Console.
            2. Seperate numbers and words from command ex. (1 right 1) -> (1, "right", 1)
            3. Use first index to find if there is a ladybug -> if there isn't, read next line
            4. If there is, check direction and move acccordingly
            5. If there is a ladybug where the command has to land, move it again the same distance
            6. If it lands outside of field, delete it
            7.If command is end -> print in format ex. (0 1 0)

            */



            int n = int.Parse(Console.ReadLine());
            int[] sizeField = new int[n];

            int[] initialLadyBugs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            foreach (int index in initialLadyBugs)
            {
                if (index >= 0 && index < sizeField.Length)
                {
                    sizeField[index] = 1;
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int ladyBugIndex = int.Parse(cmdArgs[0]);
                string direction = cmdArgs[1];
                int numMoves = int.Parse(cmdArgs[2]);

                if (ladyBugIndex < 0 || ladyBugIndex >= sizeField.Length)
                {
                    continue;
                }

                if (sizeField[ladyBugIndex] == 0)
                {
                    continue;
                }

                if (direction == "right")
                {
                    //find ladybug on field and add to it the nummoves
                    //if after addition, index is equal to 0, place ladybug and continue
                    //else add nummoves to ladybugindex and repeat
                    //maybe automatically replace start position with 0 before moving it, if it ends out of scope, do nothing and continue
                    sizeField[ladyBugIndex] = 0;

                    while (ladyBugIndex <= sizeField.Length)
                    {

                        if ((ladyBugIndex + numMoves < sizeField.Length))
                        {
                            if (sizeField[ladyBugIndex + numMoves] == 0)
                            {
                                sizeField[ladyBugIndex + numMoves] = 1;
                                break;
                            }
                            else
                            {
                                ladyBugIndex += numMoves;
                            }
                        }
                        else
                        {
                            ladyBugIndex += numMoves;
                        }
                        
                    }

                }

                else if (direction == "left")
                {
                    sizeField[ladyBugIndex] = 0;

                    while (ladyBugIndex >= 0)   
                    {

                        if (ladyBugIndex - numMoves >= 0)
                        {
                            if (sizeField[ladyBugIndex - numMoves] == 0)
                            {
                                sizeField[ladyBugIndex - numMoves] = 1;
                                break;
                            }
                            else
                            {
                                ladyBugIndex -= numMoves;
                            }
                        }
                        else
                        {
                            ladyBugIndex -= numMoves;
                        }
                        
                    }
                }


            }

            Console.WriteLine(String.Join(" ", sizeField));

        }
    }
}
