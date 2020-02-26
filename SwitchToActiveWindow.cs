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
    public class SwitchToActiveWindow : TestClass_default
    {

        [Test]
        public void TestSwitch2ActiveWin()
        {
            driver.Url = "https://formy-project.herokuapp.com/switch-window";

            IWebElement newTabBtn = driver.FindElement(By.Id("new-tab-button"));
            newTabBtn.Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); //moved to testClass_Default - just like driver 
            wait.Until(wd => wd.WindowHandles.Count == 2);

            string origHandle = driver.CurrentWindowHandle;
            foreach (string winHhandle in driver.WindowHandles)
            {
                if (origHandle != winHhandle)
                  driver.SwitchTo().Window(winHhandle);
                break;
            }

            Thread.Sleep(2000);

            driver.SwitchTo().Window(origHandle);

            Thread.Sleep(5000);

        }


    }
}
