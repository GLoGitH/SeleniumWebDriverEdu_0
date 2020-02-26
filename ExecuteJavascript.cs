using System;
using System.Collections.Generic;
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
    public class ExecuteJavascript : TestClass_default
    {
        [Test]
        public void TestJsExecr()
        {
            driver.Url = "https://formy-project.herokuapp.com/modal";

            IWebElement modalBtn = driver.FindElement(By.Id("modal-button"));
            modalBtn.Click();

            IWebElement closeBtn = driver.FindElement(By.Id("close-button"), 60, true);
            closeBtn.Click(); //returns an err 'notInteractable' as not present on page load, only present after js' reaction on clicking the modalBtn -- unless you wait for it, before clicking it ... 

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("alert(arguments[0].type);", modalBtn);  // as you already clicked it, I'll get js to alert the type of the button ... 

            try
            {
                driver.Quit();
            }
            catch (OpenQA.Selenium.UnhandledAlertException exc)
            { 
                //ignore it as it was actually expected, but did not take trouble to handle it -- cfr. Switch to Alert test
            }

            //Thread.Sleep(5000); //in order to be able to visually see the result before closing the browser if I was watching 
        }
    }
}
 