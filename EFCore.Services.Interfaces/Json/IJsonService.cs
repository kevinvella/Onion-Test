using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.Interfaces.Json
{
    public interface IJsonService
    {
        T Deserialize<T>(string input);

        string Serialize<T>(T input);
    }
}
