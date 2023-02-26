using System.Text;

namespace P01
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => _length;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }

                _length = value;
            }
        }

        public double Width
        {
            get => _width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }

                _width = value;
            }
        }

        public double Height
        {
            get => _height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }

                _height = value;
            }
        }

        public double SurfaceArea()
        {
            return LateralSurfaceArea() + 2 * Length * Width;
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Length * Height * Width;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Surface Area - {SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {Volume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
