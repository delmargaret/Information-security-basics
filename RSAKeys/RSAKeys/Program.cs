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
            int p = 29;
            int q = 73;
            var text = "CBC";

            var rsa = new RSA(p, q);
            Console.WriteLine($"string: {text}");

            var encrypted = rsa.Encrypt(text);
            Console.WriteLine($"encrypted: {encrypted}");

            var decrypted = rsa.Decrypt(encrypted);
            Console.WriteLine($"decrypted: {decrypted}");
        }
    }
}
