

using Proyecto_Automatización.Page;

namespace Proyecto_Automatización.Test
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void loginExitoso()
        {
            try
            {
                driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
                LoginPage pom = new LoginPage(driver);
                pom.ingresarUsuario("student");
                pom.ingresarPass("Password123");
                pom.clickSubmit();


                Thread.Sleep(2000);
                Assert.That(pom.getMsgLoginExitoso(), Is.EqualTo("Logged In Successfully"));
                Assert.That(driver.Url, Is.EqualTo("https://practicetestautomation.com/logged-in-successfully/"));


            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }

        [Test]
        public void loginUsuarioErroneo()
        {
            try
            {
                driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
                LoginPage pom = new LoginPage(driver);
                pom.ingresarUsuario("studen");
                pom.ingresarPass("Password123");
                pom.clickSubmit();
                Thread.Sleep(2000);
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your username is invalid"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }
        [Test]
        public void loginPassErroneo()
        {
            try
            {
                driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
                LoginPage pom = new LoginPage(driver);
                pom.login("student", "Passwrd123");
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your password is invalid"));

            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }

    


    }
}
