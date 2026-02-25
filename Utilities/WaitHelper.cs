using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public static class WaitHelper
{
    private const int DefaultTimeoutSeconds = 10;

    public static IWebElement WaitForElement(IWebDriver driver, By locator, int seconds = DefaultTimeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

        return wait.Until(d =>
        {
            try
            {
                var element = d.FindElement(locator);
                return element.Displayed ? element : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (StaleElementReferenceException)
            {
                return null; // retry automatically
            }
        })!;
    }

    public static void WaitForSpinnerToDisappear(IWebDriver driver, By locator, int seconds = DefaultTimeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

        wait.Until(d =>
        {
            try
            {
                var elements = d.FindElements(locator);
                return elements.Count == 0 || elements.All(e => !e.Displayed);
            }
            catch (StaleElementReferenceException)
            {
                return false; // retry instead of exiting early
            }
        });
    }

    public static void WaitUntil(IWebDriver driver, Func<IWebDriver, bool> condition, int seconds = DefaultTimeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

        wait.Until(d =>
        {
            try
            {
                return condition(d);
            }
            catch (StaleElementReferenceException)
            {
                return false; // retry
            }
        });
    }
}