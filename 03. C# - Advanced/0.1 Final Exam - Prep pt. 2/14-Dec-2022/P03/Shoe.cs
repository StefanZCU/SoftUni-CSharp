namespace ShoeStore
{
    public class Shoe
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        public string Material { get; set; }

        public Shoe(string brand, string type, double size, string material)
        {
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        public override string ToString()
        {
            return $"Size {Size}, {Material} {Brand} {Type} shoe.";
        }
    }
}