using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Library;

namespace Geometry.Tests
{
    [TestClass]
    public class SquareTests
    {
        [TestMethod]
        public void TestSquareArea()
        {
            double sideLength = 4;
            var square = new Square(sideLength);
            double area = square.CalculateArea();
            Assert.AreEqual(16, area);
        }

        [TestMethod]
        public void TestSquarePerimeter()
        {
            double sideLength = 4;
            var square = new Square(sideLength);
            double perimeter = square.CalculatePerimeter();
            Assert.AreEqual(16, perimeter);
        }

        [TestClass]
        public class RectangleTests
        {
            [TestMethod]
            public void TestRectangleArea()
            {
                double length = 3;
                double width = 4;
                var rectangle = new Rectangle(length, width);
                double area = rectangle.CalculateArea();
                Assert.AreEqual(12, area);
            }

            [TestMethod]
            public void TestRectanglePerimeter()
            {
                double length = 3;
                double width = 4;
                var rectangle = new Rectangle(length, width);
                double perimeter = rectangle.CalculatePerimeter();
                Assert.AreEqual(14, perimeter);
            }
        }

        [TestClass]
        public class TriangleTests
        {
            [TestMethod]
            public void TestTriangleArea()
            {
                double side1 = 3;
                double side2 = 4;
                double side3 = 5;
                var triangle = new Triangle(side1, side2, side3);
                double area = triangle.CalculateArea();
                Assert.AreEqual(6, area);
            }

            [TestMethod]
            public void TestTrianglePerimeter()
            {
                double side1 = 3;
                double side2 = 4;
                double side3 = 5;
                var triangle = new Triangle(side1, side2, side3);
                double perimeter = triangle.CalculatePerimeter();
                Assert.AreEqual(12, perimeter);
            }
        }
    }
}
