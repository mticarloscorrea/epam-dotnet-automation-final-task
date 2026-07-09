using AutomationFinalTask.Pages;
using NUnit.Framework;

namespace AutomationFinalTask.Tests;

[TestFixture]
public class LoginTests : TestBase
{
    [Test]
    public void UC1_Login_With_Only_Username_Should_Show_Password_Required()
    {
        var loginPage = new LoginPage(Driver);

        loginPage.Open();
        loginPage.LoginOnlyUsername("standard_user");

        Assert.That(loginPage.GetErrorMessage(), Does.Contain("Password is required"));
    }

    [Test]
    public void UC2_Login_With_Valid_Credentials_Should_Show_Inventory_Page()
    {
        var loginPage = new LoginPage(Driver);
        var inventoryPage = new InventoryPage(Driver);

        loginPage.Open();
        loginPage.Login("standard_user", "secret_sauce");

        Assert.Multiple(() =>
        {
            Assert.That(inventoryPage.IsBurgerMenuDisplayed(), Is.True);
            Assert.That(inventoryPage.IsLogoDisplayed(), Is.True);
            Assert.That(inventoryPage.IsCartDisplayed(), Is.True);
            Assert.That(inventoryPage.IsSortDropdownDisplayed(), Is.True);
            Assert.That(inventoryPage.HasInventoryItems(), Is.True);
        });
    }
}
