using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        byte matrixRows, matrixCols;
        try
        {
            matrixRows = byte.Parse(Console.ReadLine());
            matrixCols = byte.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            throw new ArgumentException("Invalid number of rows or columns!");
        }

        BigInteger[,] matrix = GetFilledMatrix(matrixRows, matrixCols);

        short movesNumber;
        try
        {
            movesNumber = short.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            throw new ArgumentException("Invalid number of moves!");
        }

        string[] codesArray = Console.ReadLine().Split(' ');
        int[,] pathPoints = GetPointsArray(codesArray, matrixRows, matrixCols, movesNumber);

        // ========================
        int fromRow, fromCol, toRow, toCol;
        BigInteger collectedPoints = 0;
        for (int pointIndex = 0; pointIndex < pathPoints.GetLength(0) - 1; pointIndex++)
        {
            fromRow = pathPoints[pointIndex, 0];
            fromCol = pathPoints[pointIndex, 1];
            toRow = pathPoints[pointIndex + 1, 0];
            toCol = pathPoints[pointIndex + 1, 1];
            if (fromCol < toCol)
            {
                for (int i = fromCol; i <= toCol; i++)
                {
                    collectedPoints += matrix[fromRow, i];
                    matrix[fromRow, i] = 0;
                }
            }
            else
            {
                for (int i = fromCol; i >= toCol; i--)
                {
                    collectedPoints += matrix[fromRow, i];
                    matrix[fromRow, i] = 0;
                }
            }

            if (fromRow < toRow)
            {
                for (int i = fromRow; i <= toRow; i++)
                {
                    collectedPoints += matrix[i, toCol];
                    matrix[i, toCol] = 0;
                }
            }
            else
            {
                for (int i = fromRow; i >= toRow; i--)
                {
                    collectedPoints += matrix[i, toCol];
                    matrix[i, toCol] = 0;
                }
            }
        }

        Console.WriteLine("{0:D2}", collectedPoints);
    }

    internal static BigInteger[,] GetFilledMatrix(byte matrixRows, byte matrixCols)
    {
        BigInteger[,] matrix = new BigInteger[matrixRows, matrixCols];
        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = (BigInteger)Math.Pow(2, col + matrix.GetLength(0) - row - 1);
            }
        }

        return matrix;
    }
    
    internal static int[,] GetPointsArray(string[] codesArray, byte matrixRows, byte matrixCols, short movesNumber)
    {
        int[,] pathPoints = new int[movesNumber + 1, 2];
        pathPoints[0, 0] = matrixRows - 1;
        pathPoints[0, 1] = 0;
        for (int i = 0; i < codesArray.Length; i++)
        {
            try
            {
                pathPoints[i + 1, 0] = int.Parse(codesArray[i]) / Math.Max(matrixRows, matrixCols);
                pathPoints[i + 1, 1] = int.Parse(codesArray[i]) % Math.Max(matrixRows, matrixCols);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Some of the given codes of positions are invalid!");
            }
        }

        return pathPoints;
    }
}