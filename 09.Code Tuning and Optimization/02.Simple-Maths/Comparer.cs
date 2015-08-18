namespace Compare_simple_Maths
{
    using System;
    using System.Diagnostics;

    public class Comparer
    {
        public static void Main()
        {
            Stopwatch sw = new Stopwatch();
            int intResult = 0;

            sw.Start();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                intResult = intResult + 12;
            }
            
            sw.Stop();
            Console.WriteLine("The speed of 10000000 addition operations with ints is {0}", sw.Elapsed);

            intResult = int.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                intResult = intResult - 12;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 subtract operations with ints is {0}", sw.Elapsed);

            intResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                intResult = intResult++;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 increment operations with ints is {0}", sw.Elapsed);

            intResult = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                intResult = intResult * intResult;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 multiply operations with ints is {0}", sw.Elapsed);

            intResult = int.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                intResult = intResult / 10;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 division operations with ints is {0}\n", sw.Elapsed);


            long longResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                longResult = intResult + 12;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 addition operations with longs is {0}", sw.Elapsed);

            longResult = long.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                longResult = longResult - 12;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 subtract operations with longs is {0}", sw.Elapsed);

            longResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                longResult = longResult++;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 increment operations with longs is {0}", sw.Elapsed);

            longResult = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                longResult = longResult * longResult;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 multiply operations with longs is {0}", sw.Elapsed);

            longResult = int.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                longResult = longResult / 100;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 division operations with longs is {0}\n", sw.Elapsed);


            float floatResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                floatResult = floatResult + 12f;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 addition operations with floats is {0}", sw.Elapsed);

            floatResult = float.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                floatResult = floatResult - 12f;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 subtract operations with floats is {0}", sw.Elapsed);

            floatResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                floatResult = floatResult++;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 increment operations with floats is {0}", sw.Elapsed);

            floatResult = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                floatResult = floatResult * floatResult;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 multiply operations with floats is {0}", sw.Elapsed);

            floatResult = float.MaxValue;
            sw.Restart();
            for (long passes = 0; passes <= 10000000; passes++)
            {
                floatResult = floatResult / 10f;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 division operations with floats is {0}\n", sw.Elapsed);


            double doubleResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                doubleResult = doubleResult + 12d;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 addition operations with double is {0}", sw.Elapsed);

            doubleResult = double.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                doubleResult = doubleResult - 12d;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 subtract operations with double is {0}", sw.Elapsed);

            doubleResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                doubleResult = doubleResult++;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 increment operations with double is {0}", sw.Elapsed);

            doubleResult = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                doubleResult = doubleResult * doubleResult;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 multiply operations with double is {0}", sw.Elapsed);

            doubleResult = double.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                doubleResult = doubleResult / 10d;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 division operations with double is {0}\n", sw.Elapsed);


            decimal decimalResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                decimalResult = decimalResult + 12m;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 addition operations with decimal is {0}", sw.Elapsed);

            decimalResult = decimal.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                decimalResult = decimalResult - 12m;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 subtract operations with decimal is {0}", sw.Elapsed);

            decimalResult = 0;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                decimalResult = decimalResult++;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 increment operations with decimal is {0}", sw.Elapsed);

            decimalResult = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                decimalResult = decimalResult * decimalResult;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 multiply operations with decimal is {0}", sw.Elapsed);

            doubleResult = double.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                decimalResult = decimalResult / 10m;
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 division operations with decimal is {0}\n", sw.Elapsed);
        }
    }
}
