using OpenQA.Selenium;

namespace AutomationFinalTask.Drivers;

public sealed class DriverManager
{
    private static readonly Lazy<DriverManager> LazyInstance = new(() => new DriverManager());
    private readonly ThreadLocal<IWebDriver?> _driver = new();

    private DriverManager()
    {
    }

    public static DriverManager Instance => LazyInstance.Value;

    public IWebDriver GetDriver(string browser, bool headless = false)
    {
        if (_driver.Value is null)
        {
            _driver.Value = DriverFactory.CreateDriver(browser, headless);
            _driver.Value.Manage().Window.Maximize();
        }

        return _driver.Value;
    }

    public void QuitDriver()
    {
        if (_driver.Value is null)
        {
            return;
        }

        _driver.Value.Quit();
        _driver.Value.Dispose();
        _driver.Value = null;
    }

    public void ClearDriver()
    {
        _driver.Value = null;
    }
}
