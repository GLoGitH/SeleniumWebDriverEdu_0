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
    public class fileUploading : TestClass_default
    {

        [Test]
        public void TestDropdown()
        {
            driver.Url = "https://formy-project.herokuapp.com/fileupload";
            string strFileNameToBeUplaoded = "file-to-upload.png";

            IWebElement uploadField = driver.FindElement(By.Id("file-upload-field"));
            uploadField.SendKeys(strFileNameToBeUplaoded);

            IWebElement uploadField2 = driver.FindElement(By.Id("file-upload-field"));
            string strFileNameEntered = uploadField2.GetAttribute("value");

            Assert.AreEqual(strFileNameEntered, strFileNameToBeUplaoded);


            //************* Test 2 ********//
            IWebElement resetBtn = driver.FindElement(By.CssSelector(".btn-reset"));
            //IWebElement resetBtn = driver.FindElement(By.CssSelector("button[type = 'button']"));
            // sync issue ??? 
            resetBtn.Click();

            //IWebElement uploadField3 = driver.FindElement(By.Id("file-upload-field"));
            //Assert.IsEmpty(uploadField3.GetAttribute("value"));  //field should be cleared 


            Thread.Sleep(3000);  //in order to be able to visually see the result before closing the browser if I was watching 

        }
    }
}
