using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

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

        [Category("Bing")]
        [Ignore("Ignorado este test por X motivo")]
        public void TestNavegar()
        {
            //llamado a la url que se va ha usar
            driver.Navigate().GoToUrl("https://www.bing.com/");

        }
        [Test]
        public void loginExitoso()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.CssSelector("#password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//h1[normalize-space()='Logged In Successfully']")).Displayed, Is.True);


        }
        [Test]
        public void loginUserErroneo()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.FindElement(By.Id("username")).SendKeys("estudiante");
            driver.FindElement(By.CssSelector("#password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//div[@id='error']")).Displayed, Is.True);


        }

        [Test]
        public void loginPassErroneo()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.FindElement(By.Id("username")).SendKeys("student");
            driver.FindElement(By.CssSelector("#password")).SendKeys("pass");
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);
            Assert.That(driver.FindElement(By.XPath("//div[@id='error']")).Displayed, Is.True);


        }

        [TestCase("student", "Password123", true)]
        [TestCase("student", "Password", false)]
        [TestCase("stu", "Password123", false)]
        public void loginTresEscenarios(string username, string password, bool resultado)
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.CssSelector("#password")).SendKeys(password);
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(2000);
            bool loginExitoso = driver.PageSource.Contains("Logged In Successfully");
            Assert.That(loginExitoso, Is.EqualTo(resultado));
        }   

        [Test]
        [Retry(2)]  // Reintenta la prueba hasta 2 veces si falla

        public void interactuarCheckBox()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
            // Expandir las opciones
            driver.FindElement(By.XPath("//button[@title='Toggle']")).Click();
            driver.FindElement(By.XPath("//li[3]//span[1]//button[1]")).Click();

            // Seleccionar la opcion Excel
            driver.FindElement(By.CssSelector("label[for='tree-node-excelFile']")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".text-success")).Text, Is.EqualTo("excelFile"));
        }

        [Test]
        public void ddl()
        {
            driver.Navigate().GoToUrl("https://letcode.in/dropdowns");
            SelectElement fruit = new SelectElement(driver.FindElement(By.CssSelector("#fruits")));
            fruit.SelectByText("Orange");
            Assert.That(fruit.SelectedOption.Text,Is.EqualTo("Orange"));
            Assert.That(driver.FindElement(By.CssSelector("p[class='subtitle']")).Text,Is.EqualTo("You have selected Orange"));
        }

        //IMPORTANTE hacer para que el driver no corra en segundo plano porque satura la maquina
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