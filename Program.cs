using System;
using System.IO;

namespace Cypher
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "text.txt";
            string text = File.ReadAllText(file);
            text = text.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace(",", "");
            int keyLength = Kasiski.FindKeyLength(text);
            Console.WriteLine(keyLength);
        }
    }
}
