using DemoCart_Automation_SoftwareTestingProject.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.Search_Functionality
{
    [TestClass]
    public class SearchFunctionalityTest
    {
        SearchFunctionality searchPage = new SearchFunctionality();
        BasePage basePage = new BasePage();

        #region Initializations and Cleanups
        [TestInitialize]
        public void TestInit()
        {
            // Initialize WebDriver
            basePage.SeleniumInit();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Close WebDriver
            basePage.DriverClose();
        }
        #endregion

        [TestMethod]
        public void SearchItemPositiveTest()
        {
            // Search for "mac"
            searchPage.SearchItem("mac");

            // Verify the search result header contains "mac"
            string expectedHeader = "Search - mac";
            string actualHeader = searchPage.GetSearchResultHeader();
            Assert.AreEqual(expectedHeader, actualHeader, "The search result header does not match the expected value.");
        }

        [TestMethod]
        public void SearchItemNegativeTest()
        {
            // Search for an invalid item
            searchPage.SearchItem("nonexistentitem");

            // Verify no results found message or appropriate header
            string expectedHeader = "Your shopping cart is empty!";
            string actualHeader = searchPage.GetSearchResultHeader();
            Assert.AreNotEqual(expectedHeader, actualHeader, "Unexpected search result header.");
        }
    }
}