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
            var computersPage = BasePage.ReturnToComputersPage();
            computersPage.FilterByName("ibm");
            var searchResult = computersPage.GetComputersInfo();

            Assert.That(searchResult.All(x => x.ComputerName.ToLowerInvariant().Contains("ibm")), "Expected computer name hasn't been found");
        }

        [Test]
        public void FilterByComputerName_ComputersNotFound()
        {
            var computersPage = BasePage.ReturnToComputersPage();
            computersPage.FilterByName("ibmasusace");
            var searchResult = computersPage.GetComputersInfo();

            Assert.That(searchResult.Count() == 0, "Unexpected computer name has been found");
        }
    }
}
