using EFCore.Services.Interfaces.Cryptography;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EFCore.Services
{
    public class CryptographyService : ICryptographyService
    {
        public string MD5Hashing(string data)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(data))).Replace("-", "");
        }

        public string MD5Hashing(byte[] data)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(data)).Replace("-", "");
        }

        public string SHA256Hashing(string data)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(data))).Replace("-", "");
        }

        public string SHA256Hashing(byte[] data)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(data)).Replace("-", "");
        }

        public string SHA512Hashing(string data)
        {
            return BitConverter.ToString(SHA512.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(data))).Replace("-", "");
        }

        public string SHA512Hashing(byte[] data)
        {
            return BitConverter.ToString(SHA512.Create().ComputeHash(data)).Replace("-", "");
        }
    }
}
