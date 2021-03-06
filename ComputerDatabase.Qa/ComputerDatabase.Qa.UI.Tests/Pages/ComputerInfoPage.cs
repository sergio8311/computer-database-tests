using OpenQA.Selenium;

namespace ComputerDatabase.Qa.UI.Tests.Pages
{
    //Parent class for Add/Edit Computer pages as they share the same view
    public class ComputerInfoPage : BasePage
    {
        #region Locators
        protected IWebElement ComputerName => _webDriver.FindElement(By.Id("name"));
        protected IWebElement IntroducedDate => _webDriver.FindElement(By.Id("introduced"));
        protected IWebElement DiscontinuedDate => _webDriver.FindElement(By.Id("discontinued"));
        protected IWebElement CompanyDropdown => _webDriver.FindElement(By.Id("company"));
        protected IWebElement CancelButton => _webDriver.FindElement(By.XPath("//*[text()='Cancel']"));
        #endregion

        private readonly IWebDriver _webDriver;

        public ComputerInfoPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public void SelectCompany(string companyName)
        {
            CompanyDropdown.SendKeys(companyName);
        }
    }
}
