using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace MSTest
{
    [TestClass]
    public class WebTests
    {
        private readonly IWebDriver driver;
        private By googleSearchBox = By.Id("APjFqb");
        private By googleButtonSearch = By.Name("btnK");
        private By googleSearchResult = By.Id("_mly7ZuXpJo-YwbkPreH04A8_33");
        
        public By sendButton = By.Id("send");
        public By submitButton = By.CssSelector("input[type='submit'][value='Crear']");
        public int productId = 9;

        // variables para determinar cuanto va a tardar la prueba
        private int waitTime = 3000;

        public WebTests()
        {
            // Ruta al ChromeDriver
            // string chromeDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "drivers");
            driver = new ChromeDriver();
        }

        [TestInitialize]
        public void Setup()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Tiempo de espera implícito
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestCreateProduct()
        {
            driver.Navigate().GoToUrl("http://localhost:5043/Product/Create");
            Thread.Sleep(waitTime);

            driver.FindElement(By.Id("ProductName")).SendKeys("Laptop");
            driver.FindElement(By.Id("Category")).SendKeys("Electronics");
            driver.FindElement(By.Id("Price")).SendKeys("1200");
            driver.FindElement(By.Id("StockQuantity")).SendKeys("50");
            Thread.Sleep(waitTime);
            driver.FindElement(submitButton).Click();
            Thread.Sleep(waitTime);

            driver.Navigate().GoToUrl("http://localhost:5043/Product"); 
            Thread.Sleep(6000);
        }

        [TestMethod]
        public void TestEditProduct()
        {
            driver.Navigate().GoToUrl($"http://localhost:5043/Product/Edit/{productId}"); 
            Thread.Sleep(waitTime);

            driver.FindElement(By.Id("ProductName")).Clear();
            driver.FindElement(By.Id("ProductName")).SendKeys("Updated Laptop");

            Thread.Sleep(waitTime);
            driver.FindElement(sendButton).Click();
        }

        [TestMethod]
        public void TestDeleteProduct()
        {
            driver.Navigate().GoToUrl($"http://localhost:5043/Product/Delete/{productId}"); 
            Thread.Sleep(waitTime);

            driver.FindElement(sendButton).Click();
            Thread.Sleep(waitTime);

            Assert.AreNotEqual(driver.Url, $"http://localhost:5043/Product/Delete/{productId}"); 
        }
    }
}