namespace Matrix
{
    using System;

    internal class FillMatrix
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int matrixSize = 0;
            while (!int.TryParse(input, out matrixSize) || matrixSize < 1 || matrixSize > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[matrixSize, matrixSize];
            int maxNumberToFill = matrixSize * matrixSize,
                numberToFill = 1,
                currentRow = 0,
                currentCol = 0,
                movementRowDirection = 1,
                movementColDirection = 1;

            while (numberToFill < maxNumberToFill + 1)
            {
                matrix[currentRow, currentCol] = numberToFill;
                if (HaveEmptyNeighbour(matrix, currentRow, currentCol))
                {
                    if (currentRow + movementRowDirection >= matrixSize || currentRow + movementRowDirection < 0 || currentCol + movementColDirection >= matrixSize || currentCol + movementColDirection < 0 || matrix[currentRow + movementRowDirection, currentCol + movementColDirection] != 0)
                    {
                        while (currentRow + movementRowDirection >= matrixSize || currentRow + movementRowDirection < 0 || currentCol + movementColDirection >= matrixSize || currentCol + movementColDirection < 0 || matrix[currentRow + movementRowDirection, currentCol + movementColDirection] != 0)
                        {
                            ChangeDirection(ref movementRowDirection, ref movementColDirection);
                        }
                    }

                    currentRow += movementRowDirection;
                    currentCol += movementColDirection;
                }
                else
                {
                    FindDistantFreeCell(matrix, out currentRow, out currentCol);
                    if (currentRow == 0 || currentCol == 0)
                    {
                        break;
                    }
                }

                numberToFill++;
            }

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,6}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        internal static void ChangeDirection(ref int currentDirectionRow, ref int currentDirectionCol)
        {
            if (-1 > currentDirectionRow || currentDirectionRow > 1 || -1 > currentDirectionCol || currentDirectionCol > 1)
            {
                throw new ArgumentOutOfRangeException("The directions can have value between -1 and 1!");
            }

            int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirectionIndex = 0;

            for (int i = 0; i < 8; i++)
            {
                if (rowDirections[i] == currentDirectionRow && colDirections[i] == currentDirectionCol)
                {
                    currentDirectionIndex = i;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                currentDirectionRow = rowDirections[0];
                currentDirectionCol = colDirections[0];
                return;
            }

            currentDirectionRow = rowDirections[currentDirectionIndex + 1];
            currentDirectionCol = colDirections[currentDirectionIndex + 1];
        }

        internal static bool HaveEmptyNeighbour(int[,] matrix, int currentRow, int currentCol)
        {
            int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (currentRow + rowDirections[i] >= matrix.GetLength(0) || currentRow + rowDirections[i] < 0)
                {
                    rowDirections[i] = 0;
                }

                if (currentCol + colDirections[i] >= matrix.GetLength(0) || currentCol + colDirections[i] < 0)
                {
                    colDirections[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if ((matrix[currentRow + rowDirections[i], currentCol + colDirections[i]] == 0) && (rowDirections[i] != 0 || colDirections[i] != 0))
                {
                    return true;
                }
            }

            return false;
        }

        internal static void FindDistantFreeCell(int[,] matrix, out int rowPosition, out int colPosition)
        {
            rowPosition = 0;
            colPosition = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rowPosition = i;
                        colPosition = j;
                        return;
                    }
                }
            }
        }
    }
}
