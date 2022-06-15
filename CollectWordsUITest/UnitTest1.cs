using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CollectWordsUITest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
             _driver = new ChromeDriver(DriverDirectory); // fast
            // _driver = new FirefoxDriver(DriverDirectory);  // slow
            // _driver = new EdgeDriver(DriverDirectory); // times out ... not working
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //_driver.Navigate().GoToUrl("http://localhost:3000/");
            _driver.Navigate().GoToUrl("file:///C:/andersb/javascript/collectwords/index.htm");
            Assert.AreEqual("Collect words", _driver.Title);

            IWebElement inputElement = _driver.FindElement(By.Id("wordInput"));
            inputElement.SendKeys("anders");

            IWebElement saveButton = _driver.FindElement(By.Id("saveButton"));
            saveButton.Click();

            IWebElement showButton = _driver.FindElement(By.Id("showButton"));
            showButton.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("output"));
            string text = outputElement.Text;

            Assert.AreEqual("anders", text);

            inputElement.Clear();
            inputElement.SendKeys("bor");
            saveButton.Click();
            showButton.Click();
            text = outputElement.Text;
            Assert.AreEqual("anders,bor", text);

            IWebElement clearButton = _driver.FindElement(By.Id("clearButton"));
            clearButton.Click();
            text = outputElement.Text;
            Assert.AreEqual("", text);

            showButton.Click();
            Assert.AreEqual("empty", outputElement.Text);
        }
    }
}
