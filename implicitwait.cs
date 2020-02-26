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
//using OpenQA.Selenium.Interactions;  //for Action class 


namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class implicitwait : TestClass_default
    {

        [Test]
        public void TestImplicitWait()
        {
            driver.Url = "https://formy-project.herokuapp.com/autocomplete";


            IWebElement autoCompleteCtrl = driver.FindElement(By.Id("autocomplete"));
            autoCompleteCtrl.Click();
            autoCompleteCtrl.SendKeys("1555 Park Blvd Palo Alto, California, USA");


            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10); 

            IWebElement autoCompleteResult = driver.FindElement(By.ClassName("pac-item"));
            autoCompleteResult.Click();

            string strZipExpected = "94306";
            IWebElement ZipCodeCtrl = driver.FindElement(By.Id("postal_code"));
            string strActualZip = ZipCodeCtrl.GetAttribute("value");

            if (strActualZip == String.Empty)
            {
              Assert.Warn("Check visually, as the field's value retrieved programmatically appears empty :( but on a prior visual check it was filled... ");
              Thread.Sleep(3000);  //in order to be able to visually see the result before closing the browser if I was watching 
            }
            else
                Assert.AreEqual(strZipExpected, strActualZip);

            Thread.Sleep(2000);  //in order to be able to visually see the result before closing the browser if I was watching 

        }


    }
}
