using DemoCart_Automation_SoftwareTestingProject.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace DemoCart_Automation_SoftwareTestingProject.Logout_Page
{
    [TestClass]
    public class LogoutTestCases
    {
        Logout logoutPage = new Logout();
        BasePage basePage = new BasePage();

        #region Initializations and Cleanups
        [TestInitialize]
        public void TestInit()
        {
            // Initialize WebDriver
            basePage.SeleniumInit();

            // Simulate user login (optional step if logout requires an authenticated session)
            BasePage.driver.Url = "https://demo.opencart.com/en-gb?route=account/login";
            Thread.Sleep(2000); // Wait for the login page to load
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Close WebDriver
            basePage.DriverClose();
        }
        #endregion

        [TestMethod]
        public void LogoutUserTest()
        {
            // Step 1: Logout the user
            logoutPage.LogoutUser();

            // Step 2: Verify the logout heading
            string logoutHeading = logoutPage.GetLogoutHeading();
            Assert.AreEqual("Account Logout", logoutHeading, "Logout was not successful.");
        }
    }
}