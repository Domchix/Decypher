using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Encryption
{
    public class GolombTest
    {
        [InlineData("01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011", 0.962)]
        [Theory]
        public void SingleBitTest(string text, double testResult)
        {
            Assert.Equal(testResult, Math.Round(GolombTests.SingleBitTest(text), 3));
        }

        [InlineData("01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011", 2.174)]
        [Theory]
        public void PairBitTest(string text, double testResult){
            Assert.Equal(testResult, Math.Round(GolombTests.PairBitTest(text), 3));
        }

        [InlineData("01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011", 8.534)]
        [Theory]
        public void BlockTest(string text, double testResult){
            Assert.Equal(testResult, Math.Round(GolombTests.BlockTest(text), 3));
        }
    }
}
