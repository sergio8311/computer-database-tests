using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerDatabase.Qa.UI.Tests.Pages
{
    public class EditComputerPage : ComputerInfoPage
    {
        #region Locators
        private IWebElement SaveThisComputer => _webDriver.FindElement(By.XPath("//*[@value='Save this computer']"));
        private IWebElement DeleteThisComputer => _webDriver.FindElement(By.XPath("//*[@value='Delete this computer']"));
        #endregion
        private readonly IWebDriver _webDriver;

        public EditComputerPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
