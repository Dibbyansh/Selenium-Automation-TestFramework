using OpenQA.Selenium;

namespace OrangeHRM_Revised.Utilities
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver _driver)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

                var folderPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
                Directory.CreateDirectory(folderPath);

                string testName = TestContext.CurrentContext.Test.Name.Replace(" ", "_");

                string fileName = $"{testName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
                string filePath = Path.Combine(folderPath, fileName);

                screenshot.SaveAsFile(filePath);

                TestContext.AddTestAttachment(filePath, "Screenshot on Failure");

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
                return null!;
            }
        }
    }
}
