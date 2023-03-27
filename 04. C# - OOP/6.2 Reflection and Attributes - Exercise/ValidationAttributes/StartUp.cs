namespace ValidationAttributes
{
    using System;

    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new(null, -1);

            Console.WriteLine(Validator.IsValid(person));
        }
    }

}
