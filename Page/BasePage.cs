

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Proyecto_Automatización.Page
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.driver = driver;
        }
        public void ingresarTbx(By selector, string texto)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
            driver.FindElement(selector).Clear();
            driver.FindElement(selector).SendKeys(texto);
        }
        public void clickBtn(By selector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(selector));
            driver.FindElement(selector).Click();
        }

        public string ObtenerTexto(By selector)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector)); 
            return driver.FindElement(selector).Text;   
        }
    }
}
