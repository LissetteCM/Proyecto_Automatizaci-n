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
              
                pom.clickOptionOne();
                Thread.Sleep(1000);
                pom.clickOptionTwo();
                Thread.Sleep(1000);
                pom.clickOption();
                Thread.Sleep(1000);
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
              
                SelectElement fruit = new SelectElement(driver.FindElement(By.CssSelector("#fruits")));
                          fruit.SelectByText("Orange");
     


                Assert.That(pom.getMsgFruit(), Is.EqualTo("You have selected Orange"));

            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }


    }
}

