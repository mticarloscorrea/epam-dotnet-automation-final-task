using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Importa la fábrica encargada de crear el navegador
// (Chrome, Firefox, etc.).
using AutomationFinalTask.Drivers;
// Importa las clases Page Object utilizadas en las pruebas.
using AutomationFinalTask.Pages;
// Importa el framework de pruebas NUnit.
// Proporciona atributos como [Test], [SetUp], [TearDown]
// y métodos de validación (Assert).
using NUnit.Framework;

// Importa las clases principales de Selenium.
// Permite utilizar IWebDriver para controlar el navegador.
using OpenQA.Selenium;



namespace AutomationFinalTask.Tests
{


    // Indica que esta clase contiene casos de prueba (Test Fixture).
    [TestFixture]

    // Permite que las pruebas de esta clase puedan ejecutarse
    // en paralelo, siempre que no compartan recursos entre sí.
   // [Parallelizable(ParallelScope.All)]
    public class LoginTests
    {
        // Variable que almacenará la instancia del navegador.
        // Será utilizada por todos los métodos de prueba.
        private IWebDriver _driver;

        // ==========================================
        // Método de inicialización
        // ==========================================
        // Se ejecuta automáticamente ANTES de cada prueba.
        [SetUp]
        public void Setup()
        {
            // Crea una instancia de Google Chrome utilizando
            // la fábrica de navegadores.
            _driver = DriverFactory.CreateDriver("chrome");

            // Maximiza la ventana del navegador para evitar
            // problemas con elementos ocultos o resoluciones pequeñas.
            _driver.Manage().Window.Maximize();
        }

        // ==========================================
        // Caso de prueba 1
        // ==========================================
        // Verifica que el sistema muestre el mensaje
        // "Password is required" cuando solo se captura
        // el nombre de usuario.
        [Test]
        public void UC1_Login_With_Only_Username_Should_Show_Password_Required()
        {
            // Crea un objeto que representa la página Login.
            var loginPage = new LoginPage(_driver);

            // Abre la página principal de SauceDemo.
            loginPage.Open();

            // Captura únicamente el usuario.
            // La contraseña permanecerá vacía.
            loginPage.LoginOnlyUsername("standard_user");

            // Verifica que el mensaje de error contenga
            // el texto esperado.
            Assert.That(
                loginPage.GetErrorMessage(),
                Does.Contain("Password is required"));
        }

        // ==========================================
        // Caso de prueba 2
        // ==========================================
        // Verifica que un usuario válido pueda iniciar sesión
        // correctamente y visualizar la página de inventario.
        [Test]
        public void UC2_Login_With_Valid_Credentials_Should_Show_Inventory_Page()
        {
            // Crea el objeto LoginPage.
            var loginPage = new LoginPage(_driver);

            // Crea el objeto InventoryPage.
            var inventoryPage = new InventoryPage(_driver);

            // Abre SauceDemo.
            loginPage.Open();

            // Inicia sesión utilizando credenciales válidas.
            loginPage.Login("standard_user", "secret_sauce");

            // ===============================
            // Validaciones de la página
            // ===============================

            // Verifica que el botón del menú hamburguesa
            // esté visible.
            Assert.That(inventoryPage.IsBurgerMenuDisplayed(), Is.True);

            // Verifica que el logotipo "Swag Labs"
            // se encuentre visible.
            Assert.That(inventoryPage.IsLogoDisplayed(), Is.True);

            // Verifica que el carrito de compras exista.
            Assert.That(inventoryPage.IsCartDisplayed(), Is.True);

            // Verifica que el combo para ordenar productos
            // esté disponible.
            Assert.That(inventoryPage.IsSortDropdownDisplayed(), Is.True);

            // Verifica que existan productos en el inventario.
            Assert.That(inventoryPage.HasInventoryItems(), Is.True);
        }

        // ==========================================
        // Método de limpieza
        // ==========================================
        // Se ejecuta automáticamente DESPUÉS de cada prueba.
        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                // Cierra todas las ventanas del navegador.
                _driver.Quit();

                // Libera los recursos utilizados por Selenium.
                _driver.Dispose();
            }
        }
    }
}