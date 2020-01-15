using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellmanAlgorithm
{
    class DiffieHellmanAlgorithm
    {
        private int firstNumber;
        private int secondNumber;

        public DiffieHellmanAlgorithm(int first, int second)
        {
            this.firstNumber = first;
            this.secondNumber = second;
        }
        public int GetPublicKey(int value)
        {
            var result = Math.Pow(firstNumber, value) % secondNumber;
            return (int)result;
        }

        public int GetSecretKey(int publicKey, int value)
        {
            var result = Math.Pow(publicKey, value) % secondNumber;
            return (int)result;
        }
    }
}
