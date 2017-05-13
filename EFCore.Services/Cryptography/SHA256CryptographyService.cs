using EFCore.Services.Interfaces.Cryptography;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EFCore.Services.Cryptography
{
    public class SHA256CryptographyService : ICryptographyService
    {
        public string Hash(string data)
        {
            return Hash(ASCIIEncoding.ASCII.GetBytes(data));
        }

        public string Hash(byte[] data)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(data)).Replace("-", "");
        }
    }
}
