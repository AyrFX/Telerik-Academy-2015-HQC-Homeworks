namespace BoolPrinter
{
    using System;

    public class BoolPrinter
    {
        internal const int MaxCount = 6;

        public static void Main()
        {
            BoolPrinter.PrintBool parsed = new PrintBool();
            parsed.LogAsString(true);
        }

        public class PrintBool
        {
            internal void LogAsString(bool boolValue)
            {
                string inputAsString = boolValue.ToString();
                Console.WriteLine(inputAsString);
            }
        }
    }
}
