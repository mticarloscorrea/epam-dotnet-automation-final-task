using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFinalTask.Drivers
{

    // Se declara una clase estática.
    // - Sus métodos pueden llamarse directamente.
    // Ejemplo:
    // IWebDriver driver = DriverFactory.CreateDriver("chrome");
    public static class DriverFactory
    {
        // Método público y estático.
        //
        // Recibe como parámetro el nombre del navegador ("chrome", "firefox", etc.)
        // y devuelve un objeto que implementa la interfaz IWebDriver.
        //
        // IWebDriver es la interfaz principal de Selenium que permite:
        // - Abrir páginas web.
        // - Buscar elementos.
        // - Dar clic.
        // - Escribir texto.
        // - Obtener información de la página.
        public static IWebDriver CreateDriver(string browser)
        {
            // Convierte el texto recibido a minúsculas para evitar problemas.
       
            // Así evitamos errores por diferencias entre mayúsculas y minúsculas.
            if (browser.ToLower() == "firefox")

                // Si el usuario indicó Firefox,
                // se crea una nueva instancia del navegador Firefox
                // y se devuelve como IWebDriver.
                return new FirefoxDriver();

            // Si el navegador no es Firefox,
            // por defecto se abre Google Chrome.
            //
            // Esto significa que si llamamos:
            //
            // DriverFactory.CreateDriver("chrome");
            //
            // o incluso
            //
            // DriverFactory.CreateDriver("cualquier cosa");
            //
            // el método abrirá Chrome.
            return new ChromeDriver();
        }
    }
}