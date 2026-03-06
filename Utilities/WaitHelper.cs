using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public static class WaitHelper
{
    private const int DefaultTimeoutSeconds = 10;

    public static IWebElement WaitForElement(IWebDriver driver, By locator, int seconds = DefaultTimeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        wait.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(StaleElementReferenceException));

        return wait.Until(d =>
        {
            var element = d.FindElement(locator);
            return element.Displayed ? element : null;
        })!;
    }

    public static void WaitForSpinnerToDisappear(IWebDriver driver, By locator, int seconds = DefaultTimeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        wait.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(StaleElementReferenceException));

        wait.Until(d =>
        {
            var elements = d.FindElements(locator);
            return elements.Count == 0 || elements.All(e => !e.Displayed);
        });
    }

    public static void WaitUntil(IWebDriver driver, Func<IWebDriver, bool> condition, int seconds = DefaultTimeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        wait.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(StaleElementReferenceException));

        wait.Until(d =>
        {
            return condition(d);
        });
    }

    public static void ClickWhenReady(IWebDriver driver, By locator, int seconds = DefaultTimeoutSeconds)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

        wait.IgnoreExceptionTypes(
            typeof(NoSuchElementException),
            typeof(StaleElementReferenceException)
        );

        var element = wait.Until(d =>
        {
            var el = d.FindElement(locator);
            return (el.Displayed && el.Enabled) ? el : null;
        });

        try
        {
            element.Click();
        }
        catch (ElementClickInterceptedException)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", element);
        }
    }
}