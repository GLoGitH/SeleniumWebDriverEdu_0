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
    public class Dropdown : TestClass_default
    {

        [Test]
        public void TestDropdown()
        {
            driver.Url = "https://formy-project.herokuapp.com/dropdown";

            IWebElement dropDownMenu = driver.FindElement(By.Id("dropdownMenuButton"));
            dropDownMenu.Click();

            IWebElement autocompleteItem = driver.FindElement(By.Id("autocomplete"));
            autocompleteItem.Click();

            Thread.Sleep(2000);  //give time to load page 
            Assert.AreEqual("https://formy-project.herokuapp.com/autocomplete", driver.Url);

            Thread.Sleep(3000);  //in order to be able to visually see the result before closing the browser if I was watching 

        }


    }
}
