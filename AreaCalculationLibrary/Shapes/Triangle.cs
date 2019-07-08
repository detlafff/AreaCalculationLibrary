using System;
using static AreaCalculationLibrary.PrecisionParams;

namespace AreaCalculationLibrary.Shapes
{
    public class Triangle : IShape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideB, double sideC, double sideA)
        {
            if (sideB <= 0)
                throw new ArgumentException(nameof(sideB));
            if (sideC <= 0)
                throw new ArgumentException(nameof(sideC));
            if (sideA <= 0)
                throw new ArgumentException(nameof(sideA));

            if (sideB > sideC + sideA)
                throw new ArgumentException(nameof(sideB) + " too large");
            if (sideC > sideB + sideA)
                throw new ArgumentException(nameof(sideC) + " too large");
            if (sideA > sideC + sideB)
                throw new ArgumentException(nameof(sideA) + " too large");

            SideB = sideB;
            SideC = sideC;
            SideA = sideA;
        }

        public double AreaSize
        {
            get
            {
                var p = (SideA + SideB + SideC) / 2;

                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }

        private bool? _isRightTriangle = null;

        public bool IsRightTriangle
        {
            get
            {
                if (!_isRightTriangle.HasValue)
                    _isRightTriangle =
                        (Math.Abs(Math.Pow(SideA, 2) - (Math.Pow(SideB, 2) + Math.Pow(SideC, 2))) < ArithmeticAccuracy)
                        || (Math.Abs(Math.Pow(SideB, 2) - (Math.Pow(SideA, 2) + Math.Pow(SideC, 2))) < ArithmeticAccuracy)
                        || (Math.Abs(Math.Pow(SideC, 2) - (Math.Pow(SideA, 2) + Math.Pow(SideB, 2))) < ArithmeticAccuracy);

                return _isRightTriangle.Value;
            }
        }

    }
}