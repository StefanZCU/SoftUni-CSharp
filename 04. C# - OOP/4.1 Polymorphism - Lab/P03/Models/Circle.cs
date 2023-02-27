namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2.0 * Math.PI * radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * (radius * radius);
        }

        public override string Draw()
        {
            return base.Draw() + " Circle";
        }
    }
}
