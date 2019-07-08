using System;

namespace AreaCalculationLibrary.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(Double radius)
        {
            if (radius <= 0)
                throw new ArgumentException(nameof(radius));
            Radius = radius;
        }

        public double AreaSize => 2 * Math.PI * Radius * Radius;
    }
}