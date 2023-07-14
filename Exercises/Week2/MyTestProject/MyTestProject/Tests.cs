using MyTestProject;
using NUnit.Framework;
using System;

namespace Shapes
{
    [TestFixture]
    class ShapeTests
    {
        /*
            CIRCLE TESTS
        */

        // Helper method to generate a circle
        private Circle generateCircle()
        {
            Circle circle = new Circle();
            return circle;
        }

        [TestCase(1.0, 3.14)]
        [TestCase(2.0, 12.57)]
        [TestCase(0.5, 0.79)]
        public void Calculate_Circle_Area_With_Valid_Input(double radius, double expectedArea)
        {
            // Arrange
            Circle circle = generateCircle();

            // Act
            double actual = circle.Area(radius);

            // Assert
            Assert.AreEqual(expectedArea, actual);
        }

        [TestCase(1.0, 6.28)]
        [TestCase(2.0, 12.57)]
        [TestCase(0.5, 3.14)]
        public void Calculate_Circle_Perimeter_With_Valid_Input(double radius, double expected)
        {
            // Arrange
            Circle circle = generateCircle();

            // Act
            double actual = circle.Perimeter(radius);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        /*
            TRIANGLE TESTS
        */

        // Helper method to generate a triangle
        private Triangle generateTriangle()
        {
            Triangle triangle = new Triangle();
            return triangle;
        }

        [TestCase(5.0, 5.0, 5.0, 10.83)]
        [TestCase(3.0, 4.0, 5.0, 6.0)]
        [TestCase(6.0, 8.0, 10.0, 24.0)]
        public void Calculate_Triangle_Area_With_Valid_Input(double side1, double side2, double side3, double expectedArea)
        {
            // Arrange
            Triangle triangle = generateTriangle();

            // Act
            double actual = triangle.Area(side1, side2, side3);

            // Assert
            Assert.AreEqual(expectedArea, actual);
        }

        [TestCase(1.0, 1.0, 1.0, 3.0)]
        [TestCase(3.0, 4.0, 5.0, 12.0)]
        [TestCase(6.0, 8.0, 10.0, 24.0)]
        public void Calculate_Triangle_Perimeter_With_Valid_Input(double side1, double side2, double side3, double expected)
        {
            // Arrange
            Triangle triangle = generateTriangle();

            // Act
            double actual = triangle.Perimeter(side1, side2, side3);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1.0, 2.0, 5.0)]
        [TestCase(2.0, 4.0, 10.0)]
        [TestCase(0.5, 1.0, 2.5)]
        public void Calculate_Triangle_Area_With_Invalid_SideLength(double side1, double side2, double side3)
        {
            // Arrange
            Triangle triangle = generateTriangle();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => triangle.Area(side1, side2, side3));
        }

        /*
            RECTANGLE TESTS
        */

        // Helper method to generate a rectangle
        private Rectangle generateRectangle()
        {
            Rectangle rectangle = new Rectangle();
            return rectangle;
        }

        [TestCase(2.0, 2.0, 4.0)]
        [TestCase(3.0, 4.0, 12.0)]
        [TestCase(0.5, 2.0, 1.0)]
        public void Calculate_Rectangle_Area_With_Valid_Input(double length, double width, double expectedArea)
        {
            // Arrange
            Rectangle rectangle = generateRectangle();

            // Act
            double actual = rectangle.Area(length, width);

            // Assert
            Assert.AreEqual(expectedArea, actual);
        }

        [TestCase(2.0, 2.0, 8.0)]
        [TestCase(3.0, 4.0, 14.0)]
        [TestCase(0.5, 2.0, 5.0)]
        public void Calculate_Rectangle_Perimeter_With_Valid_Input(double length, double width, double expected)
        {
            // Arrange
            Rectangle rectangle = generateRectangle();

            // Act
            double actual = rectangle.Perimeter(length, width);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}