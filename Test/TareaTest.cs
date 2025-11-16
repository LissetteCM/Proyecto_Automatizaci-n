using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Proyecto_Automatización.Page;


namespace Proyecto_Automatización.Test
{
    internal class TareaTest : BaseTest
    {
     

        [Test]
        public void interactuarCheckBox()
        {
            try
            {
                driver.Navigate().GoToUrl("https://demoqa.com/checkbox");
                LoginPage pom = new LoginPage(driver);
                Thread.Sleep(2000);
                pom.clickOptionOne();
                Thread.Sleep(2000);
                pom.clickOptionTwo();
                Thread.Sleep(2000);
                pom.clickOption();

                Assert.That(pom.getMsgSelec(), Does.Contain("excelFile"));


            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }

        [Test]
        public void ddl()
        {
            try
            {
                driver.Navigate().GoToUrl("https://letcode.in/dropdowns");
                LoginPage pom = new LoginPage(driver);
                pom.fruits();
                Thread.Sleep(2000);
                SelectElement fruit = new SelectElement(driver.FindElement(By.CssSelector("#fruits")));
                          fruit.SelectByText("Orange");
                Thread.Sleep(2000);


                Assert.That(pom.getMsgFruit(), Is.EqualTo("You have selected Orange"));

            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }


    }
}

