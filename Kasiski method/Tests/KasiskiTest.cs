using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Encryption
{
    public class KasiskiTest
    {
        [InlineData("../../../Kasiski method/Tests/test.txt")]
        [Theory]
        public void FindKeyLengthTest(string fileName)
        {
            string text = File.ReadAllText(fileName);
            text = text.Replace(" ", "").Replace("\r", "").Replace("\n", "").ToLower();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            text = rgx.Replace(text, "");

            int keyLength = Kasiski.FindKeyLength(text);

            Assert.Equal(7, keyLength);
        }


        [InlineData("../../../Kasiski method/Tests/test2.txt")]
        [Theory]
        public void FindKeyLength2Test(string fileName)
        {
            string text = File.ReadAllText(fileName);
            text = text.Replace(" ", "").Replace("\r", "").Replace("\n", "").ToLower();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            text = rgx.Replace(text, "");
            
            int keyLength = Kasiski.FindKeyLength(text);

            Assert.Equal(4, keyLength);
        }
    }
}
