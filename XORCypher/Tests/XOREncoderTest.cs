using System;
using Xunit;

namespace Encryption
{
    public class XOREncoderTest
    {
        private string Text { get => "test text"; }
        private string Key { get => "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011"; }
        private string EncryptedText = "001111010000001000011100000001100100100100000111000001110001110100011000";
        public XOREncoderTest()
        {
        }

        [Fact]
        public void EncryptTest()
        {
            string ans = XOREncryptionDecryption.Encode(Text, Key);
            Assert.Equal(ans, EncryptedText);
        }

        [Fact]
        public void DecryptTest()
        {
            string ans = XOREncryptionDecryption.Decode(EncryptedText, Key);
            Assert.Equal(ans, Text);
        }
    }
}
