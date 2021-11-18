using ComputerDatabase.Qa.Core.Configuration;
using ComputerDatabase.Qa.Core.Helpers;
using ComputerDatabase.Qa.UI.Tests.Interfaces;
using ComputerDatabase.Qa.UI.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace ComputerDatabase.Qa.UI.Tests.Tests
{
    //This is the base class for the tests
    [TestFixture, Parallelizable]
    public class TestSetup
    {
        protected IBasePage BasePage { get; set; }
        private IWebDriver _webDriver;
        private string _baseUrl;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            //setup base url
            _baseUrl = Configuration.GetConfiguration<string>("BaseURL");
        }

        [SetUp]
        public void Setup()
        {
            //Add logs
            TestContext.WriteLine("Running: " + TestContext.CurrentContext.Test.Name);
            TestContext.WriteLine("Started at: " + DateTime.Now.ToString("s"));
            Trace.WriteLine("Running: " + TestContext.CurrentContext.Test.FullName);

            //creating new driver for each test
            _webDriver = DriverContext.GetDriver(TestContext.Parameters.Get("browser", Configuration.GetConfiguration<string>("Browser")));
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(_baseUrl);
            BasePage = new BasePage(_webDriver);
        }

        [TearDown]
        public void Teardown()
        {
            //after each test add logs
            TestContext.WriteLine("Tear down method");
            TestContext.WriteLine("Finished at: " + DateTime.Now.ToString("s"));
            Screenshot ss = ((ITakesScreenshot)_webDriver).GetScreenshot();

            //add screenshot
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(LocationManager.GetDefaultScreenshotDirectory() + @"\" + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            ss.ToString();
            //Close and terminate driver
            _webDriver.CloseDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            //disposing webdriver
            _webDriver.Dispose();
        }
    }
}
