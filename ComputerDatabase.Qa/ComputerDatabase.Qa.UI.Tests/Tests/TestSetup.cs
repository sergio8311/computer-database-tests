using ComputerDatabase.Qa.Core.Helpers;
using ComputerDatabase.Qa.UI.Tests.Interfaces;
using ComputerDatabase.Qa.UI.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ComputerDatabase.Qa.UI.Tests.Tests
{
    [TestFixture, Parallelizable]
    public class TestSetup
    {
        protected IBasePage BasePage { get; set; }
        private IWebDriver _webDriver;
        private string _baseUrl;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _baseUrl = Configuration.Configuration.GetConfiguration<string>("BaseURL");
        }

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine("Running: " + TestContext.CurrentContext.Test.Name);
            TestContext.WriteLine("Started at: " + DateTime.Now.ToString("s"));
            Trace.WriteLine("Running: " + TestContext.CurrentContext.Test.FullName);

            _webDriver = DriverContext.GetDriver(TestContext.Parameters.Get("browser", Configuration.Configuration.GetConfiguration<string>("Browser")), false);
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(_baseUrl);
            BasePage = new BasePage(_webDriver);
        }

        [TearDown]
        public void Teardown()
        {
            TestContext.WriteLine("Tear down method");
            TestContext.WriteLine("Finished at: " + DateTime.Now.ToString("s"));
            Screenshot ss = ((ITakesScreenshot)_webDriver).GetScreenshot();

            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(LocationManager.GetDefaultScreenshotDirectory() + @"\" + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            ss.ToString();
            _webDriver.CloseDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            _webDriver.Dispose();
        }
    }
}
