using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;  //for Action class 
//using Selenium;



namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    class ScrollToElement
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(@"E:\testing\webdriver");
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
              driver.Quit();
        }

        [Test]
        public void ScrollToElemTest()
        {
            driver.Url = "http://formy-project.herokuapp.com/scroll";
            string nameToFillIn = "Meaghan Lewis";

            IWebElement nameField = driver.FindElement(By.Id("name"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(nameField).Build().Perform();
            nameField.SendKeys(nameToFillIn);
            
            IWebElement dateField = driver.FindElement(By.Id("date"));
            dateField.SendKeys("01/01/2020");

            Assert.AreEqual(nameToFillIn, nameField.GetAttribute("value"));
            Assert.AreEqual("01/01/2020", dateField.GetAttribute("value"));
            
            Thread.Sleep(5000); //in order to be able to visually see the result before closing the browser if I was watching 
        }

    }
}
