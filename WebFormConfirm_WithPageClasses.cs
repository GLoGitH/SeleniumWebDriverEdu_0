using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Interactions;    //for Action class 
//using OpenQA.Selenium.Support.UI;      //for the WebDriverWait
//using SeleniumExtras.WaitHelpers;      //for ExppectedConditions

namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class WebFormConfirm_WithPageClasses : TestClass_default
    {

        [Test]
        public void TestFullForm()
        {
            driver.Url = "https://formy-project.herokuapp.com/form";

            Pages.FormPage formPage = new Pages.FormPage(driver);
            formPage.submitForm();

            Pages.ConfirmationPage  confirmationPage= new Pages.ConfirmationPage(driver);
            confirmationPage.waitForAlertMsgOnPage();

            string ExpectedConfirmationMsg = "The form was successfully submitted!";
            Assert.AreEqual(ExpectedConfirmationMsg, confirmationPage.getAlertBannerText(driver));

            Thread.Sleep(2000);  //in order to be able to visually see the result before closing the browser if I was watching 

        }




    }
}
