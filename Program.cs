using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGolomb();
        }

        private static void TestGolomb(){
            string text = "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011";
            Console.WriteLine($"T1: {GolombTests.SingleBitTest(text)}");
            Console.WriteLine($"T2: {GolombTests.PairBitTest(text)}");
            Console.WriteLine($"T4: {GolombTests.BlockTest(text)}");
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
    }
}
