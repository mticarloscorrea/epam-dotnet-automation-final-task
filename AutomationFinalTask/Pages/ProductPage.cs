using OpenQA.Selenium;

namespace AutomationFinalTask.Pages;

public class ProductPage : BasePage
{
    private static readonly By ProductTitle = By.ClassName("inventory_details_name");
    private static readonly By AllButtons = By.CssSelector("button");
    private static readonly By CartBadge = By.ClassName("shopping_cart_badge");

    public ProductPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsLoaded()
    {
        return FindVisible(ProductTitle).Displayed;
    }

    public void AddToCart()
    {
        IsLoaded();

        var addButton = Wait.Until(driver =>
        {
            return driver.FindElements(AllButtons)
                .FirstOrDefault(button => button.Displayed
                    && button.Enabled
                    && IsAddToCartButton(button));
        });

        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", addButton);
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", addButton);

        Wait.Until(driver =>
        {
            var badgeExists = driver.FindElements(CartBadge)
                .Any(badge => badge.Displayed && badge.Text.Trim() == "1");

            var removeExists = driver.FindElements(AllButtons)
                .Any(button => button.Displayed && IsRemoveButton(button));

            return badgeExists || removeExists;
        });
    }

    public string GetCartBadgeText()
    {
        return Wait.Until(driver =>
        {
            var badge = driver.FindElements(CartBadge)
                .FirstOrDefault(element => element.Displayed && !string.IsNullOrWhiteSpace(element.Text));

            return badge?.Text.Trim();
        });
    }

    private static bool IsAddToCartButton(IWebElement button)
    {
        var text = button.Text.Trim();
        var id = button.GetAttribute("id") ?? string.Empty;
        var dataTest = button.GetAttribute("data-test") ?? string.Empty;

        return text.Equals("Add to cart", StringComparison.OrdinalIgnoreCase)
            || id.StartsWith("add-to-cart", StringComparison.OrdinalIgnoreCase)
            || dataTest.StartsWith("add-to-cart", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsRemoveButton(IWebElement button)
    {
        var text = button.Text.Trim();
        var id = button.GetAttribute("id") ?? string.Empty;
        var dataTest = button.GetAttribute("data-test") ?? string.Empty;

        return text.Equals("Remove", StringComparison.OrdinalIgnoreCase)
            || id.StartsWith("remove", StringComparison.OrdinalIgnoreCase)
            || dataTest.StartsWith("remove", StringComparison.OrdinalIgnoreCase);
    }
}
