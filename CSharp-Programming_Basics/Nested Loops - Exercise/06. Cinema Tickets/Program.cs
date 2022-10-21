using System;

namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentTicketCounter = 0;
            int standardTicketCounter = 0;
            int kidTicketCounter = 0;
            double totalTicketCounter = 0.0;

            while (true)
            {
                string command = Console.ReadLine();

                double studentTicketPercent = studentTicketCounter / totalTicketCounter * 100.0;
                double standardTicketPercent = standardTicketCounter / totalTicketCounter * 100.0;
                double kidTicketPercent = kidTicketCounter / totalTicketCounter * 100.0;

                if (command == "Finish")
                {
                    Console.WriteLine($"Total tickets: {totalTicketCounter}");
                    Console.WriteLine($"{studentTicketPercent:F2}% student tickets.");
                    Console.WriteLine($"{standardTicketPercent:F2}% standard tickets.");
                    Console.WriteLine($"{kidTicketPercent:F2}% kids tickets.");
                    break;
                }

                int freeSeats = int.Parse(Console.ReadLine());

                for (double i = 0.0; i <= freeSeats; i++)
                {
                    string typeOfTicket = Console.ReadLine();


                    if (typeOfTicket == "student")
                    {
                        studentTicketCounter++;
                    }
                    else if (typeOfTicket == "standard")
                    {
                        standardTicketCounter++;
                    }
                    else if (typeOfTicket == "kid")
                    {
                        kidTicketCounter++;
                    }


                    double percentFull = (i + 1) / freeSeats * 100.0;

                    if (typeOfTicket == "End")
                    {
                        percentFull = i / freeSeats * 100.0;
                        Console.WriteLine($"{command} - {percentFull:F2}% full.");
                        break;
                    }

                    totalTicketCounter++;

                    if (percentFull == 100.0)
                    {
                        Console.WriteLine($"{command} - {percentFull:F2}% full.");
                        break;
                    }
                }
            }
        }
    }
}
