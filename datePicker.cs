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
    public class datePicker : TestClass_default
    {
        [Test]
        public void TestDatePickr()
        {
            driver.Url = "https://formy-project.herokuapp.com/datepicker";

            IWebElement dateField = driver.FindElement(By.Id("datepicker"));
            string dateToSet = String.Format("{0}/{1}/{2}", DateTime.Today.AddDays(2).Month.ToString("00"), DateTime.Today.AddDays(2).Day, DateTime.Today.AddDays(2).Year);
            dateField.SendKeys(dateToSet);
            //dateField.SendKeys(Keys.Return);
            dateField.SendKeys(Keys.Enter);

            IWebElement dateField2 = driver.FindElement(By.Id("datepicker"));
            string dateBeingSet = dateField2.GetAttribute("value");

            Assert.AreEqual(dateBeingSet, dateToSet);

            Thread.Sleep(2000);  //in order to be able to visually see the result before closing the browser if I was watching 
        }


    }
}
