namespace ShoeStore
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public IReadOnlyCollection<Shoe> Shoes => shoes;
        public int Count => shoes.Count;


        public string AddShoe(Shoe shoe)
        {
            if (shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int removedShoes = 0;

            for (int i = 0; i < shoes.Count; i++)
            {
                if (shoes[i].Material != material.ToLower()) continue;
                shoes.RemoveAt(i--);
                removedShoes++;
            }

            return removedShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return shoes.Where(shoe => shoe.Type == type.ToLower()).ToList();
        }

        public Shoe GetShoeBySize(double size)
        {
            return shoes.FirstOrDefault(x => x.Size == size);
        }

        public string StockList(double size, string type)
        {
            List<Shoe> stockList = this.shoes.Where(s => s.Size == size && s.Type == type).ToList();

            StringBuilder sb = new StringBuilder();

            if (stockList.Count == 0)
            {
                sb.AppendLine("No matches found!");
            }
            else
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (Shoe shoe1 in stockList)
                {
                    sb.AppendLine(shoe1.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
