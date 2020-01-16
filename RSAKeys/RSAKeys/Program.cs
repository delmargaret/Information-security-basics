using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = 23;
            int q = 79;
            var text = "CAD";

            var rsa = new RSA(p, q);
            Console.WriteLine($"string: {text}");

            var encrypted = rsa.Encrypt(text);
            foreach (var code in encrypted.codes)
            {
                Console.Write($"{code} ");
            }

            var decrypted = rsa.Decrypt(encrypted.result);
            Console.WriteLine($"decrypted: {decrypted}");
        }
    }
}
