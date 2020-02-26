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



namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class SelectOneRadioBtnFromList : TestClass_default
    {
        [Test]
        public void TestSelectByCss_radio()
        {
            driver.Url = "https://formy-project.herokuapp.com/radiobutton";

            IWebElement specRadioBtn = driver.FindElement(By.CssSelector("input[value='option2']"));
            specRadioBtn.Click();

            Thread.Sleep(2000);
        }



        [Test]
        public void TestSelectByCss_li()
        {
            //driver.Url = "http://localhost:50842/lilist.html";
            driver.Url = "http://localhost:52163/lilist.html";


            IWebElement specliItem = driver.FindElement(By.CssSelector("#list li:nth-child(2)"));
            string strTest = specliItem.Text;
            Assert.AreEqual("throu", strTest);

            Thread.Sleep(2000);
        }


    }
}
