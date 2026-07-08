\# SauceDemo Selenium C# NUnit Tests



Automation project for testing https://www.saucedemo.com using Selenium WebDriver, C# and NUnit.



\## Test cases



\### UC-1 Login with only username

\- Enter username.

\- Clear password.

\- Click Login.

\- Verify "Password is required" message.



\### UC-2 Login with valid credentials

\- Login with standard user.

\- Verify inventory page elements:

&#x20; - Burger menu

&#x20; - Swag Labs label

&#x20; - Shopping cart

&#x20; - Sorting dropdown

&#x20; - Inventory items



\### UC-3 Add product to cart

\- Login with standard user.

\- Open product details.

\- Add product to cart.

\- Verify cart badge shows number of added products.



\## Credentials



Username: standard\_user  

Password: secret\_sauce



\## Tools



\- C#

\- Selenium WebDriver

\- NUnit

\- ChromeDriver

\- FirefoxDriver

