using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace RetoTecnico.Steps
{
    [Binding]
    public class CompraSteps
    {
        private IWebDriver driver;

        [Given(@"que el usuario se registra con nombre ""(.*)"" y contraseña ""(.*)""")]
        public void DadoQueElUsuarioSeRegistra(string nombre, string contraseña)
        {
            driver = new ChromeDriver(); 
            driver.Navigate().GoToUrl("https://www.demoblaze.com/#");
            driver.FindElement(By.Id("signin2")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("sign-username")).SendKeys(nombre);
            driver.FindElement(By.Id("sign-password")).SendKeys(contraseña);
            driver.FindElement(By.XPath("//button[text()='Sign up']")).Click();
            Thread.Sleep(3000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept(); 
            Thread.Sleep(3000);
        }

        [When(@"el usuario selecciona la categoría ""(.*)"" y el producto ""(.*)""")]
        public void CuandoElUsuarioSeleccionaCategoriaYProducto(string categoria, string producto)
        {

            driver.FindElement(By.LinkText(categoria)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText(producto)).Click();
            Thread.Sleep(2000);
        }

        [When(@"añade el producto al carrito")]
        public void CuandoAñadeElProductoAlCarrito()
        {
            driver.FindElement(By.CssSelector(".btn.btn-success")).Click(); 
            Thread.Sleep(2000);
        }

        [Then(@"el usuario completa la compra")]
        public void EntoncesElUsuarioCompletaLaCompra()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept(); // Acepta el alert
            driver.FindElement(By.Id("cartur")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".btn.btn-success")).Click();
            Thread.Sleep(2000);
            driver.Quit(); 
        }
    }
}
