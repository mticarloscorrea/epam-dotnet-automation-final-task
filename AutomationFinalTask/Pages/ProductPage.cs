// Importa las clases principales de Selenium.
// Permite utilizar IWebDriver, IWebElement, By, FindElement(), etc.
using OpenQA.Selenium;

// Namespace que agrupa todas las clases que representan
// las páginas de la aplicación (Page Object Model).
namespace AutomationFinalTask.Pages
{

    // Esta clase representa la página de detalle de un producto.
    // Contiene las acciones que el usuario puede realizar en esa página.
    public class ProductPage
    {
        // Variable privada que almacena la instancia del navegador.
        // readonly indica que solo puede asignarse una vez
        // dentro del constructor.
        private readonly IWebDriver _driver;

        // Constructor de la clase.
        // Recibe el navegador que fue creado previamente
        // y lo almacena para utilizarlo en los métodos.
        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // ============================
        // Métodos de la página
        // ============================

        // Agrega el producto al carrito de compras.
        // Busca un botón cuyo atributo id comience con "add-to-cart"
        // utilizando un selector CSS.
        //
        // Ejemplos de ids que coinciden:
        // add-to-cart-sauce-labs-backpack
        // add-to-cart-sauce-labs-bike-light
        public void AddToCart()
        {
            _driver
                .FindElement(By.CssSelector("button[id^='add-to-cart']"))
                .Click();
        }

        // Obtiene el número de productos que aparecen
        // en el icono del carrito de compras.
        //
        // Por ejemplo:
        //
        // 1
        // 2
        // 3
        //
        // Este valor será utilizado por los casos de prueba
        // para verificar que el producto fue agregado correctamente.
        public string GetCartBadgeText()
        {
            return _driver
                .FindElement(By.ClassName("shopping_cart_badge"))
                .Text;
        }
    }


}