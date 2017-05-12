using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.Interfaces.Cryptography
{
    public interface ICryptographyService
    {
        string MD5Hashing(string data);

        string MD5Hashing(byte[] data);

        string SHA256Hashing(string data);

        string SHA256Hashing(byte[] data);

        string SHA512Hashing(string data);

        string SHA512Hashing(byte[] data);
    }
}
