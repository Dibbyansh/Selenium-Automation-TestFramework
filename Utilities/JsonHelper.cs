using Newtonsoft.Json.Linq;

public static class JsonHelper
{
    public static T GetTestData<T>(string fileName, string token)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
        var json = File.ReadAllText(path);
        var jObject = JObject.Parse(json);
        return jObject.SelectToken(token)!.ToObject<T>()!;
    }
}