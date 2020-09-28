using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryption
{
    public static class StatisticTests
    {
        public static double SingleBitTest(string text)
        {
            text = Converter.StringToBinary(text);

            int n0 = text.Count(c => c == '0');
            int n1 = text.Count(c => c == '1');

            return ((n1 - n0) ^ 2 / text.Length);
        }
        public static double PairBitTest(string text)
        {
            text = Converter.StringToBinary(text);

            int n0 = text.Count(c => c == '0');
            int n1 = text.Count(c => c == '1');


            int n00 = 0;
            int n01 = 0;
            int n10 = 0;
            int n11 = 0;

            for (int i = 0; i < text.Length - 1; i++)
            {
                string pair = $"{text[i]}{text[i + 1]}";
                switch (pair)
                {
                    case "00":
                        n00++;
                        break;
                    case "01":
                        n01++;
                        break;
                    case "11":
                        n11++;
                        break;
                    case "10":
                        n10++;
                        break;
                }
            }

            int n = text.Length;

            return (4 / (n - 1)) * (n00 ^ 2 + n01 ^ 2 + n10 ^ 2 + n11 ^ 2) - ((2 / n) * (n0 ^ 2 + n1 ^ 2)) + 1;
        }
        public static double BlockTest(string text)
        {
            text = Converter.StringToBinary(text);

            char currentChar = text[0];
            int currentLength = 1;
            List<int> F = new List<int>(new int[text.Length]);
            List<int> G = new List<int>(new int[text.Length]);
            // Calculate blocks
            foreach (char c in text.Substring(1))
            {
                if (c != currentChar)
                {
                    // Update block list
                    if (currentChar == '0') { F[currentLength]++; }
                    else { G[currentLength]++; }

                    currentChar = c;
                    currentLength = 1;
                }
                currentLength++;
            }


            Func<int, double> formula = (i) => ((text.Length - i + 3) / (2 ^ i + 2));
            int i = 0;
            double E = formula(i);
            double T = 0;
            while (E >= 5)
            {
                T += (Math.Pow((F[i] - E), 2) / E) + (Math.Pow((G[i] - E), 2) / E);
                i++;
                E = formula(i);
            }

            return 0;
        }
    }
}