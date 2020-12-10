using System;
using System.Collections.Generic;

namespace Encryption
{
    public static class LinearFeedback
    {
        public static string LinearRegresion(string c){
            List<int> X = new List<int>();
            Random random = new Random();

            for (int i = 0; i < c.Length; i++)
            {
                X.Add(random.Next(2));
            }
            int n = X.Count;
            double m = Math.Pow(2, n) - 1;
            c = StringBuilder.Reverse(c);
            string newString = "";

            for(int i = 0; i<m; i++){
                newString += X[n-1].ToString();
                int tmp = 0;
                for(int j = 0; j<n; j++){
                    tmp += X[j] * int.Parse(c[j].ToString());
                }

                int s = n-1;
                while(s > 0){
                    X[s] = X[s-1];
                    s -= 1;
                }

                X[0] = tmp % 2;
            }

            return newString;
        }
    }
}
