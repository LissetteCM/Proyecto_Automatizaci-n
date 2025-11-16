

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Proyecto_Automatización.Page
{
    public class LoginPage : BasePage
    {
        private By UsernameInput = By.Id("username");
        private By PassInput = By.Id("password");
        private By SubmitButton = By.Id("submit");

        private By MsgLoginExitoso = By.XPath("//h1[normalize-space()='Logged In Successfully']");
        private By MsgLoginErroneo = By.XPath("//div[@id='error']");

        private By SelectOptionOne = By.XPath("//button[@title='Toggle']");
        private By SelectOptionTwo = By.XPath("//li[3]//span[1]//button[1]");
        private By SelectOption = By.XPath("//label[@for='tree-node-excelFile']//span[@class='rct-checkbox']//*[name()='svg']");
        private By MsgSelec = By.XPath("//div[@id='result']");

        private By SelectFruit = By.XPath("(//select[@id='fruits'])[1]");
        private By SelectOptionOrange = By.XPath("(//select[@id='fruits'])[1]");
        private By MsgSelecFruit = By.XPath("(//p[@class='subtitle'])[1]");




        public LoginPage(IWebDriver driver) : base(driver)
        { }

        public void ingresarUsuario(string usuario)
        {
            ingresarTbx(UsernameInput, usuario);
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

        public void login(string usuario, string pass)
        {
            ingresarUsuario(usuario);
            ingresarPass(pass);
            clickSubmit();
        }

        public void clickOptionOne()
        {
            clickBtn(SelectOptionOne);
        }
        public void clickOptionTwo()
        {
            clickBtn(SelectOptionTwo);
        }
        public void clickOption()
        {
            clickBtn(SelectOption);
        }
        public string getMsgSelec()
        {
            return ObtenerTexto(MsgSelec);
        }
        public void fruits()
        {
            clickBtn(SelectFruit);
   
        }
        public void selecfruits()
        {
            clickBtn(SelectOptionOrange);

        }
        public string getMsgFruit()
        {
            return ObtenerTexto(MsgSelecFruit);
        }


    }

}
