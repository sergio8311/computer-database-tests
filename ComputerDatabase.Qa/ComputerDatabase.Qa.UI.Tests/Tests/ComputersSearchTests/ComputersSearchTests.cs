using NUnit.Framework;
using System.Linq;

namespace ComputerDatabase.Qa.UI.Tests.Tests.ComputersSearchTests
{
    [TestFixture]
    public class ComputersSearchTests : TestSetup
    {
        [Test]
        public void FilterByComputerName_ComputersExist()
        {
            //Arrane 
            //open main computers page
            var computersPage = BasePage.ReturnToComputersPage();
            //Filter computers by computer name
            computersPage.FilterByName("ibm");
            //Map search result to Computers model
            var searchResult = computersPage.GetComputersInfo();
            //Assert that all computers on the page contains expected name
            Assert.That(searchResult.All(x => x.ComputerName.ToLowerInvariant().Contains("ibm")), "Expected computer name hasn't been found");
        }

        [Test]
        public void FilterByComputerName_ComputersNotFound()
        {
            var computersPage = BasePage.ReturnToComputersPage();
            //Search by invalid name 
            computersPage.FilterByName("ibmasusace");
            var searchResult = computersPage.GetComputersInfo();
            //Assert that 0 search results
            Assert.That(searchResult.Count() == 0, "Unexpected computer name has been found");
        }
    }
}
