using System.Security.AccessControl;
using System.Text;

namespace P01
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }

                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }

                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }

                height = value;
            }
        }

        private double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        private double LateralSurfaceArea()
        {
           return 2 * length * height + 2 * width * height;
        }

        private double Volume()
        {
            return length * width * height;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"Surface Area - {SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {Volume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
