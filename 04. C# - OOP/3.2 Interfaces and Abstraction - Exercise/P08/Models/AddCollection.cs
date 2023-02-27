namespace CollectionHierarchy.Models
{
    public class AddCollection : Collection
    {
        public override int Add(string item)
        {
            base.Add(item);

            return Data.Count - 1;
        }
    }
}
