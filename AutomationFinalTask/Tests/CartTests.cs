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


// Indica que esta clase contiene casos de prueba (Test Fixture).

namespace AutomationFinalTask.Tests
{

    [TestFixture]

    // Permite que las pruebas de esta clase puedan ejecutarse
    // en paralelo, siempre que no compartan recursos entre sí.
  //  [Parallelizable(ParallelScope.All)]
    public class CartTests
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
        // Caso de prueba 3
        // ==========================================
        // Verifica que un usuario pueda agregar un producto
        // al carrito de compras y que el contador del carrito
        // muestre el número correcto de productos agregados.
        [Test]
        public void UC3_Add_Product_To_Cart_Should_Show_Cart_Badge()
        {
            // Crea el objeto que representa la página de Login.
            var loginPage = new LoginPage(_driver);

            // Crea el objeto que representa la página de Inventario.
            var inventoryPage = new InventoryPage(_driver);

            // Crea el objeto que representa la página de detalle del producto.
            var productPage = new ProductPage(_driver);

            // Abre la página principal de SauceDemo.
            loginPage.Open();

            // Inicia sesión utilizando credenciales válidas.
            loginPage.Login("standard_user", "secret_sauce");

            // Abre el primer producto disponible del inventario.
            inventoryPage.OpenFirstProduct();

            // Agrega el producto al carrito de compras.
            productPage.AddToCart();

            // Verifica que el contador del carrito muestre "1",
            // indicando que se agregó correctamente un producto.
            Assert.That(
                productPage.GetCartBadgeText(),
                Is.EqualTo("1"));
        }

        // ==========================================
        // Método de limpieza
        // ==========================================
        // Se ejecuta automáticamente DESPUÉS de cada prueba.
        [TearDown]
        public void TearDown()
        {
            // Cierra todas las ventanas del navegador
            // y finaliza la sesión de Selenium.
            _driver.Quit();

            // Libera los recursos utilizados por el navegador.
            _driver.Dispose();
        }
    }
}