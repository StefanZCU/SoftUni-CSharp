namespace CollectionHierarchy.Models
{
    using Interfaces;
    public class Collection : IAddCollection
    {
        protected Collection()
        {
            Data = new List<string>();
        }

        protected List<string> Data { get; }

        public virtual int Add(string item)
        {
            int index = 0;
            Data.Insert(index, item);

            return index;
        }
    }
}
