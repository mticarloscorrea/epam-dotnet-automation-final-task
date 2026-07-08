# EPAM .NET Automation Final Task

## Project Description

This project contains automated UI tests for the **SauceDemo** web application using **Selenium WebDriver**, **C#**, and **NUnit**.

The project follows the **Page Object Model (POM)** design pattern to improve code readability, maintainability, and reusability.

**Application Under Test:**

https://www.saucedemo.com/

---

## Technology Stack

- C#
- .NET 8
- Selenium WebDriver
- NUnit
- ChromeDriver
- FirefoxDriver

---

## Project Structure

```
AutomationFinalTask
│
├── Drivers
│   └── DriverFactory.cs
│
├── Pages
│   ├── InventoryPage.cs
│   ├── LoginPage.cs
│   └── ProductPage.cs
│
├── Tests
│   ├── CartTests.cs
│   └── LoginTests.cs
│
└── README.md
```

---

## Test Cases

### UC-1 - Login with Only Username

**Objective**

Verify that the application displays an error message when the password field is empty.

**Test Steps**

1. Open the SauceDemo application.
2. Enter a valid username.
3. Leave the password field empty.
4. Click the **Login** button.

**Expected Result**

The application displays the following validation message:

```
Password is required
```

---

### UC-2 - Login with Valid Credentials

**Objective**

Verify that a registered user can log in successfully.

**Test Steps**

1. Open the SauceDemo application.
2. Enter a valid username.
3. Enter a valid password.
4. Click the **Login** button.

**Expected Result**

The Inventory page is displayed successfully.

The following elements should be visible:

- Burger menu
- Swag Labs logo
- Shopping cart
- Product sorting dropdown
- Inventory items

---

### UC-3 - Add Product to Cart

**Objective**

Verify that a product can be added to the shopping cart.

**Test Steps**

1. Log in with valid credentials.
2. Open the first product.
3. Click **Add to cart**.

**Expected Result**

The shopping cart badge displays:

```
1
```

---

## Test Credentials

| Username | Password |
|----------|----------|
| standard_user | secret_sauce |

---

## Design Pattern

This project follows the **Page Object Model (POM)** pattern.

The Page Object Model separates:

- Test logic
- Page elements
- User actions

This makes the automation framework easier to maintain and extend.

---

## Author

Carlos Eduardo Correa Brito

EPAM .NET Automation Final Task
