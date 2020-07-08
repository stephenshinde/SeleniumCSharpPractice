using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
 

namespace AutomationPractice
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        


        [OneTimeSetUp]
        public void ExtentStart()
        {

        }
        [SetUp]
        public void Launch()
        {
            driver = new ChromeDriver();
            driver.Url = "http://automationpractice.com/index.php";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(30);
        }

        [Test]
        public void verifyPageTitle()
        {
          string actualTitle=  driver.Title;

            Assert.AreEqual(actualTitle, "My Store");
        }

        [Test]
        public void searchProduct()
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys("Faded Short Sleeve T-shirts");
            driver.FindElement(By.Name("submit_search")).Click();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void destroy()
        {
            driver.Close();
        }
    }
}