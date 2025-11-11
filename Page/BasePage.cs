

using OpenQA.Selenium;

namespace Proyecto_Automatización.Page
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ingresarTbx(By selector, string texto)
        {
            driver.FindElement(selector).SendKeys(texto);
        }
        public void clickBtn(By selector)
        {
            driver.FindElement(selector).Click();
        }

        public string ObtenerTexto(By selector)
        {
            return driver.FindElement(selector).Text;   
        }
    }
}
