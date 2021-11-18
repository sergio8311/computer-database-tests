using ComputerDatabase.Qa.Core.Models;
using OpenQA.Selenium;

namespace ComputerDatabase.Qa.UI.Tests.Pages
{
    //The Add Computer page. Inherited from ComputerInfoPage as it shares the same view as Edit Computer page
    public class AddComputerPage : ComputerInfoPage
    {
        #region Locators
        private IWebElement CreateThisComputer => _webDriver.FindElement(By.XPath("//*[@value='Create this computer']"));
        private IWebElement ComputerNameValidationError => _webDriver.FindElement(By.CssSelector(".error > div > input#name"));
        #endregion

        private IWebDriver _webDriver;

        public AddComputerPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public void EnterComputerName(Computer computer)
        {
            ComputerName.SendKeys(computer.ComputerName);
        }

        public ComputersPage CreateComputer()
        {
            CreateThisComputer.Click();
            return new ComputersPage(_webDriver);
        }

        public void ClickCreateThisComputer()
        {
            CreateThisComputer.Click();
        }

        public bool IsComputerNameRequired()
        {
           return ComputerNameValidationError.Displayed;
        }
    }
}
