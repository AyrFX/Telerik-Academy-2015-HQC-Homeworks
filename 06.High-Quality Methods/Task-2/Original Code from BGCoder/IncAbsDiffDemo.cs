using System;
using System.Collections.Generic;

class ProblemTwo
{
    static void Main()
    {
        byte seqNumber = byte.Parse(Console.ReadLine());
        string[] seqs = new string[seqNumber];
        for (int i = 0; i < seqs.Length; i++)
        {
            seqs[i] = Console.ReadLine();
        }
        string sequences = "";
        for (int i = 0; i < seqs.Length; i++)
        {
            sequences = absDiffs(seqs[i]);
            Console.WriteLine(incSequence(sequences));
        }
    }

    static string absDiffs(string sequence)
    {
        List<int> adSequence = new List<int>();
        string[] numbers = sequence.Split(' ');
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            adSequence.Add(Math.Max(int.Parse(numbers[i]), int.Parse(numbers[i + 1])) - Math.Min(int.Parse(numbers[i]), int.Parse(numbers[i + 1])));
        }
        return String.Join(" ", adSequence);
    }

    static bool incSequence(string diffsSequence)
    {
        string[] diffs = diffsSequence.Split(' ');
        for (int i = 0; i < diffs.Length - 1; i++)
		{
           if ((int.Parse(diffs[i]) > int.Parse(diffs[i+1])) || (Math.Abs(int.Parse(diffs[i]) - int.Parse(diffs[i+1])) > 1))
           {
               return false;
           }
        }
    
        return true;
    }
}