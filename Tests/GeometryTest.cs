using GeometryCalc;
using Xunit;

public class GeometryLibraryTests
{
    [Fact]
    public void CalculateCircleArea_ShouldReturnCorrectArea_WhenRadiusIsPositive()
    {
        double radius = 5;
        double expectedArea = Math.PI * radius;

        IShape circle = new Circle(radius);
        double actualArea = circle.CalculateArea();

        Assert.Equal(expectedArea, actualArea, 5);
    }

    [Fact]
    public void CalculateCircleArea_ShouldThrowArgumentException_WhenRadiusIsNonPositive()
    {
        double radius = -5;

        var exception = Assert.Throws<ArgumentException>(() => new Circle(radius));

        Assert.Equal("The radius cannot be less than or equal to zero.", exception.Message);
    }

    [Fact]
    public void CalculateTriangleArea_ShouldReturnCorrectArea_WhenSidesAreValid()
    {
        double a = 3, b = 4, c = 5;
        double expectedArea = 6;

        IShape triangle = new Triangle(a, b, c);

        double actualArea = triangle.CalculateArea();

        Assert.Equal(expectedArea, actualArea, 5);
    }

    [Fact]
    public void CalculateTriangleArea_ShouldThrowArgumentException_WhenSidesAreNegative()
    {
        double a = 1, b = 2, c = -1;

        var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));

        Assert.Equal("All sides must be greater than zero.", exception.Message);
    }

    [Fact]
    public void CalculateTriangleArea_ShouldThrowArgumentException_WhenSidesAreInvalid()
    {
        double a = 1, b = 2, c = 10;

        var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));

        Assert.Equal("The specified sides do not form a triangle.", exception.Message);
    }

    [Fact]
    public void IsRightTriangle_ShouldReturnTrue_WhenTriangleIsRight()
    {
        double a = 3, b = 4, c = 5;

        ShapeProperties triangle = new Triangle(a, b, c);

        bool result = triangle.IsRightTriangle();

        Assert.True(result);
    }

    [Fact]
    public void IsRightTriangle_ShouldReturnFalse_WhenTriangleIsNotRight()
    {
        double a = 3, b = 4, c = 6;

        ShapeProperties triangle = new Triangle(a, b, c);

        bool result = triangle.IsRightTriangle();

        Assert.False(result);
    }
}
