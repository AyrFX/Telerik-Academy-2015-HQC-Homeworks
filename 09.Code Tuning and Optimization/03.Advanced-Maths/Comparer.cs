namespace Compare_advanced_Maths
{
    using System;
    using System.Diagnostics;

    public class Comparer
    {
        public static void Main()
        {
            Stopwatch sw = new Stopwatch();
            
            float someFloat = float.MaxValue;
            sw.Start();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Sqrt((double)someFloat);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 sqare root operations with floats is {0}", sw.Elapsed);

            someFloat = float.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Log((double)someFloat);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 natural logarithm operations with floats is {0}", sw.Elapsed);

            someFloat = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Sin((double)someFloat);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 sinus operations with floats is {0}\n", sw.Elapsed);


            double someDouble = double.MaxValue;
            sw.Start();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Sqrt(someDouble);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 sqare root operations with doubles is {0}", sw.Elapsed);

            someDouble = float.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Log(someDouble);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 natural logarithm operations with doubles is {0}", sw.Elapsed);

            someDouble = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Sin(someDouble);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 sinus operations with doubles is {0}\n", sw.Elapsed);


            decimal someDecimal = decimal.MaxValue;
            sw.Start();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Sqrt((double)someDecimal);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 sqare root operations with decimals is {0}", sw.Elapsed);

            someDecimal = decimal.MaxValue;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Log((double)someDecimal);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 natural logarithm operations with decimals is {0}", sw.Elapsed);

            someDecimal = 1;
            sw.Restart();
            for (int passes = 0; passes <= 10000000; passes++)
            {
                Math.Sin((double)someDecimal);
            }

            sw.Stop();
            Console.WriteLine("The speed of 10000000 sinus operations with decimals is {0}\n", sw.Elapsed);
        }
    }
}
