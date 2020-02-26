using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class KeyboardAndMouseInput
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
              driver.Quit ();
        }




        [Test]
        public void KeybMouseInput()
        {
            driver.Url = "http://formy-project.herokuapp.com/keypress";

            IWebElement name = driver.FindElement(By.Id("name"));
            name.Click();
            name.SendKeys("Meaghan Lewis");

            IWebElement btnSubmit = driver.FindElement(By.Id("button"));
            btnSubmit.Click();
        }



    }
}
