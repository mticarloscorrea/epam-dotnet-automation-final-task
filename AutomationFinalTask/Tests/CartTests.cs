using AutomationFinalTask.Pages;
using NUnit.Framework;

namespace AutomationFinalTask.Tests;

[TestFixture]
public class CartTests : TestBase
{
    [Test]
    public void UC3_Add_Product_To_Cart_Should_Show_Cart_Badge()
    {
        var loginPage = new LoginPage(Driver);
        var inventoryPage = new InventoryPage(Driver);
        var productPage = new ProductPage(Driver);

        loginPage.Open();
        loginPage.Login("standard_user", "secret_sauce");
        Assert.That(inventoryPage.IsLoaded(), Is.True);

        inventoryPage.SortByPriceLowToHigh();
        inventoryPage.OpenFirstProduct();
        productPage.AddToCart();

        Assert.That(productPage.GetCartBadgeText(), Is.EqualTo("1"));
    }
}
