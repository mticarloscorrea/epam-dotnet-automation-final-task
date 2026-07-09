using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFinalTask.Pages;

public class InventoryPage : BasePage
{
    private static readonly By BurgerMenuButton = By.Id("react-burger-menu-btn");
    private static readonly By AppLogo = By.ClassName("app_logo");
    private static readonly By CartLink = By.ClassName("shopping_cart_link");
    private static readonly By SortDropdown = By.ClassName("product_sort_container");
    private static readonly By InventoryItems = By.ClassName("inventory_item");
    private static readonly By FirstProductName = By.CssSelector(".inventory_item_name");

    public InventoryPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsLoaded()
    {
        return FindVisible(BurgerMenuButton).Displayed
               && FindVisible(AppLogo).Text == "Swag Labs"
               && FindVisible(CartLink).Displayed
               && FindVisible(SortDropdown).Displayed
               && HasInventoryItems();
    }

    public bool IsBurgerMenuDisplayed() => FindVisible(BurgerMenuButton).Displayed;

    public bool IsLogoDisplayed() => FindVisible(AppLogo).Text == "Swag Labs";

    public bool IsCartDisplayed() => FindVisible(CartLink).Displayed;

    public bool IsSortDropdownDisplayed() => FindVisible(SortDropdown).Displayed;

    public bool HasInventoryItems() => FindAll(InventoryItems).Count > 0;

    public void SortByPriceLowToHigh()
    {
        var select = new SelectElement(FindVisible(SortDropdown));
        select.SelectByValue("lohi");
    }

    public void OpenFirstProduct()
    {
        FindAll(FirstProductName).First().Click();
    }
}
