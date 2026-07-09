using AutomationFinalTask.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationFinalTask.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateDriver(string browserName, bool headless = false)
    {
        var browser = ParseBrowser(browserName);

        return browser switch
        {
            BrowserType.Firefox => CreateFirefoxDriver(headless),
            BrowserType.Edge => CreateEdgeDriver(headless),
            _ => CreateChromeDriver(headless)
        };
    }

    private static BrowserType ParseBrowser(string browserName)
    {
        return Enum.TryParse(browserName, ignoreCase: true, out BrowserType browser)
            ? browser
            : BrowserType.Chrome;
    }

    private static IWebDriver CreateChromeDriver(bool headless)
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");

        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }

        return new ChromeDriver(options);
    }

    private static IWebDriver CreateFirefoxDriver(bool headless)
    {
        var options = new FirefoxOptions();

        if (headless)
        {
            options.AddArgument("--headless");
        }

        return new FirefoxDriver(options);
    }

    private static IWebDriver CreateEdgeDriver(bool headless)
    {
        var options = new EdgeOptions();
        options.AddArgument("--start-maximized");

        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }

        return new EdgeDriver(options);
    }
}
