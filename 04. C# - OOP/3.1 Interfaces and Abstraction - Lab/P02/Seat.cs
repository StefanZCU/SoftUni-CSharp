using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; }
        public string Color { get; }
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
                .AppendLine($"{Color} {nameof(Seat)} {Model}")
                .AppendLine(Start())
                .AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
