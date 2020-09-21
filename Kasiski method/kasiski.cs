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
        public static int MinKeyLength { get; set; } = 4;
        public static int MinDigramLength {get;set;} = 4;
        public static int MaxDigramLength { get; set; } = 4;
        private static IEnumerable<int> GetDivisors(int n)
        {
            return from a in Enumerable.Range(2, n / 2)
                where n % a == 0
                select a;
        }

        public static int FindKeyLength(string text)
        {
            // Find all matching text parts
            List<Pair> matchingPairs = new List<Pair>();
            foreach (var digramLength in Enumerable.Range(MinDigramLength, MaxDigramLength))
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

            // Get all different deviders and count ammount
            List<Pair> deviders = new List<Pair>();
            foreach(Pair matchingPair in matchingPairs){
                foreach(var divisor in GetDivisors(matchingPair.PeriodLength).Append(matchingPair.PeriodLength)){
                    if (deviders.Any(n => n.PeriodLength == divisor))
                        deviders.FirstOrDefault(n => n.PeriodLength == divisor).CountOfSubstrings += matchingPair.CountOfSubstrings;
                    else
                        deviders.Add(new Pair
                        {
                            PeriodLength = divisor,
                            CountOfSubstrings = matchingPair.CountOfSubstrings
                        });
                }
            }
            // Filter out smaller keys, order by count and take the highest one
            var matrix = deviders.OrderByDescending(n => n.CountOfSubstrings).ToList();
            Console.WriteLine("Devidor  | Number of pairs");
            foreach(var item in matrix.Take(10)){
                Console.WriteLine($"{item.PeriodLength} \t | {item.CountOfSubstrings}");
            }
            return deviders.Where(n => n.PeriodLength >= MinKeyLength).OrderByDescending(n => n.CountOfSubstrings).ToList()[0].PeriodLength;
        }
    }
}