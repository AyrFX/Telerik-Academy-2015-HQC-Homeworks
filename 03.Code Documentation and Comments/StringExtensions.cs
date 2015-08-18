namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides additional methods for string manipulation
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Creates MD5 Hash of given string
        /// </summary>
        /// <param name="input">String to generate MD5 Hash</param>
        /// <returns>Hexadecimal string containing MD5 of the input</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks if given string represents boolean value.
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>Boolean, representing if the given string is in the set of given true representing values</returns>
        public static bool ToBoolean(this string input)
        {
            // Create Array containing values of strings, representing true.
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts string to short value.
        /// </summary>
        /// <param name="input">String to convert in short value</param>
        /// <returns>The short value, represented in given string. If the conversion isn't successful the return value is 0 (default value of type short</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts string to integer value.
        /// </summary>
        /// <param name="input">String to convert in integer value</param>
        /// <returns>The integer value, represented in given string. If the conversion isn't successful the return value is 0 (default value of type integer</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts string to long value.
        /// </summary>
        /// <param name="input">String to convert in long value</param>
        /// <returns>The long value, represented in given string. If the conversion isn't successful the return value is 0 (default value of type long</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts string to DateTime value.
        /// </summary>
        /// <param name="input">String to convert in DateTime value</param>
        /// <returns>The DateTime value, represented in given string. If the conversion isn't successful the return value is DateTime.MinValue.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Converts the first char of the given string to uppercase.
        /// </summary>
        /// <param name="input">The string to capitalize first character</param>
        /// <returns>New string in which the first character is converted to uppercase.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Retrieves a substring between two substrings from given string.
        /// </summary>
        /// <param name="input">The string in which the substring to be searched.</param>
        /// <param name="startString">The substring which marks the begin of searched substring.</param>
        /// <param name="endString">The substring which marks the end of searched substring.</param>
        /// <param name="startFrom">The index of the string from which to search.</param>
        /// <returns>Substring between the two given strings.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts cyrillic letters of given string to their latin representations.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>String with cyrillic characters replaced.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            // Create array containing all cyrillic characters
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };

            // Create array containing all representations of bulgarian characters on appropriate indexes
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };

            // Iterate over the array of cyrrilic characters and if current character exists in the input string,
            // replaces it with corresponding latin representation.
            // The second check is for replacing of capital letters. 
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts cyrillic letters of given string to their corresponding latin letter.
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>String with cyrillic characters replaced.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            // Create array containing all latin characters
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            // Create array containing cyrillic characters, that have corresponding latin characters.
            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            // Iterate over the array of latin characters and if current character exists in the input string,
            // replaces it with corresponding cyrillic character.
            // The second check is for replacing of capital letters.
            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts given string to string containing valid username (including only latin characters, digits, "_" and ".",
        /// removing all other symbols.         
        /// </summary>
        /// <param name="input">String to be converted in valid username string.</param>
        /// <returns>Converted string with invalid symbols removed.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts given string to string containing valid filename (including only latin characters, digits, "_", "." and "-",
        /// removing all other symbols.         
        /// </summary>
        /// <param name="input">String to be converted in valid filename string.</param>
        /// <returns>Converted string with invalid symbols removed.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns substring of definite number characters at the begin of the given string. 
        /// </summary>
        /// <param name="input">String containing searched substring.</param>
        /// <param name="charsCount">The length of returned substring.</param>
        /// <returns>Substring of given number of characters at the begin of the given string. If given length is bigger of the length of the string, returns the given string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Extracts the file extension from given filename.
        /// </summary>
        /// <param name="fileName">String containing filename.</param>
        /// <returns>Extension part of the filename. If the given filename isn't valid filename, returns empty string.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the file content type according given file extension.  
        /// </summary>
        /// <param name="fileExtension">The extension of a file for which content type to be returned.</param>
        /// <returns>The content type of the file with the given extension.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts string to array of characters.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Array of bytes in which every two bytes represent one char.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
