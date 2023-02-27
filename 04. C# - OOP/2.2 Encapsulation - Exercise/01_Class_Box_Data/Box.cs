using System.Text;

namespace _01_Class_Box_Data
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

        public double SurfaceArea()
        {
            return LateralSurfaceArea() + (2 * Length * Width);
        }

        public double LateralSurfaceArea()
        {

            return (2 * Length * Height) + (2 * Width * Height);
        }

        public double Volume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Surface Area - {this.SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
