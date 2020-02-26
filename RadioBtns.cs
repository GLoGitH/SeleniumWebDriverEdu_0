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
using OpenQA.Selenium.Support.PageObjects;  //ByChained to combine multiple FindElement By. ... 's ... 


namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class RadioBtns : TestClass_default
    {

        [Test]
        public void TestRadioBtn1()
        {
            driver.Url = "https://formy-project.herokuapp.com/radiobutton";

            IWebElement radioBtn1 = driver.FindElement(By.Id("radio-button-1"));
            radioBtn1.Click();

            Thread.Sleep(3000); //in order to be able to visually see the result before closing the browser if I was watching 
        }

        [Test]
        public void TestRadioBtn2()
        {
            driver.Url = "https://formy-project.herokuapp.com/radiobutton";

            IWebElement radioBtn2 = driver.FindElement(By.CssSelector("input[value = 'option2']"));
            radioBtn2.Click();

            Thread.Sleep(3000); //in order to be able to visually see the result before closing the browser if I was watching 
        }


        [Test]
        public void TestRadioBtn3()
        {
            driver.Url = "https://formy-project.herokuapp.com/radiobutton";

            IWebElement radioBtn3 = driver.FindElement(By.XPath("html/body/div/div[3]/input"));
            radioBtn3.Click();

            Thread.Sleep(3000); //in order to be able to visually see the result before closing the browser if I was watching 
        }


        [Test]
        public void TestCheckBox2()
        {
            driver.Url = "https://formy-project.herokuapp.com/checkbox";

            IWebElement chkBox2 = driver.FindElement(By.CssSelector("input[aria-label='checkbox'][value='checkbox-2']"));
            //IWebElement chkBox2 = driver.FindElement(new ByChained(By.CssSelector("input[aria-label='checkbox']"),
            //                                                       By.CssSelector("input[value='checkbox-2']")
            //                                                       )
            //                                        );
            chkBox2.Click();

            Thread.Sleep(4000); //in order to be able to visually see the result before closing the browser if I was watching 
        }




    }
}
