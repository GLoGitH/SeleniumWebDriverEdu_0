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
using OpenQA.Selenium.Support.UI;      //for the WebDriverWait
using SeleniumExtras.WaitHelpers;      //for ExpectedConditions




namespace Selenium_Essential_LinkedIn
{
    [TestFixture]
    public class cleanup_test_code : TestClass_default
    {
        [Test]
        public void TestFullForm()
        {
            driver.Url = "https://formy-project.herokuapp.com/form";

            submitForm(driver);

            waitForAlertMsgOnPage(driver);

            string ExpectedConfirmationMsg = "The form was successfully submitted!";
            Assert.AreEqual(ExpectedConfirmationMsg, getAlertBannerText(driver));

            Thread.Sleep(2000);  //in order to be able to visually see the result before closing the browser if I was watching 
        }


        public static void submitForm(IWebDriver driver) 
        {
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
            dateField.SendKeys(String.Format("{0}/{1}/{2}", DateTime.Now.Month, DateTime.Now.Day + 1, DateTime.Now.Year));
            dateField.SendKeys(Keys.Enter); //close the calender popup 

            IWebElement submitBtn = driver.FindElement(By.CssSelector(".btn.btn-lg.btn-primary"));
            submitBtn.Click();
        }


        public static void waitForAlertMsgOnPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("alert")));
        }

        public static string getAlertBannerText(IWebDriver driver)
        { 
          return driver.FindElement(By.ClassName("alert")).Text;
        }



    }
}
