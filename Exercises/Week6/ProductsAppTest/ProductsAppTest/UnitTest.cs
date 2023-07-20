using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace ProductsAppTest
{
    /// <summary>
    /// Test class for testing the ProductController.
    /// </summary>
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

        // Test case: Test_Create_Product_Form
        [Test]
        public void Test_Create_Product_Form()
        {
            // Test the "Create Product" form page
            driver.Url = "http://localhost:44305";
            driver.Navigate().GoToUrl("http://localhost:44305/Product/Create");
            driver.Manage().Window.Maximize();

            IWebElement FeedCreate = driver.FindElement(By.XPath("/html/body/div/h2"));
            string text = FeedCreate.Text;

            NUnit.Framework.Assert.AreEqual("Create", text);
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
        }

        // Test case: testCreate
        [Test]
        public void testCreate()
        {
            // Test creating a new product
            driver.Url = "http://localhost:44305";
            driver.Navigate().GoToUrl("http://localhost:44305/Product/Create");
            driver.Manage().Window.Maximize();

            IWebElement ProductNameTextbox = driver.FindElement(By.XPath("//*[@id=\"ProductName\"]"));
            ProductNameTextbox.Click();
            ProductNameTextbox.SendKeys("Racecar");
            System.Threading.Thread.Sleep(2000);

            IWebElement ProductPriceTextBox = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
            ProductPriceTextBox.Click();
            ProductPriceTextBox.SendKeys("3.99");
            System.Threading.Thread.Sleep(2000);

            IWebElement ProductDescTextBox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            ProductDescTextBox.Click();
            ProductDescTextBox.SendKeys("From that Disney movie");
            System.Threading.Thread.Sleep(2000);

            IWebElement SubmitBtn = driver.FindElement(By.XPath("/html/body/div/form/div/div[4]/div/input"));
            SubmitBtn.Click();

            IWebElement IndexLabel = driver.FindElement(By.XPath("/html/body/div/h2"));
            String labelText = IndexLabel.Text;
            System.Threading.Thread.Sleep(2000);
            NUnit.Framework.Assert.AreEqual("Index", labelText);
            System.Threading.Thread.Sleep(2000);
            //driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
        }

        // Test case: testEdit
        [Test]
        public void testEdit()
        {
            // Test editing an existing product
            driver.Url = "http://localhost:44305";
            driver.Navigate().GoToUrl("http://localhost:44305/Product/Index");
            driver.Manage().Window.Maximize();

            IWebElement editLink = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr[2]/td[4]/a[1]"));
            editLink.Click();

            IWebElement ProductNameTextbox = driver.FindElement(By.XPath("//*[@id=\"ProductName\"]"));
            ProductNameTextbox.Click();
            ProductNameTextbox.Clear();
            ProductNameTextbox.SendKeys("Racecar");
            System.Threading.Thread.Sleep(2000);

            IWebElement ProductPriceTextBox = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
            ProductPriceTextBox.Click();
            ProductPriceTextBox.Clear();
            ProductPriceTextBox.SendKeys("3.99");
            System.Threading.Thread.Sleep(2000);

            IWebElement ProductDescTextBox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            ProductDescTextBox.Click();
            ProductDescTextBox.Clear();
            ProductDescTextBox.SendKeys("From that Disney movie");
            System.Threading.Thread.Sleep(2000);

            IWebElement EditBtn = driver.FindElement(By.XPath("/html/body/div/form/div/div[4]/div/input"));
            EditBtn.Click();

            IWebElement IndexLabel = driver.FindElement(By.XPath("/html/body/div/h2"));
            String labelText = IndexLabel.Text;
            System.Threading.Thread.Sleep(2000);
            NUnit.Framework.Assert.AreEqual("Index", labelText);
            System.Threading.Thread.Sleep(2000);
            //driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
        }

        // Test case: Test_Delete_Product
        [Test]
        public void Test_Delete_Product()
        {
            driver.Navigate().GoToUrl("http://localhost:44305/Product/Index");

            // Assuming the product that was created in the previous test exists
            IWebElement deleteLink = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr[2]/td[4]/a[3]"));
            deleteLink.Click();
            System.Threading.Thread.Sleep(2000);

            // Confirm deletion by clicking the "Delete" button
            IWebElement deleteButton = driver.FindElement(By.XPath("/html/body/div/div/form/div/input"));
            deleteButton.Click();
            System.Threading.Thread.Sleep(2000);

            // After successful deletion, verify that the user is redirected to the Index page
            IWebElement indexLabel = driver.FindElement(By.XPath("/html/body/div/h2"));
            string labelText = indexLabel.Text;
            NUnit.Framework.Assert.AreEqual("Index", labelText);
            System.Threading.Thread.Sleep(2000);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
