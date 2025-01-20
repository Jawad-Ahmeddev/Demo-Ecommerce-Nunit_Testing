using DemoCart_Automation_SoftwareTestingProject.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.Search_Functionality
{
    public class SearchFunctionality : BasePage
    {
        #region Locators
        private static By searchInput = By.CssSelector("input[placeholder='Search']");
        private static By searchButton = By.CssSelector(".btn.btn-light.btn-lg");
        private static By searchResultHeader = By.CssSelector("#content > h1");
        #endregion

        #region Methods
        public void SearchItem(string itemName)
        {
            // Navigate to the Home URL
            driver.Url = "https://demo.opencart.com/en-gb?route=common/home";

            // Enter search term
            driver.FindElement(searchInput).SendKeys(itemName);

            // Click on the search button
            driver.FindElement(searchButton).Click();
            Thread.Sleep(20000);
        }

        public string GetSearchResultHeader()
        {
            // Get the text of the result header
            return driver.FindElement(searchResultHeader).Text;
        }
        #endregion
    }
}