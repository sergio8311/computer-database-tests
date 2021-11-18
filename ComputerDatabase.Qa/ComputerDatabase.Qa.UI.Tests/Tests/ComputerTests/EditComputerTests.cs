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
    public class EditComputerTests : TestSetup
    {
        [Test]
        public void EditComputer_ChangeIsSaved()
        {
            //Arrange
            //Add new computer
            var computerName = $"TestEditcomputer{CommonFunctions.GetRandomInt(100, 9999)}";
            var computer = new ComputerBuilder()
                .WithComputerName(computerName)
                .Build();

            var computersPage = BasePage.ReturnToComputersPage();
            var addComputerPage = computersPage.AddComputer();

            addComputerPage.EnterComputerName(computer);
            computersPage = addComputerPage.CreateComputer();
            //Find added computer by name
            computersPage.FilterByName(computerName);
            var editComputerPage = computersPage.SelectComputerByComputerName(computerName);
            //Open edit computer page and change the company name
            editComputerPage.SelectCompany("Apple");
            computersPage = editComputerPage.SaveChanges();
            //save changes and read alert message
            var alertMessage = computersPage.GetAlertMessage();
            //find edited computer and map to the model
            computersPage.FilterByName(computerName);
            var computers = computersPage.GetComputersInfo();

            //Assert that Company is changed and alert message contains computer name
            Assert.Multiple(() =>
            {
                Assert.That(alertMessage, Is.EqualTo(computersPage.ComputerUpdatedAlertMessage(computerName)));
                Assert.That(computers.Any(x => x.Company == "Apple Inc."), Is.True);
            });
        }

        [Test]
        public void DeleteComputer_ComputerIsDeleted()
        {
            //Arrange
            var computerName = $"TestDeleteComputer{CommonFunctions.GetRandomInt(999, 99999)}";
            var computer = new ComputerBuilder()
                .WithComputerName(computerName)
                .Build();

            var computersPage = BasePage.ReturnToComputersPage();
            var addComputerPage = computersPage.AddComputer();

            addComputerPage.EnterComputerName(computer);
            computersPage = addComputerPage.CreateComputer();

            computersPage.FilterByName(computerName);
            var editComputerPage = computersPage.SelectComputerByComputerName(computerName);
            //Act
            computersPage = editComputerPage.DeleteComputer();
            var alertMessage = computersPage.GetAlertMessage();

            computersPage.FilterByName(computerName);
            var computers = computersPage.GetComputersInfo();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(alertMessage, Is.EqualTo("Done! Computer has been deleted"));
                Assert.That(computers.Count, Is.EqualTo(0));
            });
        }
    }
}
