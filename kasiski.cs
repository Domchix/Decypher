using System;
using System.Collections.Generic;
using System.Linq;

namespace Cypher
{
    public class Pair
    {
        public int PeriodLength { get; set; }
        public int CountOfSubstrings { get; set; }
        public string Substring { get; set; }
    }

    public static class Kasiski
    {
        public static int MinKeyLength { get; set; } = 3;
        public static int MaxKeyLength { get; set; } = 70;
        private static IEnumerable<int> GetDivisors(int n)
        {
            return from a in Enumerable.Range(2, n / 2)
                where n % a == 0
                select a;
        }
        private static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b, a % b);
            }
        }

        public static int FindKeyLength(string text)
        {
            // Find all matching text parts
            List<Pair> matchingPairs = new List<Pair>();
            foreach (var digramLength in Enumerable.Range(MinKeyLength, MaxKeyLength))
            {
                for (int i = 0; i < text.Length - digramLength; i++)
                {
                    string temp = text.Substring(i, digramLength);
                    for (int j = i + 1; j < text.Length - digramLength; j++)
                    {
                        string temp2 = text.Substring(j, digramLength);
                        if (temp == temp2)
                        {
                            if (matchingPairs.Any(n => n.PeriodLength == j - i && n.Substring == temp2))
                                matchingPairs.FirstOrDefault(n => n.PeriodLength == j - i).CountOfSubstrings++;
                            else
                                matchingPairs.Add(new Pair {
                                    PeriodLength = j - i,
                                    CountOfSubstrings = 1,
                                    Substring = temp2
                                });
                        }
                    }
                }
            }
            // Analyze matching parts matrix for most common deviders
            List<Pair> greatestCommonDeviders = new List<Pair>();
            for(int i = 0; i < matchingPairs.Count(); i++)
                for(int j = i + 1; j < matchingPairs.Count(); j++)
                {
                    var keyLength = GCD(matchingPairs[i].PeriodLength, matchingPairs[j].PeriodLength);
                    if (greatestCommonDeviders.Any(n => n.PeriodLength == keyLength))
                        greatestCommonDeviders.FirstOrDefault(n => n.PeriodLength == keyLength).CountOfSubstrings++;
                    else
                        greatestCommonDeviders.Add(new Pair
                        {
                            PeriodLength = keyLength,
                            CountOfSubstrings = 1
                        });
                }

            List<Pair> gcd = new List<Pair>();
            foreach(Pair matchingPair in matchingPairs){
                foreach(var divisor in GetDivisors(matchingPair.PeriodLength).Append(matchingPair.PeriodLength)){
                    if (gcd.Any(n => n.PeriodLength == divisor))
                        gcd.FirstOrDefault(n => n.PeriodLength == divisor).CountOfSubstrings++;
                    else
                        gcd.Add(new Pair
                        {
                            PeriodLength = divisor,
                            CountOfSubstrings = 1
                        });
                }
            }
            // Filter out smaller keys, order by count and take the highest one
            var a = greatestCommonDeviders.OrderByDescending(n => n.CountOfSubstrings).ToList();
            var b = gcd.OrderByDescending(n => n.CountOfSubstrings).ToList();
            Console.WriteLine(b[0].PeriodLength);
            return greatestCommonDeviders.Where(n => n.PeriodLength > MinKeyLength).OrderByDescending(n => n.CountOfSubstrings).ToList()[0].PeriodLength;
        }
    }
}