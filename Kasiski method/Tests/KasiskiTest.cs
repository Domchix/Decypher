using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Encryption
{
    public class KasiskiTest
    {
        [InlineData("../../../Kasiski method/Tests/test.txt", 7)]
        [InlineData("../../../Kasiski method/Tests/test2.txt", 5)]
        [Theory]
        public void FindKeyLengthTest(string fileName, int expectedKeyLength)
        {
            string text = File.ReadAllText(fileName);
            text = text.Replace(" ", "").Replace("-", "").Replace("\r", "").Replace("\n", "").ToLower();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            text = rgx.Replace(text, "");

            int keyLength = Kasiski.FindKeyLength(text);

            Assert.Equal(expectedKeyLength, keyLength);
        }
    }
}
