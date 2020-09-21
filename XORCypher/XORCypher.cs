using System;
using System.Linq;

namespace Cypher{
    public static class XOREncryptionDecryption
    {
        public static string Encode(string data, string key)
        {
            string bin_data = "";
            string code = "";

            foreach(char c in data){
                bin_data += DecToBinary((int)c, 8);
            }

            foreach(var i in Enumerable.Range(0, bin_data.Length)){
                if(bin_data[i] == key[i]){ code += "0"; } else { code += "1";}
            }

            return code;
        }

        public static string Decode(string data, string key){
            string code = "";

            foreach(var i in Enumerable.Range(0, data.Length)){
                if(key[i] == '1' && data[i] == '0') { code += "1"; }
                else if(key[i] == '0' && data[i] == '1') { code += "1";}
                else { code += "0"; }
            }

            string ans = "";
            for(int i=0; i<code.Length; i=i+8){
                 ans += (char)BinToDec(code.Substring(i, 8));
            }

            return ans;
        }

        // expects a integer value and length of the binary string (e.g. 4, 8, 16).
        private static string DecToBinary(int value, int length)
        {
            string binString = "";

            while (value > 0)
            {
                binString += value % 2;
                value /= 2;
            }

            // we need to reverse the binary string
            string reverseString = "";
            foreach (char c in binString)
                reverseString = new string((char)c, 1) + reverseString;
            binString = reverseString;

            // padding
            binString = new string((char)'0', length - binString.Length) + binString;

            return binString;
        }

        // expects the binary string and returns it's integer equivalent
        private static int BinToDec(string Binary)
        {
            return Convert.ToInt32(Binary, 2);
        }
    }
}