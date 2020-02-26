using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;  //for Action class 
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace Selenium_Essential_LinkedIn 
{
    [TestFixture]
    public class DragAndDrop : TestClass_default
    {

        [Test]
        public void TestDragAndDrop()
        {
            driver.Url = "https://formy-project.herokuapp.com/dragdrop";

            IWebElement box = driver.FindElement(By.Id("box"));
            IWebElement img = driver.FindElement(By.Id("image"));

            Actions actions = new Actions(driver);
            actions.DragAndDrop(img, box).Build().Perform(); //Build().Perform() to actually carry out the action :) ! 


            Thread.Sleep(2000);
            IWebElement img2 = driver.FindElement(By.Id("image"));
            //Assert.Less(img2.Location.X, img.Location.X);

            //Thread.Sleep(5000); //in order to be able to visually see the result before closing the browser if I was watching 


        }

    }
}
