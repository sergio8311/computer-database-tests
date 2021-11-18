using ComputerDatabase.Qa.Core.Helpers;
using ComputerDatabase.Qa.Core.Models;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace ComputerDatabase.Qa.UI.Tests.Pages
{
    //The main Computers page 
    public class ComputersPage : BasePage
    {
        //Page locators. Encapsulated into the page class for interaction internally only
        #region Locators
        private IWebElement SearchField => _webDriver.FindElement(By.Id("searchbox"));
        private IWebElement SubmitSearch => _webDriver.FindElement(By.Id("searchsubmit"));
        private IWebElement AddNewComputer => _webDriver.FindElement(By.Id("add"));
        private IEnumerable<IWebElement> ComputersRows => _webDriver.FindElements(By.CssSelector("tbody > tr"));
        private const string ComputerName = "td:nth-child(1) > a";
        private const string Introduced = "td:nth-child(2)";
        private const string Discontinued = "td:nth-child(3)";
        private const string Company = "td:nth-child(4)";

        private IWebElement AlertMessage => _webDriver.FindElement(By.CssSelector("#main > .alert-message"));
        #endregion

        public string ComputerCreatedAlertMessage(string computerName) => $"Done! Computer {computerName} has been created";
        public string ComputerUpdatedAlertMessage(string computerName) => $"Done! Computer {computerName} has been updated";

        private readonly IWebDriver _webDriver;
        //Injection of driver instance 
        public ComputersPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        //Public methods for interacting with the page
        public void FilterByName(string name)
        {
            SearchField.SendKeys(name);
            SubmitSearch.Click();
        }

        //Get Computers list from the computers table
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

        //Add computer method navigates to AddComputerPage and return new PageOpject
        public AddComputerPage AddComputer()
        {
            AddNewComputer.Click();
            return new AddComputerPage(_webDriver);
        }

        //Method which returns alert message
        public string GetAlertMessage()
        {
            return AlertMessage.Text;
        }

        public EditComputerPage SelectComputerByComputerName(string computerName)
        {
            var computer = ComputersRows.Where(x => x.FindElement(By.CssSelector(ComputerName)).Text == computerName).FirstOrDefault();
            computer.FindElement(By.CssSelector(ComputerName)).Click();
            return new EditComputerPage(_webDriver);
        }
    }
}
