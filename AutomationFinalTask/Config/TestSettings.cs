namespace AutomationFinalTask.Config;

public sealed class TestSettings
{
    public string BaseUrl { get; init; } = "https://www.saucedemo.com";
    public string Browser { get; init; } = "chrome";
    public int TimeoutSeconds { get; init; } = 10;
    public bool Headless { get; init; } = false;
}
