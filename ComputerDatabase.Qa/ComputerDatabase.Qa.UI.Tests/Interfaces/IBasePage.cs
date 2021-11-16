using ComputerDatabase.Qa.UI.Tests.Pages;
using OpenQA.Selenium;

namespace ComputerDatabase.Qa.UI.Tests.Interfaces
{
    public interface IBasePage
    {
        IWebDriver WebDriver { get; }

        string GetCurrentUrl();
        public ComputersPage ReturnToComputersPage();
    }
}
