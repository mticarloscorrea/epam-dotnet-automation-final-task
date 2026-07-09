# SauceDemo Selenium C# NUnit Tests

Automation project for testing [SauceDemo](https://www.saucedemo.com) using Selenium WebDriver, C# and NUnit.

## Architecture

The project uses **Page Object Model (POM)** and a basic **Factory + Singleton Driver Manager** structure.

- `Pages`: page objects with locators and user actions.
- `Drivers`: browser creation and driver lifecycle management.
- `Config`: app settings and browser configuration.
- `Tests`: NUnit test cases.
- `log4net.config`: console and file logging.

## Test Cases

### UC-1 Login with only username

- Open login page.
- Enter username.
- Leave password empty.
- Click Login.
- Verify the `Password is required` error message.

### UC-2 Login with valid credentials

- Login with standard user.
- Verify inventory page elements:
  - Burger menu
  - Swag Labs label
  - Shopping cart
  - Sorting dropdown
  - Inventory items

### UC-3 Add product to cart

- Login with standard user.
- Validate inventory page is loaded.
- Sort products by price from low to high.
- Open the first product.
- Add product to cart.
- Verify the cart badge shows `1`.

## Credentials

```text
Username: standard_user
Password: secret_sauce
```

## Tools

- C#
- .NET 8
- Selenium WebDriver
- Selenium Support / WebDriverWait
- NUnit
- ChromeDriver
- GeckoDriver
- log4net

## Configuration

Default configuration is in:

```text
AutomationFinalTask/appsettings.json
```

Example:

```json
{
  "BaseUrl": "https://www.saucedemo.com",
  "Browser": "chrome",
  "TimeoutSeconds": 10,
  "Headless": false
}
```

## Notes about the Evaluation Criteria

- Browser driver implementation uses the Factory pattern.
- Driver lifecycle is managed by a Singleton `DriverManager`.
- POM is implemented with one class per page.
- Locators use stable IDs, CSS selectors and class names.
- Explicit waits are centralized in `BasePage`.
- Logging is implemented with log4net.

## Author

Carlos Eduardo Correa Brito

EPAM .NET Automation Final Task