using System;
using System.Numerics;

public class DeCatCoding
{
    public static void Main()
    {
        string inputSentence = Console.ReadLine();
        string[] codedWordsArray = inputSentence.Split(' ');
        string[] translatedWordsArray = new string[codedWordsArray.Length];

        for (int wordIndex = 0; wordIndex < codedWordsArray.Length; wordIndex++)
        {
            BigInteger wordAsDecimal = GetCodedWordDecimalValue(codedWordsArray[wordIndex]);
            translatedWordsArray[wordIndex] = GetLatinWordFromDecimalValue(wordAsDecimal);
        }

        Console.WriteLine(string.Join(" ", translatedWordsArray));
    }

    internal static BigInteger GetCodedWordDecimalValue(string codedWord)
    {
        const byte CatLettersNumber = 21;

        BigInteger wordDecimalValue = 0;
        for (int charIndex = codedWord.Length - 1; charIndex >= 0; charIndex--)
        {
            wordDecimalValue = wordDecimalValue + (CatCharToNumber(codedWord[charIndex]) * Power(CatLettersNumber, codedWord.Length - charIndex - 1));
        }

        return wordDecimalValue;
    }

    internal static string GetLatinWordFromDecimalValue(BigInteger decimalValue)
    {
        const byte LatinLettersNumber = 26;
        string latinWord = string.Empty;
        while (decimalValue / LatinLettersNumber > 0)
        {
            latinWord = NumberToLatinChar((BigInteger)decimalValue % LatinLettersNumber).ToString() + latinWord;
            decimalValue /= LatinLettersNumber;
        }

        latinWord = NumberToLatinChar(decimalValue % LatinLettersNumber).ToString() + latinWord;

        return latinWord;
    }

    internal static BigInteger CatCharToNumber(char symbol)
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
            default:
                {
                    throw new ArgumentException("Given symbol is not valid cat-letter!");
                }
        }
    }

    internal static char NumberToLatinChar(BigInteger number)
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
            default:
                {
                    throw new ArgumentException("The latin characters are represented from integers between 0 to 25!");
                }
        }
    }

    internal static BigInteger Power(BigInteger baseNumber, BigInteger exponent)
    {
        BigInteger result = 1;
        for (BigInteger i = 0; i < exponent; i++)
        {
            result *= baseNumber;
        }

        return result;
    }
}