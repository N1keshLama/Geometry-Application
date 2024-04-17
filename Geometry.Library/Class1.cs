namespace Geometry.Library;

public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}

public class Square : IShape
{
    private double Size;

    public Square(double Size)
    {
        this.Size = Size;
    }

    public double CalculateArea()
    {
        return Size * Size;
    }

    public double CalculatePerimeter()
    {
        return 4 * Size;
    }
}

