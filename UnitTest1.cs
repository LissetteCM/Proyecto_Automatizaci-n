using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Proyecto_Automatización
{
    public class Tests
    {
        //Inicialización de la variable del driver
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            //Llamado al driver que se utilizará
            var options = new EdgeOptions();
            driver = new EdgeDriver(options);
            //Conf para que el navegador levante maximizado
            driver.Manage().Window.Maximize();
        }

        // Si se elimina, desaparecen las pruebas
        [Test]
        public void TestNavegar()
        {
            //llamado a la url que se va ha usar
            driver.Navigate().GoToUrl("https://www.bing.com/");

        }

        //IMPORTANTE hacer para que el driver no corra en segundo plano porque satura la maquina
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
    }