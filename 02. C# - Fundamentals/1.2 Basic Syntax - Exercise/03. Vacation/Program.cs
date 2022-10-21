using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCnt = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string weekDay = Console.ReadLine();

            double price = 0.0;


            switch (groupType)
            {
                case "Students":

                    switch (weekDay)
                    {
                        case "Friday":

                            price = peopleCnt * 8.45;

                            break;

                        case "Saturday":

                            price = peopleCnt * 9.8;

                            break;

                        case "Sunday":

                            price = peopleCnt * 10.46;

                            break;

                        default:
                            break;
                    }
                    break;

                case "Business":

                    switch (weekDay)
                    {
                        case "Friday":

                            price = peopleCnt * 10.9;

                            break;

                        case "Saturday":

                            price = peopleCnt * 15.6;

                            break;

                        case "Sunday":

                            price = peopleCnt * 16.0;

                            break;

                        default:
                            break;
                    }
                    break;

                case "Regular":

                    switch (weekDay)
                    {
                        case "Friday":

                            price = peopleCnt * 15.0;

                            break;

                        case "Saturday":

                            price = peopleCnt * 20.0;

                            break;

                        case "Sunday":

                            price = peopleCnt * 22.50;

                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }

            if (groupType == "Students" && peopleCnt >= 30)
            {
                price = price - (price * 0.15);
            }

            if (groupType == "Business" && peopleCnt >= 100)
            {
                if (weekDay == "Friday")
                {
                    price = price - (10.9 * 10);
                }
                else if (weekDay == "Saturday")
                {
                    price = price - (15.6 * 10);
                }
                else if (weekDay == "Sunday")
                {
                    price = price - (16.0 * 10);
                }
            }

            if (groupType == "Regular" && peopleCnt >= 10 && peopleCnt <= 20)
            {
                price = price - (price * 0.05);
            }

            Console.WriteLine($"Total price: {price:F2}");

        }
    }
}
