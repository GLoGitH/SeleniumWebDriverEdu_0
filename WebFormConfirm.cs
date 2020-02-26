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
using OpenQA.Selenium.Support.UI;      //for the WebDriverWait
using SeleniumExtras.WaitHelpers;      //for ExppectedConditions




namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class WebFormConfirm : TestClass_default
    {
        [Test]
        public void TestFullForm()
        {
            driver.Url = "https://formy-project.herokuapp.com/form";

            IWebElement firstNameField = driver.FindElement(By.Id("first-name"));
            firstNameField.SendKeys("John");

            IWebElement lastNameField = driver.FindElement(By.Id("last-name"));
            lastNameField.SendKeys("Doe");
            
            IWebElement JobTitleField = driver.FindElement(By.Id("job-title"));
            JobTitleField.SendKeys("QA Engineer");

            IWebElement eduLevelField = driver.FindElement(By.Id("radio-button-3"));
            eduLevelField.Click();

            IWebElement sexField = driver.FindElement(By.Id("checkbox-2"));
            sexField.Click();

            IWebElement ddlItem = driver.FindElement(By.CssSelector("option[value='3']"));
            ddlItem.Click();

            IWebElement dateField = driver.FindElement(By.Id("datepicker"));
            dateField.SendKeys(String.Format("{0}/{1}/{2}", DateTime.Now.Month, DateTime.Now.Day+1, DateTime.Now.Year));
            dateField.SendKeys(Keys.Enter); //close the calender popup 

            IWebElement submitBtn = driver.FindElement(By.CssSelector(".btn.btn-lg.btn-primary"));
            submitBtn.Click();

            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            //var element = wait.Until( () =>
            //{
            //    var e = driver.FindElement(By.ClassName("alert"));
            //    if (e.Displayed)
            //        return e;
            //});


            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //IWebElement alertOnPage = wait.Until(
            //    (By.ClassName("alert")));


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement alertOnPage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("alert")));

            string ExpectedConfirmationMsg = "The form was successfully submitted!";
            Assert.AreEqual(ExpectedConfirmationMsg, alertOnPage.Text);

            Thread.Sleep(2000);  //in order to be able to visually see the result before closing the browser if I was watching 
        }

    }
}
