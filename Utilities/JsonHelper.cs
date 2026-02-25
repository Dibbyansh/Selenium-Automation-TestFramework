using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
public static class JsonHelper
{
    private static readonly ConcurrentDictionary<string, JObject> _cache = new();

    public static T GetTestData<T>(string fileName, string token)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
        var jObject = _cache.GetOrAdd(path, p =>
        {
            var json = File.ReadAllText(p);
            return JObject.Parse(json);
        });

        return jObject.SelectToken(token)!.ToObject<T>()!;
    }
}