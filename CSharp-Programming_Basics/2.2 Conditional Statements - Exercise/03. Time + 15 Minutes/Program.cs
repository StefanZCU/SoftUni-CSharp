//Време + 15 минути

//Да се напише програма, която чете час и минути от 24-часово денонощие,
//въведени от потребителя и изчислява колко ще е часът след 15 минути.
//Резултатът да се отпечата във формат часове:минути.
//Часовете винаги са между 0 и 23, а минутите винаги са между 0 и 59.
//Часовете се изписват с една или две цифри.
//Минутите се изписват винаги с по две цифри, с водеща нула, когато е необходимо. 





using System;

internal class Program
{
    static void Main(string[] args)
    {
        int initialHour = int.Parse(Console.ReadLine());
        int initialMinute = int.Parse(Console.ReadLine());

        int fifteenMinutesLater = initialMinute + 15;

        if (fifteenMinutesLater >= 60)
        {
            initialHour++;
            fifteenMinutesLater -= 60;

            if (initialHour == 24)
            {
                initialHour = 0;
                if (fifteenMinutesLater < 10)
                {
                    Console.WriteLine($"{initialHour}:0{fifteenMinutesLater}");
                }
                else
                {
                    Console.WriteLine($"{initialHour}:{fifteenMinutesLater}");
                }


            }
            else if (fifteenMinutesLater < 10)
            {
                Console.WriteLine($"{initialHour}:0{fifteenMinutesLater}");
            }
            else
            {
                Console.WriteLine($"{initialHour}:{fifteenMinutesLater}");
            }
        }
        else
        {
            Console.WriteLine($"{initialHour}:{fifteenMinutesLater}"); 
        }

    }
}

