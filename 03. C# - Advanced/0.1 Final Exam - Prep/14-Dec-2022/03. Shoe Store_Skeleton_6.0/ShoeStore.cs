using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get;}
        public int Count => Shoes.Count;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);

            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int shoesRemoved = 0;
            List<Shoe> shoesToRemove = new List<Shoe>();

            foreach (var shoe in Shoes)
            {
                if (shoe.Material.ToLower() == material.ToLower())
                {
                    shoesToRemove.Add(shoe);
                    shoesRemoved++;
                }
            }

            foreach (var shoe in shoesToRemove)
            {
                Shoes.Remove(shoe);
            }

            return shoesRemoved;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.Where(x => String.Equals(x.Type, type, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(x => x.Size == size);
        }

        public string StockList(double size, string type)
        {
            List<Shoe> stockList = Shoes.Where(s => s.Size == size && s.Type == type).ToList();

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
