using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellmanAlgorithm
{
    public static class CaesarCipher
    {
        const string alfabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        private static string CodeEncode(string text, int key)
        {
            var alfabetLength = alfabet.Length;
            var validText = text.ToLower();
            var resultValue = "";
            for (int i = 0; i < validText.Length; i++)
            {
                var c = validText[i];
                var index = alfabet.IndexOf(c);
                var codeIndex = (alfabetLength + index + key) % alfabetLength;
                resultValue += alfabet[codeIndex];
            }

            return resultValue;
        }

        public static string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        public static string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }
}
