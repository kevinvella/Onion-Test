using EFCore.Services.Interfaces.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.Json
{
    public class JsonService : IJsonService
    {
        public T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
