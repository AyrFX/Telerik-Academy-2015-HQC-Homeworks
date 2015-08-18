namespace Matrix.Tests
{
    using System;
    using System.IO;
    using Matrix;
    using NUnit.Framework;

    [TestFixture]
    public class MatrixTests
    {
        [TestCase("ABC")]
        [TestCase("abc")]
        [TestCase("")]
        [TestCase("%$#")]
        [TestCase("1x5")]
        [TestCase("-23")]
        [TestCase("0")]
        [TestCase("101")]
        [TestCase("23523")]
        [TestCase("2.6")]
        [TestCase("-4.13")]
        public void AskUntilValidMatrixSizeEntered(string input)
        {
            StringReader reader = new StringReader(input + "\n3");
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            FillMatrix.Main();
            string expectedOutput = "Enter a positive number \r\n" +
                                    "You haven't entered a correct positive number\r\n" +
                                    "     1     7     8\r\n" +
                                    "     6     2     9\r\n" +
                                    "     5     4     3\r\n";
            Assert.AreEqual(expectedOutput, writer.ToString());
            reader.Dispose();
            writer.Dispose();
        }

        [Test]
        public void CheckOneCellMatrix()
        {
            StringReader reader = new StringReader("1");
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            FillMatrix.Main();
            string expectedOutput = "Enter a positive number \r\n     1\r\n";
            Assert.AreEqual(expectedOutput, writer.ToString());
            reader.Dispose();
            writer.Dispose();
        }

        [Test]
        public void CheckFourCellsMatrix()
        {
            StringReader reader = new StringReader("2");
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            FillMatrix.Main();
            string expectedOutput = "Enter a positive number \r\n     1     4\r\n     3     2\r\n";
            Assert.AreEqual(expectedOutput, writer.ToString());
            reader.Dispose();
            writer.Dispose();
        }

        [Test]
        public void CheckNineCellsMatrix()
        {
            StringReader reader = new StringReader("3");
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            FillMatrix.Main();
            string expectedOutput = "Enter a positive number \r\n     1     7     8\r\n     6     2     9\r\n     5     4     3\r\n";
            Assert.AreEqual(expectedOutput, writer.ToString());
            reader.Dispose();
            writer.Dispose();
        }

        [TestCase("1")]
        [TestCase("10")]
        [TestCase("24")]
        [TestCase("100")]
        public void TheResultMatrixShouldHaveAccurateSize(string size)
        {
            StringReader reader = new StringReader(size);
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            FillMatrix.Main();
            string output = writer.ToString();
            output = output.Replace("Enter a positive number ", string.Empty);
            output = output.Replace("\r", string.Empty);
            output = output.Replace("\n", string.Empty);
            string[] separators = { " " };
            string[] outputNumbers = output.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(Int32.Parse(size) * Int32.Parse(size), outputNumbers.Length);
            reader.Dispose();
            writer.Dispose();
        }
        
        [TestCase("1")]
        [TestCase("10")]
        [TestCase("24")]
        [TestCase("100")]
        public void TheMaxFilledNumberShoudBeSizeToTheSecondPower(string size)
        {
        	int matrixCellsNumber = Int32.Parse(size) * Int32.Parse(size);
            StringReader reader = new StringReader(size);
            StringWriter writer = new StringWriter();
            Console.SetIn(reader);
            Console.SetOut(writer);
            FillMatrix.Main();
            string output = writer.ToString();
            output = output.Replace("Enter a positive number ", string.Empty);
            output = output.Replace("\r", string.Empty);
            output = output.Replace("\n", string.Empty);
            string[] separators = { " " };
            string[] outputNumbers = output.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int maxNumber = 0;
            for (int i = 0; i < matrixCellsNumber; i++) {
            	int currentNumber = Int32.Parse(outputNumbers[i].Trim());
            	if (currentNumber > maxNumber)
            	{
            		maxNumber = currentNumber;
            	}
            }
            Assert.AreEqual(matrixCellsNumber, maxNumber);
            reader.Dispose();
            writer.Dispose();
        }
        
        [TestCase(4, 0)]
        [TestCase(-1, 7)]
        [TestCase(-3, 1)]
        [TestCase(-4, -1)]
        public void ChangeOfDirectionsShouldThrowByWrongInput(int currentRowDirection, int currentColDirection)
        {
        	Assert.Throws(typeof(ArgumentOutOfRangeException), () => {FillMatrix.ChangeDirection(ref currentRowDirection, ref currentColDirection);}, "Boo!");
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void ChangeOfDirectionsShouldSwitchDirectionsCorrect(int directionNumber)
        {
			int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int inputDirectionRow = rowDirections[directionNumber - 1], inputDirectionCol = colDirections[directionNumber - 1];
        	FillMatrix.ChangeDirection(ref inputDirectionRow, ref inputDirectionCol);
        	if (directionNumber < 8) {
        		Assert.AreEqual(rowDirections[directionNumber], inputDirectionRow);
        		Assert.AreEqual(colDirections[directionNumber], inputDirectionCol);
        	}
        	else {
        		Assert.AreEqual(rowDirections[0], inputDirectionRow);
        		Assert.AreEqual(colDirections[0], inputDirectionCol);
        	}
        }
        
        [Test]
        public void HaveEmptyNeighbourShouldReturnFalseIfOnlyEmptyCellIsCurrent()
        {
        	int[,] firstMatrix = {
        		{0,2,3},
        		{4,5,6},
        		{7,8,9}};
        	Assert.AreEqual(false, FillMatrix.HaveEmptyNeighbour(firstMatrix, 0, 0));
        	int[,] secondMatrix = {
        		{1,2,3},
        		{4,0,6},
        		{7,8,9}};
        	Assert.AreEqual(false, FillMatrix.HaveEmptyNeighbour(secondMatrix, 1, 1));
        	int[,] thirdMatrix = {
        		{1,2,3},
        		{4,5,6},
        		{0,8,9}};
        	Assert.AreEqual(false, FillMatrix.HaveEmptyNeighbour(thirdMatrix, 2, 0));
        }
        
        [Test]
        public void HaveEmptyNeighbourShouldReturnFalseIfOnlyEmptyCellIsNotNeighbourOfCurrentCell()
        {
        	int[,] firstMatrix = {
        		{1,2,3},
        		{4,5,0},
        		{7,8,9}};
        	Assert.AreEqual(false, FillMatrix.HaveEmptyNeighbour(firstMatrix, 0, 0));
        	int[,] secondMatrix = {
        		{1,2,3},
        		{4,5,6},
        		{0,8,9}};
        	Assert.AreEqual(false, FillMatrix.HaveEmptyNeighbour(secondMatrix, 1, 2));
        	int[,] thirdMatrix = {
        		{1,0,3},
        		{4,5,6},
        		{7,8,9}};
        	Assert.AreEqual(false, FillMatrix.HaveEmptyNeighbour(thirdMatrix, 2, 1));
        }
        
        [Test]
        public void HaveEmptyNeighbourShouldReturnTrueByPresenceOfEmptyNeighbour()
        {
        	int[,] firstMatrix = {
        		{1,2,3},
        		{4,5,0},
        		{7,8,9}};
        	Assert.AreEqual(true, FillMatrix.HaveEmptyNeighbour(firstMatrix, 0, 2));
        	int[,] secondMatrix = {
        		{1,2,3},
        		{4,5,6},
        		{0,8,9}};
        	Assert.AreEqual(true, FillMatrix.HaveEmptyNeighbour(secondMatrix, 1, 1));
        	int[,] thirdMatrix = {
        		{1,0,3},
        		{4,5,6},
        		{7,8,9}};
        	Assert.AreEqual(true, FillMatrix.HaveEmptyNeighbour(thirdMatrix, 1, 0));
        }
    }
}

