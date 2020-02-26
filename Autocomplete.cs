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
using OpenQA.Selenium.Support.UI;
using Selenium;




namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    class Autocomplete
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
        public void AutocompleteTest() 
        {
            driver.Url = "http://formy-project.herokuapp.com/autocomplete";

            IWebElement autoCompleteCtrl = driver.FindElement(By.Id("autocomplete"));
            autoCompleteCtrl.Click();
            autoCompleteCtrl.SendKeys("1555 Park Blvd Palo Alto, California, USA");

            Thread.Sleep(2000);

            autoCompleteCtrl.SendKeys(Keys.ArrowDown);

            Thread.Sleep(2000);


            ///???????????



            try
            {
              IWebElement autoCompleteResult = driver.FindElement(By.ClassName("pac-item"));
              autoCompleteResult.SendKeys(Keys.Return);
            }
            catch(ElementNotInteractableException exc)
            {
                //ignore this exc -- by looking at it, you see the autocomplete has filled in fields ... 
            }
            finally
            {

              IWebElement zipCodeCtrl = driver.FindElement(By.Id("postal_code"), 5);
              Assert.AreEqual("94306", zipCodeCtrl.GetAttribute("value"));
            }
            Thread.Sleep(5000); //in order to be able to see the result before closing the browser

        }


    }
}
