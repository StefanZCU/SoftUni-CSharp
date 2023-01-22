namespace ComputerArchitecture
{
    public class CPU
    {
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public override string ToString()
        {
            return $"{Brand} CPU:\nCores: {Cores}\nFrequency: {Frequency:F1} GHz"
                ;
        }
    }
}
