using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace PsicoOnline.Core.Util
{
    public static class JsonExtensions
    {
        public static StringContent ToJson<T>(this T obj)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(obj, settings);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}