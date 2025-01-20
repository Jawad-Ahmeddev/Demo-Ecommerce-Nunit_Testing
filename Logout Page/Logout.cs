using DemoCart_Automation_SoftwareTestingProject.Core;
using OpenQA.Selenium;
using System.Threading;

namespace DemoCart_Automation_SoftwareTestingProject.Logout_Page
{
    public class Logout : BasePage
    {
        #region Locators
        private static By logoutLink = By.CssSelector("div[class='nav float-end'] li[class='list-inline-item'] a[href*='route=account/logout']");
        private static By logoutHeading = By.CssSelector("div[id='content'] h1"); // Heading after logout
        #endregion

        #region Methods
        public void LogoutUser()
        {
            // Click the logout link
            driver.FindElement(logoutLink).Click();
            Thread.Sleep(2000); // Wait for the logout action to complete
        }

        public string GetLogoutHeading()
        {
            // Retrieve the heading text on the logout confirmation page
            return driver.FindElement(logoutHeading).Text;
        }
        #endregion
    }
}