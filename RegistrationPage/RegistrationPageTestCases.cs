using DemoCart_Automation_SoftwareTestingProject.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.RegistrationPage
{
    [TestClass]
    public class RegistrationPageTest
    {
        RegistrationPage registrationPage = new RegistrationPage();
        BasePage basePage = new BasePage();

        #region Initializations and Cleanups
        [TestInitialize]
        public void TestInit()
        {
            // Initialize WebDriver
            basePage.SeleniumInit();

            // Navigate to the registration page
            BasePage.driver.Url = "https://demo.opencart.com/en-gb?route=account/register";
            Thread.Sleep(2000); // Wait for the page to load
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Close WebDriver
            basePage.DriverClose();
        }
        #endregion

        [TestMethod]
        public void SuccessfulRegistrationTest()
        {
            // Fill in the registration form
            registrationPage.FillRegistrationForm("John", "Doe", "johndoe@examplee12324.com", "Password123!", true);
            Thread.Sleep(10000);

            // Submit the registration form
            registrationPage.SubmitRegistration();
            Thread.Sleep(10000);
            // Verify the registration success by checking the page heading
            string registrationHeading = registrationPage.GetRegistrationHeading();
            Assert.AreEqual("Your Account Has Been Created!", registrationHeading, "User registration was not successful.");
        }

        [TestMethod]
        public void RegistrationWithMissingFieldsTest()
        {
            // Fill in the registration form with missing email
            registrationPage.FillRegistrationForm("John", "Doe", "", "Password123!", true);

            // Submit the registration form
            registrationPage.SubmitRegistration();

            // Verify that registration did not succeed
            string registrationHeading = registrationPage.GetRegistrationHeading();
            Assert.AreNotEqual("Your Account Has Been Created!", registrationHeading, "Registration succeeded despite missing required fields.");
        }
    }
}