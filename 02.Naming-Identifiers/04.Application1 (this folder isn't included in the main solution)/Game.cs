namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mines
    {
        public static void Main(string[] arguments)
        {
            string command = string.Empty;
            char[,] field = CreateField();
            char[,] mines = PlaceMines();
            int turnsCounter = 0;
            bool exploded = false;
            List<PlayerScore> highScoreCollection = new List<PlayerScore>(6);
            int row = 0;
            int col = 0;
            bool gameStart = true;
            const int EmptyCells = 35;
            bool allEmptyOpened = false;

            do
            {
                if (gameStart)
                {
                    Console.WriteLine("Let's play Minesweeper. Try your luck to find the cells without mines." +
                        " Command 'top' shows the highscore, 'restart' starts new game, 'exit' exits the game!");
                    PrintField(field);
                    gameStart = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHighscore(highScoreCollection);
                        break;
                    case "restart":
                        field = CreateField();
                        mines = PlaceMines();
                        PrintField(field);
                        exploded = false;
                        gameStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                ProcessTurn(field, mines, row, col);
                                turnsCounter++;
                            }

                            if (EmptyCells == turnsCounter)
                            {
                                allEmptyOpened = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid Command!\n");
                        break;
                }

                if (exploded)
                {
                    PrintField(mines);
                    Console.Write("\nSorry! Your exploded with {0} points. Enter your nickname: ", turnsCounter);
                    string playerNickname = Console.ReadLine();
                    PlayerScore currentPlayerScore = new PlayerScore(playerNickname, turnsCounter);
                    if (highScoreCollection.Count < 5)
                    {
                        highScoreCollection.Add(currentPlayerScore);
                    }
                    else
                    {
                        for (int i = 0; i < highScoreCollection.Count; i++)
                        {
                            if (highScoreCollection[i].Points < currentPlayerScore.Points)
                            {
                                highScoreCollection.Insert(i, currentPlayerScore);
                                highScoreCollection.RemoveAt(highScoreCollection.Count - 1);
                                break;
                            }
                        }
                    }

                    highScoreCollection.Sort((PlayerScore r1, PlayerScore r2) => r2.Name.CompareTo(r1.Name));
                    highScoreCollection.Sort((PlayerScore r1, PlayerScore r2) => r2.Points.CompareTo(r1.Points));
                    ShowHighscore(highScoreCollection);

                    field = CreateField();
                    mines = PlaceMines();
                    turnsCounter = 0;
                    exploded = false;
                    gameStart = true;
                }

                if (allEmptyOpened)
                {
                    Console.WriteLine("\nWell done! You've opened 35 cells withuot to explode.");
                    PrintField(mines);
                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();
                    PlayerScore currentPlayerScore = new PlayerScore(playerName, turnsCounter);
                    highScoreCollection.Add(currentPlayerScore);
                    ShowHighscore(highScoreCollection);
                    field = CreateField();
                    mines = PlaceMines();
                    turnsCounter = 0;
                    allEmptyOpened = false;
                    gameStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("Good bye.");
            Console.Read();
        }

        private static void ShowHighscore(List<PlayerScore> highscoreCollection)
        {
            Console.WriteLine("\nHighscore:");
            if (highscoreCollection.Count > 0)
            {
                for (int i = 0; i < highscoreCollection.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, highscoreCollection[i].Name, highscoreCollection[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No highscore!\n");
            }
        }

        private static void ProcessTurn(char[,] field, char[,] mines, int row, int col)
        {
            char minesAround = CountMinesAround(mines, row, col);
            mines[row, col] = minesAround;
            field[row, col] = minesAround;
        }

        private static void PrintField(char[,] field)
        {
            int row = field.GetLength(0);
            int col = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        private static char[,] PlaceMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> minesCollection = new List<int>();
            while (minesCollection.Count < 15)
            {
                Random randomGenerator = new Random();
                int currentMineNumber = randomGenerator.Next(50);
                if (!minesCollection.Contains(currentMineNumber))
                {
                    minesCollection.Add(currentMineNumber);
                }
            }

            foreach (int element in minesCollection)
            {
                int col = element / cols;
                int row = element % cols;
                if (row == 0 && element != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static void CalculateMinesAroundCells(char[,] field)
        {
            int row = field.GetLength(0);
            int col = field.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char minesAround = CountMinesAround(field, i, j);
                        field[i, j] = minesAround;
                    }
                }
            }
        }

        private static char CountMinesAround(char[,] field, int row, int col)
        {
            int minesCounter = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    minesCounter++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    minesCounter++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    minesCounter++;
                }
            }

            return char.Parse(minesCounter.ToString());
        }

        public class PlayerScore
        {
            private string name;
            private int points;

            public PlayerScore()
            {
            }

            public PlayerScore(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }
    }
}
