using Microsoft.Extensions.Configuration;

namespace AutomationFinalTask.Config;

public static class SettingsProvider
{
    private static readonly Lazy<TestSettings> LazySettings = new(LoadSettings);

    public static TestSettings Settings => LazySettings.Value;

    private static TestSettings LoadSettings()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables(prefix: "TA_")
            .Build();

        var settings = configuration.Get<TestSettings>() ?? new TestSettings();

        return new TestSettings
        {
            BaseUrl = string.IsNullOrWhiteSpace(settings.BaseUrl) ? "https://www.saucedemo.com" : settings.BaseUrl,
            Browser = string.IsNullOrWhiteSpace(settings.Browser) ? "chrome" : settings.Browser,
            TimeoutSeconds = settings.TimeoutSeconds <= 0 ? 10 : settings.TimeoutSeconds,
            Headless = settings.Headless
        };
    }
}
