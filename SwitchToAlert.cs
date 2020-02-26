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


namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class SwitchToAlert : TestClass_default
    {

        [Test]
        public void TestSimpleAlert()
        {
            driver.Url = "https://formy-project.herokuapp.com/switch-window";

            IWebElement alertBtn = driver.FindElement(By.Id("alert-button"));
            alertBtn.Click();

            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

            string alertText = alert.Text;
            Assert.AreEqual("This is a test alert!", alertText);

            Thread.Sleep(2000);
            alert.Accept();
            Thread.Sleep(3000);
        }



    }
}
