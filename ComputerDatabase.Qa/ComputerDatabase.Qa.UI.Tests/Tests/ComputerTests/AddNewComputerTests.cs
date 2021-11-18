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
            //navigating to Add computer page
            var addComputerPage = computersPage.AddComputer();
            //Click save button 
            addComputerPage.ClickCreateThisComputer();
            //Assert that computer name is required message displayed
            Assert.That(addComputerPage.IsComputerNameRequired, Is.True);
        }

        [Test]
        public void AddNewComputer_ComputerAdded()
        {
            //Create a new computer object
            var computerName = $"Test computer{CommonFunctions.GetRandomInt(100, 9999)}";
            var computer = new ComputerBuilder()
                .WithComputerName(computerName)
                .WithCompany("IBM")
                .Build();

            var computersPage = BasePage.ReturnToComputersPage();
            var addComputerPage = computersPage.AddComputer();
            //navigate to add computer page, fill in only computer name and save it
            addComputerPage.EnterComputerName(computer);
            computersPage = addComputerPage.CreateComputer();

            //read allert message
            var alertMessage = computersPage.GetAlertMessage();
            //search added computer
            computersPage.FilterByName(computerName);
            var computers = computersPage.GetComputersInfo();
            //Assert that added computers is found and alert message contains computer name
            Assert.Multiple(() =>
            {
                Assert.That(alertMessage, Is.EqualTo(computersPage.ComputerCreatedAlertMessage(computerName)));
                Assert.That(computers.Any(x => x.ComputerName == computerName), Is.True);
            });
        }
    }
}
