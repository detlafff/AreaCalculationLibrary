using System;
using AreaCalculationLibrary;
using AreaCalculationLibrary.Shapes;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class CircleTest
    {
        [Test]
        [TestCase(0)]
        public void CtorMustThrowExceptionOnInvalidParam(double r)
        {
            Assert.Catch<ArgumentException>(() => new Circle(r));
        }

        [Test]
        [TestCase(5, 157.079632679)]
        public void TestAreaCalcultion(double r, double correctAnswer)
        {
            var circle = new Circle(r);
            var delta = Math.Abs( circle.AreaSize - correctAnswer);
            Assert.Greater(PrecisionParams.ArithmeticAccuracy, delta);
        }

    }
}