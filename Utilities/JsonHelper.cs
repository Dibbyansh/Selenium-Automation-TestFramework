using Newtonsoft.Json.Linq;

public static class JsonHelper
{
    public static string GetTestData(string fileName, string token)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
        var json = File.ReadAllText(path);
        var jObject = JObject.Parse(json);
        return jObject.SelectToken(token)!.ToString();
    }
}