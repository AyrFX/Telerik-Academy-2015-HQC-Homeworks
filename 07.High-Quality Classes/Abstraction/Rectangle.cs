namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (!this.IsValidDimensionValue(value))
                {
                    throw new ArgumentException("The width can be only positive floating-point value!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (!this.IsValidDimensionValue(value))
                {
                    throw new ArgumentException("The height can be only positive floating-point value!");
                }

                this.height = value;
            }
        }
        
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
