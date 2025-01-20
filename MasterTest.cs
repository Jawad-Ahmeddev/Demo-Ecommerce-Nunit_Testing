using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DemoCart_Automation_SoftwareTestingProject.Core;
using DemoCart_Automation_SoftwareTestingProject.RegistrationPage;
using DemoCart_Automation_SoftwareTestingProject.Search_Functionality;
using DemoCart_Automation_SoftwareTestingProject.AddToCart;
using DemoCart_Automation_SoftwareTestingProject.ShoppingCartPage;
using DemoCart_Automation_SoftwareTestingProject.Logout_Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;

namespace DemoCart_Automation_SoftwareTestingProject
{
    [TestClass]
    public class MasterTest
    {
        BasePage basePage = new BasePage();
        RegistrationPageTest registrationPage = new RegistrationPageTest();
        SearchFunctionality searchPage = new SearchFunctionality();
        AddToCartTest addToCartPage = new AddToCartTest();
        ShoppingCartPageTest shoppingCartPage = new ShoppingCartPageTest();
        Logout logoutPage = new Logout();

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
            // Do not close WebDriver in TestCleanup to keep it available for the entire test flow
        }
        #endregion

        [TestMethod]
        public void EndToEndTest()
        {
            try
            {
                // Step 1: User Registration
                BasePage.driver.Url = "https://demo.opencart.com/en-gb?route=account/register";
                Thread.Sleep(2000); // Wait for the page to load
                registrationPage.SuccessfulRegistrationTest();

                // Step 2: Search for a Product
                BasePage.driver.Url = "https://demo.opencart.com/en-gb";
                Thread.Sleep(2000); // Wait for the homepage to load
                searchPage.SearchItem("mac");

                // Step 3: Add to Cart
                addToCartPage.AddToCartAfterSearchTest();

                // Step 4: Update Cart Quantity
                BasePage.driver.Url = "https://demo.opencart.com/en-gb?route=checkout/cart";
                Thread.Sleep(2000); // Wait for the cart page to load
                shoppingCartPage.UpdateCartQuantityTest();

                // Step 5: Remove Item from Cart
                shoppingCartPage.RemoveCartItemTest();

                // Step 6: Logout
                logoutPage.LogoutUser();
            }
            finally
            {
                // Ensure WebDriver is closed after the entire test flow
                basePage.DriverClose();
            }
        }
    }
}