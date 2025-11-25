

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

                //test.pass hace que se coloque como positivo/negativo en el reporte
                //test.info hace que se coloque como informativo en el reporte
                driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
                LoginPage pom = new LoginPage(driver);
                test.Pass("Se ha navegado correctamente");
                pom.ingresarUsuario(username);
                test.Pass("Se ha ingresado el usuario"+username);
                pom.ingresarPass(password);
                test.Pass("Se ha ingresado la contraseña");
                pom.clickSubmit();
                test.Info("Se ha seleccionado el btn login correctamente");


                Thread.Sleep(2000);
                Assert.That(pom.getMsgLoginExitoso(), Is.EqualTo("Logged In Successfully"));
                test.Info("Se valida el msj de login exitoso");
                Assert.That(driver.Url, Is.EqualTo("https://practicetestautomation.com/logged-in-successfully/"));
                test.Info("Se valida la url");


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
                pom.ingresarUsuario(username+"45");
                test.Pass("Se ha ingresado  un usuario erroneo"+ username);
                pom.ingresarPass(password);
                pom.clickSubmit();
                Thread.Sleep(2000);
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your username is invalid!"));
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
                pom.login(username, password+"123");
                Thread.Sleep(2000);
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your password is invalid!"));

            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }
        [Test]
        public void loginCaptura()
        {
            try
            {
                driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");
                LoginPage pom = new LoginPage(driver);
                pom.ingresarUsuario(username + "45");
                test.Pass("Se ha ingresado  un usuario erroneo" + username);
                pom.ingresarPass(password);
                pom.clickSubmit();
                Thread.Sleep(2000);
                Assert.That(pom.getMsgLoginErroneo(), Is.EqualTo("Your username "));
            }
            catch (Exception ex)
            {
                Assert.Fail("Error inesperado de la prueba" + ex.Message);
            }

        }




    }
}
