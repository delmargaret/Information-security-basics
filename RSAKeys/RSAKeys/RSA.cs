using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public string Encrypt(string text)
        {
            List<int> resultCodes = new List<int>();

            for (int i=0; i < text.Length; i++)
            {
                resultCodes.Add((text[i]^e) % n);  
            }

            string result = "";
            foreach (var code in resultCodes)
            {
                result += (char)code;
            }
            return result;
        }

        public string Decrypt(string text)
        {
            List<int> resultCodes = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                resultCodes.Add((text[i] ^ d) % n);
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
