﻿namespace P08.Models
{
    using Interfaces;

    public class AddCollection : IAddCollection
    {
        private readonly List<string> data;

        public AddCollection()
        {
            data = new List<string>();
        }

        public int Add(string item)
        {
            data.Add(item);

            return data.Count - 1;
        }
    }
}
