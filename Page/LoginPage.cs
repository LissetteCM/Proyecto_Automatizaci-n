

using OpenQA.Selenium;

namespace Proyecto_Automatización.Page
{
    public class LoginPage : BasePage
    {
        private By UsernameInput = By.Id("username");
        private By PassInput = By.Id("password");
        private By SubmitButton = By.Id("submit");

        private By MsgLoginExitoso = By.XPath("//h1[normalize-space()='Logged In Successfully']");
        private By MsgLoginErroneo = By.XPath("//div[@id='error']");

        

        public LoginPage(IWebDriver driver) : base(driver)
        {}

        public void ingresarUsuario(string usuario)
        {
            ingresarTbx(UsernameInput,usuario);
        }

        public void ingresarPass(string pass)
        {
            ingresarTbx(PassInput, pass);
        }

        public void clickSubmit()
        {
            clickBtn(SubmitButton);
        }

        public string getMsgLoginExitoso()
        {
            return ObtenerTexto(MsgLoginExitoso);
        }

        public string getMsgLoginErroneo()
        {
            return ObtenerTexto(MsgLoginErroneo);
        }
    }

}
