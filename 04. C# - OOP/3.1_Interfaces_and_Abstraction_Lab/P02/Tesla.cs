using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model { get; }
        public string Color { get; }
        public int Battery { get; }
        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{Color} {nameof(Tesla)} {Model} with {Battery} Batteries")
                .AppendLine(Start())
                .AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
