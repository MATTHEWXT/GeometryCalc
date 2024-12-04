namespace GeometryCalc
{
    public interface IShape
    {
        double CalculateArea();
    }

    public interface IShapeProperties
    {
        bool IsRightTriangle();
    }

    public class AreaCalculator
    {
        public double CalculateShapeArea(IShape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            return shape.CalculateArea();
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("The radius cannot be less than or equal to zero.");

            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius;
        }
    }

    public class Triangle : IShape, ShapeProperties
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("All sides must be greater than zero.");

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                throw new ArgumentException("The specified sides do not form a triangle.");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            double semiPerimeter = (SideA + SideB + SideC) / 2;

            return Math.Sqrt(semiPerimeter *
                             (semiPerimeter - SideA) *
                             (semiPerimeter - SideB) *
                             (semiPerimeter - SideC));
        }

        public bool IsRightTriangle()
        {
            var sides = new[] { SideA, SideB, SideC };
            Array.Sort(sides);

            return sides[0] * sides[0] + sides[1] * sides[1] == sides[2] * sides[2];
        }
    }
}
