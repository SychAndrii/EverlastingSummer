using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilder.Helpers
{
    internal class DeepCopyHelper
    {
        internal static T DeepCopy<T>(T other)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented,
            };

            string json = JsonConvert.SerializeObject(other, settings);
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}
