using DemoCart_Automation_SoftwareTestingProject.Core;
using DemoCart_Automation_SoftwareTestingProject.Search_Functionality;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.AddToCart
{
    [TestClass]
    public class AddToCartTest
    {
        SearchFunctionality searchPage = new SearchFunctionality();
        AddToCart addToCartPage = new AddToCart();
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
        public void AddToCartAfterSearchTest()
        {
            // Step 1: Perform search for an item
            searchPage.SearchItem("mac");

            // Step 2: Add the item to the cart
            addToCartPage.AddItemToCart();
            Thread.Sleep(8000);

            // Step 3: Verify the cart button value changes to reflect the added item
            string cartValue = addToCartPage.GetCartButtonValue();

            Console.WriteLine(cartValue);
            Assert.IsTrue(cartValue.Contains("1 item(s) - $122.00"), "The cart value did not update correctly after adding the item.");
        }
    }
}

