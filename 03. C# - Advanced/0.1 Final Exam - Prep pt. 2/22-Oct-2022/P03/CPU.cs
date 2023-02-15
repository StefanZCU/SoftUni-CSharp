namespace ComputerArchitecture
{
    using System.Text;

    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get; set; }
        public int Cores { get; set; }

        public double Frequency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{Brand} CPU:")
                .AppendLine($"Cores: {Cores}")
                .AppendLine($"Frequency: {Frequency:F1} GHz");

            return sb.ToString().TrimEnd();
        }
    }
}