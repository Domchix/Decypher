using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Encryption
{
    public class GolombTest
    {
        // NOTE: All numbers are rounded

        [InlineData(true, 0.962, 7.879, "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011")]
        [Theory]
        public void SingleBitTest(bool expectedTestResult, double expectedTValue, double check, string binaryText)
        {
            (bool testResult, double tValue) = GolombTests.SingleBitTest(binaryText, check);
            tValue = Math.Round(tValue, 3);

            Assert.Equal(expectedTValue, tValue);
            Assert.Equal(expectedTestResult, testResult);
        }

        [InlineData(true, 2.174, 10.597, "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011")]
        [Theory]
        public void PairBitTest(bool expectedTestResult, double expectedTValue, double check, string binaryText){
            (bool testResult, double tValue) = GolombTests.PairBitTest(binaryText, check);
            tValue = Math.Round(tValue, 3);

            Assert.Equal(expectedTValue, tValue);
            Assert.Equal(expectedTestResult, testResult);
        }

        [InlineData(true, 8.534, 14.86, "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011")]
        [Theory]
        public void BlockTest(bool expectedTestResult, double expectedTValue, double check, string binaryText){
            (bool testResult, double tValue) = GolombTests.BlockTest(binaryText, check);
            tValue = Math.Round(tValue, 3);

            Assert.Equal(expectedTValue, tValue);
            Assert.Equal(expectedTestResult, testResult);
        }

        [InlineData(true, 0.555, 2.807, "01001001011001110110111101110010011010010111001101100010011001010110110001101111011101100110000101110011")]
        [Theory]
        public void AutocorelationTest(bool expectedTestResult, double expectedTValue, double check, string binaryText){
            (bool testResult, double tValue) = GolombTests.AutocorelationTest(binaryText, check);
            tValue = Math.Round(tValue, 3);

            Assert.Equal(expectedTValue, tValue);
            Assert.Equal(expectedTestResult, testResult);
        }

        [Fact]
        public void LineaFeedbackTest(){
            
        }
    }
}
