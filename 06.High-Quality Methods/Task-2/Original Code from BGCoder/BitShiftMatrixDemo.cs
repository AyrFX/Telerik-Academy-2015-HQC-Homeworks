using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int matrixRows = int.Parse(Console.ReadLine());
        int matrixCols = int.Parse(Console.ReadLine());
        //======================
        int movesNumber = int.Parse(Console.ReadLine());
        string[] codes = Console.ReadLine().Split(' ');
        int[,] points = new int[movesNumber+1, 2];
        points[0, 0] = matrixRows - 1;
        points[0, 1] = 0;
        for (int i = 0; i < codes.Length; i++)
        {
            points[i + 1, 0] = int.Parse(codes[i]) / Math.Max(matrixRows, matrixCols);
            points[i + 1, 1] = int.Parse(codes[i]) % Math.Max(matrixRows, matrixCols);
        }
        //=======================
        BigInteger [,] matrix = new BigInteger[matrixRows, matrixCols];
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = (BigInteger)Math.Pow(2, j + matrix.GetLength(0) - i - 1);
            }
        }
        //========================
        int fromRow, fromCol, toRow, toCol;
        BigInteger collectedPoints = 0;
        for (int i = 0; i < points.GetLength(0) - 1; i++)
        {
            fromRow = points[i, 0];
            fromCol = points[i, 1];
            toRow = points[i + 1, 0];
            toCol = points[i + 1, 1];
            if (fromCol < toCol)
            {
                for (int j = fromCol; j <= toCol; j++)
                {
                    collectedPoints += matrix[fromRow, j];
                    matrix[fromRow, j] = 0;
                    //Console.WriteLine("row={0}, col={1}", fromRow, j);
                }
            }
            else
                for (int j = fromCol; j >= toCol; j--)
                {
                    collectedPoints += matrix[fromRow, j];
                    matrix[fromRow, j] = 0;
                    //Console.WriteLine("row={0}, col={1}", fromRow, j);
                }
            if (fromRow < toRow)
            {
                for (int j = fromRow; j <= toRow; j++)
                {
                    collectedPoints += matrix[j, toCol];
                    matrix[j, toCol] = 0;
                    //Console.WriteLine("row={0}, col={1}", j, toCol);
                }
            }
            else
            {
                for (int j = fromRow; j >= toRow; j--)
                {
                    collectedPoints += matrix[j, toCol];
                    matrix[j, toCol] = 0;
                    //Console.WriteLine("row={0}, col={1}", j, toCol);
                }
            }
            //printMatrix(matrix);
            //Console.WriteLine("Result after point {0} = {1}", i + 1, collectedPoints);
        }
        Console.WriteLine("{0:D2}", collectedPoints);
    }

    static void printMatrix(BigInteger[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, 5} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
