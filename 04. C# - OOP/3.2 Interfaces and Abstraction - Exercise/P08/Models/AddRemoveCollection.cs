namespace CollectionHierarchy.Models
{
    using Interfaces;

    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public virtual string Remove()
        {
            string item = Data[^1];
            Data.RemoveAt(Data.Count - 1);

            return item;
        }
    }
}
