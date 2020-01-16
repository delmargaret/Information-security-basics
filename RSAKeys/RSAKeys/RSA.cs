using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSAKeys
{
    public class RSA
    {
        private readonly int p;
        private readonly int q;
        private int n;
        private int e;
        private int d;

        public RSA(int p, int q)
        {
            this.p = p;
            this.q = q;
            GetPrivateCipherKey();
        }

        private void GetPrivateCipherKey()
        {
            n = p * q;
            var func = (p - 1) * (q - 1);
            e = func - 1; // два соседних числа - взаимно простые

            int k = 1;
            while(true)
            {
                if (((k * func) + 1) % e == 0)
                {
                    d = ((k * func) + 1)/e;
                    break;
                }
                k++;
            }
            Console.WriteLine($"D: {d}");
        }

        public (IEnumerable<BigInteger> codes, string result) Encrypt(string text)
        {
            List<BigInteger> resultCodes = new List<BigInteger>();

            for (int i=0; i < text.Length; i++)
            {
                BigInteger numb = BigInteger.ModPow(text[i], e, n);
                resultCodes.Add(numb);  
            }

            string result = "";
            foreach (var code in resultCodes)
            {
                result += (char)code;
            }
            return (resultCodes, result);
        }

        public string Decrypt(string text)
        {
            List<BigInteger> resultCodes = new List<BigInteger>();

            for (int i = 0; i < text.Length; i++)
            {
                BigInteger numb = BigInteger.ModPow(text[i], d, n);
                resultCodes.Add(numb);
            }

            string result = "";
            foreach (var code in resultCodes)
            {
                result += (char)code;
            }
            return result;
        }

    }
}
