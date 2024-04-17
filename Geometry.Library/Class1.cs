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

public class Rectangle : IShape
{
    private double length;
    private double breadth;

    public Rectangle(double length, double breadth)
    {
        this.length = length;
        this.breadth = breadth;
    }

    public double CalculateArea()
    {
        return length * breadth;
    }

    public double CalculatePerimeter()
    {
        return 2 * (length + breadth);
    }
}

