using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.IE;

using OpenQA.Selenium.Support.UI;  //value in ddl, WebDriverWait, .. 


namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class TestClass_default
    {
        protected internal IWebDriver driver;
        protected internal WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"E:\testing\webdriver");
            wait   = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        private void Test()
        {
            //driver.Url = "http://about:blank";
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
              driver.Quit();

        }
    }


}
