namespace TelerikAcademy.Homeworks
{
    using System;

    public class Size
    {
        public double width, height;
        
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(
            Size figureSize, double rotationAngle)
        {
            double rotatedFigureWidth = (Math.Abs(Math.Cos(rotationAngle)) * figureSize.width) +
                    (Math.Abs(Math.Sin(rotationAngle)) * figureSize.height);
            double rotatedFigureHeight = (Math.Abs(Math.Sin(rotationAngle)) * figureSize.width) +
                    (Math.Abs(Math.Cos(rotationAngle)) * figureSize.height);
            return new Size(rotatedFigureWidth, rotatedFigureHeight);
        }
    }
}
