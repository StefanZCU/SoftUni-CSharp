
//Конзолен конвертор: USD към BGN

//Напишете програма за конвертиране на щатски долари (USD) в български лева (BGN). Използвайте фиксиран курс между долар и лев: 1 USD = 1.79549 BGN.



using System;
internal class Program
{
    static void Main()
    {
        decimal USD = decimal.Parse(Console.ReadLine());
        decimal BGN = USD * 1.79549m;
        Console.WriteLine(BGN);
    }
}

