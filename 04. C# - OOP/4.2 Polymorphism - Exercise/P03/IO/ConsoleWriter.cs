﻿namespace P03.IO
{
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string str) => Console.WriteLine(str);
    }
}
