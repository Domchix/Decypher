using System;

namespace Encryption
{
    public static class Converter
    {
        public static string StringToBinary(string text)
        {
            string binText = "";
            foreach (char c in text)
            {
                binText += Converter.DecToBinary((int)c, 8);
            }

            return binText;
        }

        /// <summary>
        /// Expects a integer value and length of the binary string (e.g. 4, 8, 16).
        /// </summary>
        /// <param name="value">char in decimal value</param>
        /// <param name="length">char length (e.g. 4, 8, 16)</param>
        /// <returns>string that contains binary form of the char</returns>
        public static string DecToBinary(int value, int length)
        {
            string binString = "";

            while (value > 0)
            {
                binString += value % 2;
                value /= 2;
            }

            // we need to reverse the binary string
            string reverseString = "";
            foreach (char c in binString)
                reverseString = new string((char)c, 1) + reverseString;
            binString = reverseString;

            // padding
            binString = new string((char)'0', length - binString.Length) + binString;

            return binString;
        }

        /// <summary>
        /// expects the binary string and returns it's integer equivalent
        /// </summary>
        /// <param name="Binary">String in binary</param>
        /// <returns>Integer equivalent in char</returns>
        public static int BinToDec(string Binary)
        {
            return Convert.ToInt32(Binary, 2);
        }
    }
}