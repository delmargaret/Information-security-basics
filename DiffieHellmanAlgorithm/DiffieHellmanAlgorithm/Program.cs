using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellmanAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("enter first value: ");
                var isFirstValid = int.TryParse(Console.ReadLine(), out int firstNumber);
                Console.WriteLine("enter second value: ");
                var isSecondValid = int.TryParse(Console.ReadLine(), out int secondNumber);
                Console.WriteLine();

                if (!isFirstValid || !isSecondValid)
                {
                    throw new Exception("invalid initial values");
                }

                Console.WriteLine("enter 1st secret number: ");
                var isFirstRandomValid = int.TryParse(Console.ReadLine(), out int firstRandomNumber);
                Console.WriteLine("enter 2nd secret number: ");
                var isSecondRandomValid = int.TryParse(Console.ReadLine(), out int secondRandomNumber);
                Console.WriteLine();

                if (!isFirstRandomValid || !isSecondRandomValid)
                {
                    throw new Exception("invalid secret values");
                }

                var diffieHellmanAlgorithm = new DiffieHellmanAlgorithm(firstNumber, secondNumber);

                var firstPublicKey = diffieHellmanAlgorithm.GetPublicKey(firstRandomNumber);
                var secondPublicKey = diffieHellmanAlgorithm.GetPublicKey(secondRandomNumber);

                Console.WriteLine($"1st public key: {firstPublicKey}");
                Console.WriteLine($"2nd public key: {secondPublicKey}");
                Console.WriteLine();


                var firstSecretKey = diffieHellmanAlgorithm.GetSecretKey(secondPublicKey, firstRandomNumber);
                var secondSecretKey = diffieHellmanAlgorithm.GetSecretKey(firstPublicKey, secondRandomNumber);

                Console.WriteLine($"1st secret key: {firstSecretKey}");
                Console.WriteLine($"2nd secret key: {secondSecretKey}");
                Console.WriteLine();

                Console.WriteLine($"---------------- Caesar Cipher -------------");
                var message = "хочузачетавтоматом";
                Console.WriteLine($"string: {message}");

                var encryptedString = CaesarCipher.Encrypt(message, firstSecretKey);
                Console.WriteLine($"encrypted string: {encryptedString}");

                var decryptedString = CaesarCipher.Decrypt(encryptedString, firstSecretKey);
                Console.WriteLine($"decrypted string: {decryptedString}");
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
