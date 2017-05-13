using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.Interfaces.Cryptography
{
    public interface ICryptographyService
    {
        string Hash(string data);

        string Hash(byte[] data);
    }
}
