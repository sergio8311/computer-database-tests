using OpenQA.Selenium;

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

        public ComputersPage SaveChanges()
        {
            SaveThisComputer.Click();
            return new ComputersPage(_webDriver);
        }

        public ComputersPage DeleteComputer()
        {
            DeleteThisComputer.Click();
            return new ComputersPage(_webDriver);
        }
    }
}
