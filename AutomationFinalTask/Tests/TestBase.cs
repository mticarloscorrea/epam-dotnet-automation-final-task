using System.Reflection;
using AutomationFinalTask.Config;
using AutomationFinalTask.Drivers;
using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationFinalTask.Tests;

public abstract class TestBase
{
    protected IWebDriver Driver = null!;
    protected ILog Log = null!;

    [OneTimeSetUp]
    public void ConfigureLogger()
    {
        var logRepository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
        var configFile = new FileInfo(Path.Combine(AppContext.BaseDirectory, "log4net.config"));
        XmlConfigurator.Configure(logRepository, configFile);
        Log = LogManager.GetLogger(GetType());
    }

    [SetUp]
    public void SetUp()
    {
        var settings = SettingsProvider.Settings;
        Log.Info($"Starting test with browser: {settings.Browser}");
        Driver = DriverManager.Instance.GetDriver(settings.Browser, settings.Headless);
    }

    [TearDown]
    public void TearDown()
    {
        var result = TestContext.CurrentContext.Result.Outcome.Status;
        Log.Info($"Finished test: {TestContext.CurrentContext.Test.Name}. Result: {result}");
        Driver?.Quit();
        Driver?.Dispose();
        DriverManager.Instance.ClearDriver();
    }
}
