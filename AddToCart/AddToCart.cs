using DemoCart_Automation_SoftwareTestingProject.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.AddToCart
{
    public class AddToCart : BasePage
    {
        #region Locators // Initial value of the cart button 0 item(s) - $0.00   button[type='button'] i[class='fa-solid fa-cart-shopping']  
        private static By addToCartDiv = By.CssSelector("#product-list");
        private static By specificProductDiv = By.CssSelector("body > main:nth-child(4) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div:nth-child(8) > div:nth-child(1)");
        private static By addToCartButton = By.CssSelector("body > main:nth-child(4) > div:nth-child(2) > div:nth-child(2) > div:nth-child(1) > div:nth-child(8) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > form:nth-child(2) > div:nth-child(1) > button:nth-child(1)");
        private static By cartButton = By.CssSelector(".btn.btn-lg.btn-inverse.btn-block.dropdown-toggle"); // Cart button showing cart count
        #endregion

        #region Methods
        public void AddItemToCart()
        {
            // Wait for the product div to be visible
            Thread.Sleep(5000); // Replace explicit wait with Thread.Sleep()

            try
            {
                // Scroll to the Add to Cart button
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(addToCartButton));

                // Wait to ensure the button is fully interactive
                Thread.Sleep(2000);

                // Click the Add to Cart button
                driver.FindElement(addToCartButton).Click();
            }
            catch (OpenQA.Selenium.ElementClickInterceptedException)
            {
                // Fallback: Use JavaScript to click the button
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(addToCartButton));
            }
        }

        public string GetCartButtonValue()
        {
            // Wait for the cart button to update
            Thread.Sleep(5000); // Wait for the cart count to reflect the addition

            // Return the cart button text (indicating cart count)
            return driver.FindElement(cartButton).Text;
        }
        #endregion
    }
}