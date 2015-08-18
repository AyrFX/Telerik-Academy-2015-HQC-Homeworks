using System;
using System.Numerics;

class ProblemOne
{
    static void Main()
    {
        string[] encWords = Console.ReadLine().Split(' ');
        BigInteger result;
        string resultString;
        for (int i = 0; i < encWords.Length; i++)
        {
            result = 0;
            for (int j = encWords[i].Length - 1; j >= 0; j--)
            {
                result = result + (charToNumber(encWords[i][j]) * Power(21, encWords[i].Length - 1 - j));
            }
            resultString = "";
            while (result / 26 > 0)
            {
                resultString = numberToChar((BigInteger)result % 26).ToString() + resultString;
                result /= 26;
            }
            resultString = numberToChar(result % 26).ToString() + resultString;
            encWords[i] = resultString;
        }
        Console.WriteLine(String.Join(" ", encWords));
    }

    static BigInteger charToNumber(char symbol)
    {
        switch (symbol)
        {
            case 'a': return 0;
            case 'b': return 1;
            case 'c': return 2;
            case 'd': return 3;
            case 'e': return 4;
            case 'f': return 5;
            case 'g': return 6;
            case 'h': return 7;
            case 'i': return 8;
            case 'j': return 9;
            case 'k': return 10;
            case 'l': return 11;
            case 'm': return 12;
            case 'n': return 13;
            case 'o': return 14;
            case 'p': return 15;
            case 'q': return 16;
            case 'r': return 17;
            case 's': return 18;
            case 't': return 19;
            case 'u': return 20;
            default: return 1;
        }
    }

    static char numberToChar(BigInteger number)
    {
        switch ((ulong)number)
        {
            case 0: return 'a';
            case 1: return 'b';
            case 2: return 'c';
            case 3: return 'd';
            case 4: return 'e';
            case 5: return 'f';
            case 6: return 'g';
            case 7: return 'h';
            case 8: return 'i';
            case 9: return 'j';
            case 10: return 'k';
            case 11: return 'l';
            case 12: return 'm';
            case 13: return 'n';
            case 14: return 'o';
            case 15: return 'p';
            case 16: return 'q';
            case 17: return 'r';
            case 18: return 's';
            case 19: return 't';
            case 20: return 'u';
            case 21: return 'v';
            case 22: return 'w';
            case 23: return 'x';
            case 24: return 'y';
            case 25: return 'z';
            default: return ' ';
        }
    }

    static BigInteger Power(BigInteger x, BigInteger y)
    {
        BigInteger result = 1;
        for (BigInteger i = 0; i < y; i++)
        {
            result *= x;
        }
        return result;
    }
}