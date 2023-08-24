using NUnit.Framework;
using CalculatorAPI;
using System;
using Moq;
namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Mock<IDiagnostics> _mockDiagnostics;

        [SetUp]
        public void SetUp()
        {
            _mockDiagnostics = new Mock<IDiagnostics>();
        }


        private ICalculator CreateCalculator()
        {
            return new Calculator(_mockDiagnostics.Object);
        }



        [TestCase(4, 2, 6)]
        [TestCase(6, 12, 18)]
        [TestCase(100, 43, 143)]
        [TestCase(-14, 6, -8)]
        public void TestAdd(int a, int b, int expected)
        {
            //Arrange
            var calc = CreateCalculator();
            
            // Act
            int result =calc.Add(a, b);

            // Assert
            Assert.AreEqual(expected, result, $"Addition result is incorrect for {a} + {b}.");
        }



        [TestCase(4, 2, 2)]
        [TestCase(15, 5, 10)]
        [TestCase(100, 21, 79)]
        [TestCase(-14, 3, -17)]
        public void TestSubtract(int a, int b, int expected)
        {
            //Arrange
            var calc = CreateCalculator();

            // Act
            int result = calc.Subtract(a, b);

            // Assert
            Assert.AreEqual(expected, result, $"Subtraction result is incorrect for {a} - {b}. Expected: {expected}, Actual: {result}");
        }

        [TestCase(4, 2, 8)]
        [TestCase(15, 0, 0)]
        [TestCase(10, -21, -210)]
        [TestCase(-12, -3, 36)]
        public void TestMultiply(int a, int b, int expected)
        {
            //Arrange
            var calc = CreateCalculator();

            // Act
            int result = calc.Multiply(a, b);

            // Assert
            Assert.AreEqual(expected, result, $"Multiplication result is incorrect for {a} * {b}. Expected: {expected}, Actual: {result}");
        }

        [TestCase(4, 2, 2)]
        [TestCase(15, 7, 2)]
        [TestCase(10, -21, 0)]
        [TestCase(-12, -3, 4)]
        public void TestDivide(int a, int b, int expected)
        {
            //Arrange
            var calc = CreateCalculator();

            // Act
            int result = calc.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, result, $"Division result is incorrect for {a} / {b}. Expected: {expected}, Actual: {result}");
        }


        [Test]
        public void TestDivideByZero()
        {
            //Arrange
            var calc = CreateCalculator();

            //Act Assert
            Assert.Throws<DivideByZeroException>(() => calc.Divide(5, 0),$"Division by zero exception expected for 5/0");
        }
    }
}