using System;
using AreaCalculationLibrary.Shapes;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class TriangleTest
    {
        [Test]
        [TestCase(-1, 2, 5)]
        [TestCase(1, -2, 5)]
        [TestCase(1, 2, 0)]
        [TestCase(1,2, 5)]
        [TestCase(1, 10, 5)]
        [TestCase(19, 2, 5)]
        public void CtroWithInvalidParamsMustThrowException(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Test]
        [TestCase(3, 4, 5, 6)]
        public void TestAreaCalcultion(double a, double b, double c, double correctAreaSize)
        {
            var triangle  = new Triangle(a,b,c);

            Assert.AreEqual(triangle.AreaSize, correctAreaSize);
        }

        [Test]
        [TestCase(3, 4, 5, true)]
        [TestCase(4, 3, 5, true)]
        [TestCase(5, 4, 3, true)]
        [TestCase(4, 4, 5, false)]
        public void TestRightTriangleCheck(double a, double b, double c, bool correctAnwer)
        {
            var triangle = new Triangle(a, b, c);

            Assert.AreEqual(triangle.IsRightTriangle, correctAnwer);
        }
    }
}
