using ComputerDatabase.Qa.Core.Builders;
using ComputerDatabase.Qa.Core.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerDatabase.Qa.UI.Tests.Tests.ComputerTests
{
    [TestFixture]
    public class AddNewComputerTests : TestSetup
    {
        [Test]
        public void AddNewComputer_ComputerNameRequired()
        {
            var computersPage = BasePage.ReturnToComputersPage();
            var addComputerPage = computersPage.AddComputer();

            addComputerPage.ClickCreateThisComputer();

            Assert.That(addComputerPage.IsComputerNameRequired, Is.True);
        }

        [Test]
        public void AddNewComputer_ComputerAdded()
        {
            var computerName = $"Test computer{CommonFunctions.GetRandomInt(100, 9999)}";
            var computer = new ComputerBuilder()
                .WithComputerName(computerName)
                .Build();

            var computersPage = BasePage.ReturnToComputersPage();
            var addComputerPage = computersPage.AddComputer();

            addComputerPage.EnterComputerName(computer);
            computersPage = addComputerPage.CreateComputer();

            var alertMessage = computersPage.GetAlertMessage();

            computersPage.FilterByName(computerName);
            var computers = computersPage.GetComputersInfo();

            Assert.Multiple(() =>
            {
                Assert.That(alertMessage.Contains(computerName), Is.True);
                Assert.That(computers.Any(x => x.ComputerName == computerName), Is.True);
            });
        }
    }
}
