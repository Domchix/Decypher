using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryption
{
    public static class GolombTests
    {
        public static (bool, double) SingleBitTest(string binary, double check)
        {
            int n0 = binary.Count(c => c == '0');
            int n1 = binary.Count(c => c == '1');
            double T = (Math.Pow((n1 - n0), 2) / binary.Length);

            return (T < check, T);
        }
        public static (bool, double) PairBitTest(string binary, double check)
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
            double T = ((4 / (n - 1)) * (Math.Pow(n00, 2) + Math.Pow(n01, 2) + Math.Pow(n10, 2) + Math.Pow(n11, 2)) - ((2 / n) * (Math.Pow(n0, 2) + Math.Pow(n1, 2))) + 1);

            return (T < check, T);
        }
        public static (bool, double) BlockTest(string binary, double check)
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

            return (T < check, T);
        }

        public static (bool, double) AutocorelationTest(string binary, double check)
        {
            int length = binary.Length;
            int d = length / 2;
            int Xd = 0;

            for (int i = 0; i < length - d; i++)
            {
                if (binary[i] == binary[i + d - 1])
                {
                    Xd += 1;
                }
            }

            double T = Math.Abs((2 * Xd - length + d) / (Math.Sqrt(length - d)));

            return (T < check, T);
        }

        public static void RunAndPrintTests(string binary, CheckConstants checks)
        {
            (bool testResult, double tValue) = SingleBitTest(binary, checks.Check1);
            Console.Write($"-Single Bit Test- \n Result: {testResult} \n Value: {tValue} \n");
            (testResult, tValue) = PairBitTest(binary, checks.Check2);
            Console.Write($"-Pair Bit Test- \n Result: {testResult} \n Value: {tValue} \n");
            (testResult, tValue) = BlockTest(binary, checks.Check4);
            Console.Write($"-Single Bit Test- \n Result: {testResult} \n Value: {tValue} \n");
            (testResult, tValue) = AutocorelationTest(binary, checks.Check5);
            Console.Write($"-Autocorelation Test- \n Result: {testResult} \n Value: {tValue} \n");
        }

        public class CheckConstants{
            public double Check1 { get; set; }
            public double Check2 { get; set; }
            public double Check4 { get; set; }
            public double Check5 { get; set; }
        }
    }
}
