

using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Proyecto_Automatización.Test
{
    public class BaseTest
    {
        protected IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            //Llamado al driver que se utilizará
            var options = new EdgeOptions();
            driver = new EdgeDriver(options);
            //Conf para que el navegador levante maximizado
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();

            }
        }
}
}
