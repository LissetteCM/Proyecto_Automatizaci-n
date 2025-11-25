

using AventStack.ExtentReports;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Proyecto_Automatización.Test
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected ExtentTest test;
        private static AventStack.ExtentReports.ExtentReports extent;

        public string username = "";
        public string password = "";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("🚀 OneTimeSetUp ejecutado");

            // Ruta fija donde quieres guardar los reportes
            var reportPath = @"C:\Users\lisse\source\repos\Proyecto_Automatizaci-n\Reportes";

            // Crear carpeta si no existe
            Directory.CreateDirectory(reportPath);

            // usar nombres totalmente cualificados para evitar conflictos de namespace
            var spark = new AventStack.ExtentReports.Reporter.ExtentHtmlReporter(Path.Combine(reportPath, "ReporteAutomatizacion.html"));
            // declarar e instanciar también con nombre totalmente calificado
            AventStack.ExtentReports.ExtentReports extentLocal = new AventStack.ExtentReports.ExtentReports();
            extentLocal.AttachReporter(spark);

            extent = extentLocal;

            Console.WriteLine("📁 Reporte se generará en: " + reportPath);
        }
        [SetUp]
        public void Setup()
        {

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Info("inicializando navegador Edge");

            //Llamado al driver que se utilizará
            var options = new EdgeOptions();
            options.AddArgument("--headless=new");     // el modo headless clásico está obsoleto
            //options.AddArgument("--disable-gpu");
            //options.AddArgument("--window-size=1920,1080");
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("--disable-dev-shm-usage");
            driver = new EdgeDriver(options);
            //Conf para que el navegador levante maximizado
            driver.Manage().Window.Maximize();

            var Data = Utils.JsonReader.ReadLoginData();
            username = Data.username;
            password = Data.password;



        }
        public string TomarCaptura(string nombreTest)
        {
            try
            {
                string screenshotsDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotsDir);

                string filePath = Path.Combine(screenshotsDir, $"{nombreTest}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al tomar captura: " + ex.Message);
                return "";
            }
        }
        [TearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("❌ El test falló: " + TestContext.CurrentContext.Result.Message);

                string rutaCaptura = TomarCaptura(TestContext.CurrentContext.Test.Name);

                if (!string.IsNullOrEmpty(rutaCaptura))
                {
                    test.AddScreenCaptureFromPath(rutaCaptura);
                    test.Info("📸 Captura adjunta");
                }
            }
            else
            {
                test.Pass("✔ Test ejecutado correctamente.");
            }

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();

            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("🔥 Ejecutando OneTimeTearDown...");
            extent.Flush();
        }
    }
}
