using DemoCart_Automation_SoftwareTestingProject.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.ShoppingCartPage
{
    public class ShoppingCartPage : BasePage
    {
        #region Locators
        private static By quantityInput = By.CssSelector("input[value='1']"); // Quantity input field
        private static By updateButton = By.CssSelector("button[aria-label='Update']"); // Update button
        private static By removeButton = By.CssSelector("button[aria-label='Remove']"); // Remove button
        private static By emptyCartMessage = By.CssSelector(".alert.alert-warning"); // Message when cart is empty
        #endregion

        #region Methods
        public void UpdateQuantity(string newQuantity)
        {
            // Enter the new quantity
            IWebElement quantityField = driver.FindElement(quantityInput);
            quantityField.Clear();
            quantityField.SendKeys(newQuantity);

            // Click the update button
            driver.FindElement(updateButton).Click();
            Thread.Sleep(2000); // Wait for the cart to update
        }

        public void RemoveItemFromCart()
        {
            // Click the remove button
            driver.FindElement(removeButton).Click();
            Thread.Sleep(2000); // Wait for the item to be removed
        }

        public string GetEmptyCartMessage()
        {
            // Retrieve the message displayed when the cart is empty
            Thread.Sleep(2000); // Wait for the message to appear
            return driver.FindElement(emptyCartMessage).Text;
        }

        public bool IsCartEmpty()
        {
            // Check if the empty cart message is displayed
            Thread.Sleep(2000); // Wait for the page to update
            return driver.FindElement(emptyCartMessage).Displayed;
        }
        #endregion
    }
}