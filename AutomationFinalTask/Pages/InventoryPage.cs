using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Importa las clases principales de Selenium.
// Permite utilizar IWebDriver, IWebElement, By, FindElement(), etc.
using OpenQA.Selenium;

namespace AutomationFinalTask.Pages
{


    // Esta clase representa la página de inventario de SauceDemo.
    // Es la página que aparece después de iniciar sesión correctamente.
    //
    // Sigue el patrón Page Object Model (POM), donde cada página
    // del sistema se representa mediante una clase.
    public class InventoryPage
    {
        // Variable privada que almacena la instancia del navegador.
        // readonly indica que solo puede asignarse una vez
        // dentro del constructor.
        private readonly IWebDriver _driver;

        // Constructor de la clase.
        // Recibe el navegador creado previamente y lo guarda
        // para que todos los métodos puedan utilizarlo.
        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // ==================================
        // Métodos de validación de la página
        // ==================================

        // Verifica que el botón del menú lateral (hamburguesa)
        // esté visible en la página.
        //
        // Devuelve:
        // true  -> si el botón existe y es visible.
        // false -> si no está visible.
        public bool IsBurgerMenuDisplayed() =>
            _driver.FindElement(By.Id("react-burger-menu-btn")).Displayed;

        // Verifica que el logotipo de la aplicación sea "Swag Labs".
        //
        // Busca el elemento con la clase "app_logo"
        // y compara el texto mostrado.
        //
        // Devuelve true únicamente si el texto es exactamente
        // "Swag Labs".
        public bool IsLogoDisplayed() =>
            _driver.FindElement(By.ClassName("app_logo")).Text == "Swag Labs";

        // Verifica que el ícono del carrito de compras
        // esté visible en la pantalla.
        //
        // Devuelve:
        // true  -> si el carrito existe.
        // false -> si no existe.
        public bool IsCartDisplayed() =>
            _driver.FindElement(By.ClassName("shopping_cart_link")).Displayed;

        // Verifica que el combo para ordenar productos
        // (Nombre A-Z, Precio, etc.) esté visible.
        //
        // Devuelve true cuando el control existe
        // y puede visualizarse.
        public bool IsSortDropdownDisplayed() =>
            _driver.FindElement(By.ClassName("product_sort_container")).Displayed;

        // Verifica que existan productos en el inventario.
        //
        // FindElements() devuelve una lista de elementos.
        // Count obtiene la cantidad encontrada.
        //
        // Si la cantidad es mayor que cero,
        // significa que la página cargó correctamente
        // y existen productos disponibles.
        public bool HasInventoryItems() =>
            _driver.FindElements(By.ClassName("inventory_item")).Count > 0;

        // ==================================
        // Acciones sobre la página
        // ==================================

        // Abre el primer producto de la lista.
        //
        // FindElements() obtiene todos los nombres
        // de los productos.
        //
        // [0] representa el primer elemento de la colección,
        // ya que los índices en C# comienzan en cero.
        //
        // Finalmente realiza un clic sobre dicho producto.
        public void OpenFirstProduct()
        {
            _driver.FindElements(By.ClassName("inventory_item_name"))[0].Click();
        }
    }
}