namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public string RandomString()
        {
            random = new Random();
            var stringToRemove = this[random.Next(0, Count)];
            Remove(stringToRemove);
            return stringToRemove;
        }
    }
}
