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

public class Triangle : IShape
{
    private double firstSide;
    private double secondSide;
    private double thirdSide;

    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        this.firstSide = firstSide;
        this.secondSide = secondSide;
        this.thirdSide = thirdSide;
    }

    public double CalculateArea()
    {
        ///Using the formula of Heron's to calculate the area of triangle
        double SA = (firstSide + secondSide + thirdSide) / 2;
        return Math.Sqrt(SA * (SA - firstSide) * (SA - secondSide) * (SA - thirdSide));
    }

    public double CalculatePerimeter()
    {
        return firstSide + secondSide + thirdSide;
    }
}
