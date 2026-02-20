using Microsoft.Extensions.Configuration;

namespace OrangeHRM_Revised.Utilities
{
    public static class ConfigManager
    {
        private static readonly IConfigurationRoot _config;

        static ConfigManager()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string BaseUrl => _config["BrowserSettings:BaseUrl"]!;
        public static string Browser => _config["BrowserSettings:Browser"]!;
        public static bool Headless => _config.GetValue<bool>("BrowserSettings:Headless");
    }
}