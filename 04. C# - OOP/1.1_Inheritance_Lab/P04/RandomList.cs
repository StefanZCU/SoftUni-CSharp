namespace CustomRandomList
{
    using System;

    public class RandomList : List<string>
    {
        private readonly Random _random;

        public RandomList()
        {
            _random = new Random();
        }

        public string RandomString()
        {
            var index = _random.Next(0, Count);
            var element = this[index];
            RemoveAt(index);
            return element;
        }
    }
}
