using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            this.shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        IReadOnlyCollection<Shoe> Shoes => shoes;
        public int Count => this.shoes.Count;

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


        public Shoe GetShoeBySize(double size) => this.shoes.FirstOrDefault(s => s.Size == size);

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> listToReturn = new List<Shoe>();
            foreach (Shoe shoe in this.shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    listToReturn.Add(shoe);
                }
            }
            return listToReturn;
        }

        public int RemoveShoes(string material)
        {
            int removedShoes = 0;

            for (int i = 0; i < shoes.Count; i++)
            {
                if (shoes[i].Material == material.ToLower())
                {
                    shoes.RemoveAt(i--);
                    removedShoes++;
                }
            }

            return removedShoes;
        }

        public string AddShoe(Shoe shoe)
        {
            if (this.StorageCapacity == this.shoes.Count)
            {
                return "No more space in the storage room.";
            }

            this.shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }
    }
}
