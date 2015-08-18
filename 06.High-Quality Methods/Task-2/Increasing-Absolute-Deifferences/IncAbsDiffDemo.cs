using System;
using System.Collections.Generic;

public class IncreasingAbsoluteDifference
{
    public static void Main()
    {
        byte sequencesCount;

        try
        {
            sequencesCount = byte.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            throw new ArgumentException("The number of sequences can be integer value!");
        }

        if (sequencesCount < 4 || 10 < sequencesCount)
        {
            throw new ArgumentException("The number of sequences must be between 4 and 10 inclusive!");
        }

        string[] sequencesArray = new string[sequencesCount];
        for (int i = 0; i < sequencesArray.Length; i++)
        {
            sequencesArray[i] = Console.ReadLine();
        }

        string absoluteDiffecencesSequence = string.Empty;
        for (int i = 0; i < sequencesArray.Length; i++)
        {
            absoluteDiffecencesSequence = CalcAbsoluteDifferences(sequencesArray[i]);
            Console.WriteLine(IsSequenceIncreasing(absoluteDiffecencesSequence));
        }
    }

    internal static string CalcAbsoluteDifferences(string sequence)
    {
        List<int> absoluteDifferenceSequence = new List<int>();
        string[] sequenceMembers = sequence.Split(' ');
        for (int i = 0; i < sequenceMembers.Length - 1; i++)
        {
            int largerMember, smallerMember;
            try
            {
                largerMember = Math.Max(int.Parse(sequenceMembers[i]), int.Parse(sequenceMembers[i + 1]));
                smallerMember = Math.Min(int.Parse(sequenceMembers[i]), int.Parse(sequenceMembers[i + 1]));
            }
            catch (FormatException)
            {
                throw new ArgumentException("The sequence can consist only of integer values!");
            }

            absoluteDifferenceSequence.Add(largerMember - smallerMember);
        }

        return string.Join(" ", absoluteDifferenceSequence);
    }

    internal static bool IsSequenceIncreasing(string absoluteDifferencesSequence)
    {
        string[] differencesArray = absoluteDifferencesSequence.Split(' ');
        for (int i = 0; i < differencesArray.Length - 1; i++)
        {
            int currentMember = int.Parse(differencesArray[i]);
            int nextMember = int.Parse(differencesArray[i + 1]);
            if (currentMember > nextMember || Math.Abs(currentMember - nextMember) > 1)
            {
                return false;
            }
        }

        return true;
    }
}