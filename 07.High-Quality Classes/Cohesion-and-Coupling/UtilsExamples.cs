namespace CohesionAndCoupling
{
    using System;

    internal class UtilsExamples
    {
        internal static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                DistanceUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                DistanceUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            ParallelipipedUtils.Width = 3;
            ParallelipipedUtils.Height = 4;
            ParallelipipedUtils.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", ParallelipipedUtils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", ParallelipipedUtils.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", ParallelipipedUtils.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", ParallelipipedUtils.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", ParallelipipedUtils.CalcDiagonalYZ());
        }
    }
}
