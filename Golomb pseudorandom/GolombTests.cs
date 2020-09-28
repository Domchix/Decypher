using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryption
{
    public static class GolombTests
    {
        private static double P { get; set; } = 3.84146;
        public static double SingleBitTest(string binary, bool convertToBinary = true)
        {
            int n0 = binary.Count(c => c == '0');
            int n1 = binary.Count(c => c == '1');

            return (Math.Pow((n1 - n0), 2) / binary.Length);
        }
        public static double PairBitTest(string binary)
        {
            int n0 = binary.Count(c => c == '0');
            int n1 = binary.Count(c => c == '1');


            int n00 = 0;
            int n01 = 0;
            int n10 = 0;
            int n11 = 0;

            for (int i = 0; i < binary.Length - 1; i++)
            {
                string pair = $"{binary[i]}{binary[i + 1]}";
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

            double n = binary.Length;

            return ((4 / (n - 1)) * (Math.Pow(n00, 2) + Math.Pow(n01, 2) + Math.Pow(n10, 2) + Math.Pow(n11, 2)) - ((2 / n) * (Math.Pow(n0, 2) + Math.Pow(n1, 2))) + 1);
        }
        public static double BlockTest(string binary)
        {
            char currentChar = binary[0];
            int currentLength = 1;
            List<int> F = new List<int>(new int[binary.Length]);
            List<int> G = new List<int>(new int[binary.Length]);
            // Calculate blocks
            foreach (char c in binary.Substring(1))
            {
                if (c != currentChar)
                {
                    // Update block list
                    if (currentChar == '0') { F[currentLength]++; }
                    else { G[currentLength]++; }

                    currentChar = c;
                    currentLength = 1;
                }
                else
                {
                    currentLength++;
                }
            }

            if (currentChar == '0') { F[currentLength]++; }
            else { G[currentLength]++; }

            Func<int, double> formula = (i) => ((binary.Length - i + 3) / (Math.Pow(2, i + 2)));
            int i = 1;
            double E = formula(i);
            double T = 0;
            while (E >= 5)
            {
                T += ((Math.Pow((F[i] - E), 2) / E) + (Math.Pow((G[i] - E), 2) / E));
                i++;
                E = formula(i);
            }

            return T;
        }

        public static double AutocorelationTest()
        {
            // use sort
            return 0;
        }
    }
}