using System.Collections.Concurrent;
using System.Text.Json;

/// <summary>
/// Provides helper methods for loading and querying test data from JSON files.
/// Parsed JSON files are cached in memory to avoid redundant file I/O across tests.
/// </summary>
public static class JsonHelper
{
    // Thread-safe cache that stores parsed JSON content keyed by file path.
    // This ensures each JSON file is read and parsed only once, even in parallel test runs.
    private static readonly ConcurrentDictionary<string, JsonElement> _cache = new();

    /// <summary>
    /// Retrieves and deserializes a specific section of test data from a JSON file.
    /// </summary>
    
    /// <typeparam name="T">The type to deserialize the JSON data into.</typeparam>
    /// <param name="fileName">The name of the JSON file located in the "TestData" folder (e.g., "credentials.json").</param>
    /// <param name="token">A dot-separated path to navigate nested JSON properties. 
    /// For example, "login.validUser" navigates to the "login" object, then to the "validUser" property within it.</param>
    /// <returns>The deserialized object of type <typeparamref name="T"/>.</returns>
    public static T GetTestData<T>(string fileName, string token)
    {
        // Build the full path to the JSON file under the "TestData" directory
        var path = Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);

        // Try to get the cached JSON root element for this file path.
        // If not cached, read the file, parse it, and cache the result.
        var root = _cache.GetOrAdd(path, p =>
        {
            var json = File.ReadAllText(p);

            // Parse the JSON string into a JsonDocument.
            // 'using' ensures the document is disposed after cloning, freeing internal buffers.
            using var doc = JsonDocument.Parse(json);

            // Clone the root element so it remains valid after the JsonDocument is disposed.
            return doc.RootElement.Clone();
        });

        // Navigate through the JSON structure using the dot-separated token.
        // Each segment moves one level deeper into the JSON hierarchy.
        var current = root;
        foreach (var segment in token.Split('.'))
        {
            current = current.GetProperty(segment);
        }

        // Deserialize the targeted JSON element into the requested type and return it.
        // The null-forgiving operator (!) asserts the result is non-null.
        return current.Deserialize<T>()!;
    }
}