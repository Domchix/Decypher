using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using static Encryption.GolombTests;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Linear();
        }

        private static void TestGolomb()
        {
            CheckConstants checks = new CheckConstants()
            {
                Check1 = 3.841458820694124,
                Check2 = 5.991464547107979,
                Check4 = 9.487729036781154,
                Check5 = 1.959963984540054
            };
            string text = "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011";
            Console.WriteLine($"T1: {GolombTests.SingleBitTest(text, checks.Check1)}");
            Console.WriteLine($"T2: {GolombTests.PairBitTest(text, checks.Check2)}");
            Console.WriteLine($"T4: {GolombTests.BlockTest(text, checks.Check4)}");
        }

        private static void TestKasiski()
        {
            // Read file, clean text
            string fileName = "Kasiski method/Tests/test.txt";
            string text = File.ReadAllText(fileName);
            text = text.Replace(" ", "").Replace("\r", "").Replace("\n", "").ToLower();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            text = rgx.Replace(text, "");

            Kasiski.MinDigramLength = 2;
            Kasiski.MaxDigramLength = 2;
            Kasiski.PrintResult = true;
            int keyLength = Kasiski.FindKeyLength(text);
            Console.WriteLine($"Key length: {keyLength}");
        }

        private static void Cypher()
        {
            string ans = XOREncryptionDecryption.Encode("test text", "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011");
            Console.WriteLine(ans);

            ans = XOREncryptionDecryption.Decode("000001000000011000011101000110110001110000000000", "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011");
            Console.WriteLine(ans);
        }

        private static void Linear()
        {
            CheckConstants checks = new CheckConstants()
            {
                Check1 = 3.841458820694124,
                Check2 = 5.991464547107979,
                Check4 = 9.487729036781154,
                Check5 = 1.959963984540054
            };
            string str = LinearFeedback.LinearRegresion("1000001");
            Console.WriteLine(str);
            GolombTests.RunAndPrintTests(str, checks);
        }
    }
}
