using ComputerDatabase.Qa.Core.Helpers;
using ComputerDatabase.Qa.Core.Models;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace ComputerDatabase.Qa.UI.Tests.Pages
{
    public class ComputersPage : BasePage
    {
        #region Locators
        private IWebElement SearchField => _webDriver.FindElement(By.Id("searchbox"));
        private IWebElement SubmitSearch => _webDriver.FindElement(By.Id("searchsubmit"));
        private IWebElement AddNewComputer => _webDriver.FindElement(By.Id("add"));
        private IEnumerable<IWebElement> ComputersRows => _webDriver.FindElements(By.CssSelector("tbody > tr"));
        private const string ComputerName = "td:nth-child(1)";
        private const string Introduced = "td:nth-child(2)";
        private const string Discontinued = "td:nth-child(3)";
        private const string Company = "td:nth-child(4)";

        private IWebElement AlertMessage => _webDriver.FindElement(By.CssSelector("#main > .alert-message"));
        #endregion

        private readonly IWebDriver _webDriver;

        public ComputersPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public void FilterByName(string name)
        {
            SearchField.SendKeys(name);
            SubmitSearch.Click();
        }

        public IEnumerable<Computer> GetComputersInfo()
        {
            var computersList = new List<Computer>();
            foreach (var computer in ComputersRows)
            {
                computersList.Add(new Computer()
                { 
                    ComputerName = computer.FindElement(By.CssSelector(ComputerName)).Text,
                    IntroducedDate = DateTimeHelper.FormatDate(computer.FindElement(By.CssSelector(Introduced)).Text),
                    DiscontinuedDate = DateTimeHelper.FormatDate(computer.FindElement(By.CssSelector(Discontinued)).Text),
                    Company = computer.FindElement(By.CssSelector(Company)).Text
                });
            }
            return computersList;
        }

        public AddComputerPage AddComputer()
        {
            AddNewComputer.Click();
            return new AddComputerPage(_webDriver);
        }

        public string GetAlertMessage()
        {
            return AlertMessage.Text;
        }
    }
}
