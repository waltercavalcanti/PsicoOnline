using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace PsicoOnline.Core.Util;

public static class JsonExtensions
{
    private static readonly JsonSerializerSettings _settings;

    static JsonExtensions()
    {
        _settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None
        };
    }

    public static object Deserialize<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj, _settings);
    }

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