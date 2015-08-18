namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        public Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        protected bool IsValidDimensionValue(double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value) || double.Equals(value, 0) || value < 0)
            {
                return false;
            }

            return true;
        }
    }
}
