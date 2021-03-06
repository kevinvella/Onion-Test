﻿using EFCore.Services.Interfaces.Cryptography.Hashing;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EFCore.Services.Cryptography.Hashing
{
    public class SHA512CryptographyService : ICryptographyService
    {
        public string Hash(string data)
        {
            return Hash(ASCIIEncoding.ASCII.GetBytes(data));
        }

        public string Hash(byte[] data)
        {
            return BitConverter.ToString(SHA512.Create().ComputeHash(data)).Replace("-", "");
        }
    }
}
