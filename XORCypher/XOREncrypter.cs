using System;
using System.Linq;

namespace Encryption{
    public static class XOREncryptionDecryption
    {
        public static string Encode(string data, string key)
        {
            string bin_data = "";
            string code = "";

            foreach(char c in data){
                bin_data += Converter.DecToBinary((int)c, 8);
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
                 ans += (char)Converter.BinToDec(code.Substring(i, 8));
            }

            return ans;
        }

        
    }
}