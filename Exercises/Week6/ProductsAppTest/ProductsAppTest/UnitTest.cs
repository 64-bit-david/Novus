using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace ProductsAppTest
{
    [TestClass]
    public class UnitTest
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            FirefoxOptions options = new FirefoxOptions();
            driver = new FirefoxDriver(options);
        }
        
        [Test]
        public void Test_Create_Product_Form()
        {
            driver.Url = "http://localhost:44305";
            driver.Navigate().GoToUrl("http://localhost:44305/Product/Create");
            driver.Manage().Window.Maximize();

            IWebElement FeedCreate = driver.FindElement(By.XPath("/html/body/div/h2"));
            string text =  FeedCreate.Text;

            NUnit.Framework.Assert.AreEqual("Create", text);
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);

        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
