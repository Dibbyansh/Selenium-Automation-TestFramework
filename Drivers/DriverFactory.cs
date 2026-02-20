using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OrangeHRM_Revised.Utilities;

namespace OrangeHRM_Revised.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver InitDriver()
        {

            switch (ConfigManager.Browser)
            {
                case "Edge":
                    var edgeOptions = new EdgeOptions();
                   
                    if (ConfigManager.Headless)
                        edgeOptions.AddArgument("--headless=new");
                    
                    return new EdgeDriver(edgeOptions);

                default:
                    var chromeOptions = new ChromeOptions();

                    if (ConfigManager.Headless)
                    {
                        chromeOptions.AddArgument("--headless=new");
                    }

                    chromeOptions.AddArgument("--start-maximized");

                    return new ChromeDriver(chromeOptions);
            }
        }
    }
}
