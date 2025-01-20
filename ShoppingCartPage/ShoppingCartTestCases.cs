using DemoCart_Automation_SoftwareTestingProject.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoCart_Automation_SoftwareTestingProject.AddToCart;
namespace DemoCart_Automation_SoftwareTestingProject.ShoppingCartPage
{
    [TestClass]
    public class ShoppingCartPageTest
    {
        ShoppingCartPage shoppingCartPage = new ShoppingCartPage();
        AddToCartTest addToCartPage = new AddToCartTest();
        BasePage basePage = new BasePage();

        #region Initializations and Cleanups
        [TestInitialize]
        public void TestInit()
        {
            // Initialize WebDriver
            basePage.SeleniumInit();

            // Step 1: Add an item to the cart
            BasePage.driver.Url = "https://demo.opencart.com/en-gb";
            Thread.Sleep(2000); // Wait for the homepage to load
            addToCartPage.AddToCartAfterSearchTest();
            Thread.Sleep(30000); // Wait for the homepage to load

            // Step 2: Navigate to the shopping cart page
            BasePage.driver.Url = "https://demo.opencart.com/en-gb?route=checkout/cart";
            Thread.Sleep(10000); // Wait for the shopping cart page to load
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Close WebDriver
            basePage.DriverClose();
        }
        #endregion

        [TestMethod]
        public void UpdateCartQuantityTest()
        {
            // Update the quantity of the cart item
            shoppingCartPage.UpdateQuantity("2");

            // Verify the quantity was updated (by reloading or checking updated state)
            string updatedQuantity = BasePage.driver.FindElement(By.CssSelector("input[value='2']")).GetAttribute("value");
            Assert.AreEqual("2", updatedQuantity, "The cart quantity was not updated correctly.");
        }

        [TestMethod]
        public void RemoveCartItemTest()
        {
            // Remove the item from the cart
            shoppingCartPage.RemoveItemFromCart();

            // Verify the cart is empty
            Assert.IsTrue(shoppingCartPage.IsCartEmpty(), "The cart is not empty after removing the item.");
        }
    }
}