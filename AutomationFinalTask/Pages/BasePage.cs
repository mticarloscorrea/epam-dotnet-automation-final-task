using AutomationFinalTask.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinalTask.Pages;

public abstract class BasePage
{
    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SettingsProvider.Settings.TimeoutSeconds));
    }

    protected IWebDriver Driver { get; }

    protected WebDriverWait Wait { get; }

    protected IWebElement FindVisible(By locator)
    {
        return Wait.Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed ? element : null;
        });
    }

    protected IWebElement FindClickable(By locator)
    {
        return Wait.Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed && element.Enabled ? element : null;
        });
    }

    protected IReadOnlyCollection<IWebElement> FindAll(By locator)
    {
        return Wait.Until(driver =>
        {
            var elements = driver.FindElements(locator);
            return elements.Count > 0 ? elements : null;
        });
    }

    protected bool Exists(By locator)
    {
        return Driver.FindElements(locator).Count > 0;
    }

    protected void Click(By locator)
    {
        var element = FindClickable(locator);
        try
        {
            element.Click();
        }
        catch (ElementClickInterceptedException)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }
    }

    protected void Type(By locator, string text)
    {
        var element = FindVisible(locator);
        element.Clear();
        element.SendKeys(text);
    }
}
