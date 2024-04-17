using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {


            IWebDriver driver = new ChromeDriver();


            try
            {
                //Prueba de búsqueda
                prueba(driver);
                pruebaDos(driver);
                pruebaVerCarrito(driver);
                reseñasCaracteristicas(driver);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
            finally
            {
                // Cerrar el navegador al finalizar la prueba
                System.Threading.Thread.Sleep(10000);
                driver.Quit();
            }
        }

        static void prueba(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\Desktop\Pruebas-Proyecto Final\Pruebas PF\imagenesPrueba";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };


            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");

            IWebElement imagenP = driver.FindElement(By.CssSelector("#producto > div.producto__thumbs > img:nth-child(2)"));
            // Hacer clic en el elemento
            imagenP.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");

            IWebElement imagenS = driver.FindElement(By.CssSelector("#producto > div.producto__thumbs > img:nth-child(3)"));     
            imagenS.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 200)");
            System.Threading.Thread.Sleep(5000);

            IWebElement imagenT= driver.FindElement(By.CssSelector("#producto > div.producto__thumbs > img:nth-child(4)"));
            imagenT.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");

            IWebElement imagenC = driver.FindElement(By.CssSelector("#producto > div.producto__thumbs > img:nth-child(5)"));
            imagenC.Click();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            System.Threading.Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0)");

            imagenP.Click();
            System.Threading.Thread.Sleep(5000);


        }

        static void pruebaDos(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\Desktop\Pruebas-Proyecto Final\Pruebas PF\imagenesPrueba";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };


      

            IWebElement colorRed= driver.FindElement(By.CssSelector("#propiedad-color > div > label:nth-child(2) > p"));
            colorRed.Click();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            System.Threading.Thread.Sleep(5000);

            IWebElement colorYellow = driver.FindElement(By.CssSelector("#propiedad-color > div > label:nth-child(3) > p"));
            colorYellow.Click();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            System.Threading.Thread.Sleep(5000);

            IWebElement size = driver.FindElement(By.CssSelector("#propiedad-tamaño > div > label:nth-child(3) > p"));
            size.Click();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            System.Threading.Thread.Sleep(5000);

            IWebElement elemento = driver.FindElement(By.CssSelector("#incrementar-cantidad"));
            elemento.Click();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            System.Threading.Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 50)");

            IWebElement agregarCarrito = driver.FindElement(By.CssSelector("#agregar-al-carrito"));
            agregarCarrito.Click();
            System.Threading.Thread.Sleep(6000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");

        }


        static void pruebaVerCarrito(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\Desktop\Pruebas-Proyecto Final\Pruebas PF\imagenesPrueba";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };



            IWebElement agregarCarrito = driver.FindElement(By.CssSelector("#agregar-al-carrito"));
            agregarCarrito.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");


            IWebElement miCarrito = driver.FindElement(By.CssSelector("body > div.contenedor > header > nav > a:nth-child(2)"));
            miCarrito.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");


            IWebElement elemento = driver.FindElement(By.CssSelector("#carrito > div > div > div.carrito__body > div > div.carrito__producto-contenedor-precio > button"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", elemento);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            System.Threading.Thread.Sleep(5000);

            IWebElement boton = driver.FindElement(By.CssSelector("#carrito > div > div > div.carrito__footer > div.carrito__contenedor-btn-regresar > button"));
            boton.Click();
            System.Threading.Thread.Sleep(5000);

        }

        static void reseñasCaracteristicas(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\Desktop\Pruebas-Proyecto Final\Pruebas PF\imagenesPrueba";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };



            IWebElement boton = driver.FindElement(By.CssSelector("#mas-informacion > div.tabs > button:nth-child(2)"));
            boton.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 300)");
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");

            IWebElement botonEnvio = driver.FindElement(By.CssSelector("#mas-informacion > div.tabs > button:nth-child(3)"));
            botonEnvio.Click();
            System.Threading.Thread.Sleep(5000);
        }

    }
}
