using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationFinalTask.Pages
{
    public class LoginPage
    {
        // Variable privada que almacena la instancia del navegador
        // (Chrome, Firefox, Edge, etc.).
        // readonly significa que solo puede asignarse una vez en el constructor.
        private readonly IWebDriver _driver;

        // Constructor de la clase.
        // Recibe el navegador creado previamente y lo guarda
        // para utilizarlo en todos los métodos de esta página.
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // ============================
        // Elementos de la página
        // ============================

        // Obtiene el campo de texto "Username".
        // Busca el elemento cuyo id es "user-name".
        private IWebElement Username => _driver.FindElement(By.Id("user-name"));

        // Obtiene el campo de texto "Password".
        private IWebElement Password => _driver.FindElement(By.Id("password"));

        // Obtiene el botón "Login".
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        // Obtiene el mensaje de error que aparece cuando el login falla.
        // Se localiza utilizando un selector CSS.
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("[data-test='error']"));

        // ============================
        // Métodos de la página
        // ============================

        // Abre la página principal de SauceDemo.
        public void Open()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        // Realiza un inicio de sesión válido.
        // Parámetros:
        // username -> usuario que se escribirá.
        // password -> contraseña que se escribirá.
        public void Login(string username, string password)
        {
            // Limpia el campo usuario por si contiene información previa.
            Username.Clear();

            // Escribe el nombre de usuario.
            Username.SendKeys(username);

            // Limpia el campo contraseña.
            Password.Clear();

            // Escribe la contraseña.
            Password.SendKeys(password);

            // Hace clic en el botón Login.
            LoginButton.Click();
        }

        // Caso especial utilizado para validar el mensaje
        // "Password is required".
        // Solo escribe el usuario y deja la contraseña vacía.
        public void LoginOnlyUsername(string username)
        {
            // Limpia el campo usuario.
            Username.Clear();

            // Escribe el usuario.
            Username.SendKeys(username);

            // Limpia la contraseña para dejarla vacía.
            Password.Clear();

            // Hace clic en Login.
            LoginButton.Click();
        }

        // Devuelve el texto del mensaje de error mostrado en pantalla.
        // Este método será utilizado por los casos de prueba para verificar
        // que el mensaje sea el esperado.
        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}