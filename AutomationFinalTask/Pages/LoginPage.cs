using AutomationFinalTask.Config;
using OpenQA.Selenium;

namespace AutomationFinalTask.Pages;

public class LoginPage : BasePage
{
    private static readonly By UsernameInput = By.Id("user-name");
    private static readonly By PasswordInput = By.Id("password");
    private static readonly By LoginButton = By.Id("login-button");
    private static readonly By ErrorMessage = By.CssSelector("[data-test='error']");

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public void Open()
    {
        Driver.Navigate().GoToUrl(SettingsProvider.Settings.BaseUrl);
        FindVisible(UsernameInput);
    }

    public void Login(string username, string password)
    {
        Type(UsernameInput, username);
        Type(PasswordInput, password);
        Click(LoginButton);
        ClosePasswordChangeAlertIfExists();
    }



    public void ClosePasswordChangeAlertIfExists()
    {
        try
        {
            var buttons = Driver.FindElements(By.CssSelector("button,a,input[type='button'],input[type='submit']"));
            foreach (var b in buttons)
            {
                var t=(b.Text??"").Trim().ToLowerInvariant();
                if(!b.Displayed) continue;
                if(t.Contains("skip")||t.Contains("later")||t.Contains("cancel")||t.Contains("omit")||t.Contains("después")||t.Contains("despues")||t.Contains("cancelar"))
                {
                    b.Click();
                    break;
                }
            }
        }
        catch{}
    }

    public void LoginOnlyUsername(string username)
    {
        Type(UsernameInput, username);
        Type(PasswordInput, string.Empty);
        Click(LoginButton);
    }

    public string GetErrorMessage()
    {
        return FindVisible(ErrorMessage).Text;
    }
}
