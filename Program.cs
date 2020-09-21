using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Encryption
{
    class Program
    {
        private static string FileName {get;set;} = "text.txt";
        static void Main(string[] args)
        {
            Kasiski();
            Cypher();
        }

        private static void Kasiski(){
            string text = File.ReadAllText(FileName);
            text = text.Replace(" ", "").Replace("\r", "").Replace("\n", "").ToLower();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            text = rgx.Replace(text, "");

            //int keyLength = Kasiski.FindKeyLength(text);
            //Console.WriteLine($"Key length: {keyLength}");
        }

        private static void Cypher(){
            string ans = XOREncryptionDecryption.Encode("test text", "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011");
            Console.WriteLine(ans);

            ans = XOREncryptionDecryption.Decode("000001000000011000011101000110110001110000000000", "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011");
            Console.WriteLine(ans);
        }
    }
}
