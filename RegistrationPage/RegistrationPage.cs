using DemoCart_Automation_SoftwareTestingProject.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.RegistrationPage
{
    public class RegistrationPage : BasePage
    {
        #region Locators
        private static By firstNameField = By.CssSelector("#input-firstname");
        private static By lastNameField = By.CssSelector("#input-lastname");
        private static By emailField = By.CssSelector("#input-email");
        private static By passwordField = By.CssSelector("#input-password");
        private static By subscribeToggle = By.CssSelector("#input-newsletter");
        private static By policyToggle = By.CssSelector("input[value='1'][name='agree']");
        private static By submitButton = By.CssSelector("button[type='submit']");
        private static By registrationHeading = By.CssSelector("div[id='content'] h1"); // Heading after registration
        #endregion

        #region Methods
        public void FillRegistrationForm(string firstName, string lastName, string email, string password, bool subscribe)
        {
            // Enter First Name
            driver.FindElement(firstNameField).SendKeys(firstName);

            // Enter Last Name
            driver.FindElement(lastNameField).SendKeys(lastName);

            // Enter Email
            driver.FindElement(emailField).SendKeys(email);

            // Enter Password
            driver.FindElement(passwordField).SendKeys(password);

            // Toggle Subscription (if needed)
            
                driver.FindElement(subscribeToggle).Click();
            

            // Agree to Policy
            driver.FindElement(policyToggle).Click();
        }

        public void SubmitRegistration()
        {
            driver.FindElement(submitButton).Click();
            Thread.Sleep(3000); // Wait for the page to process
        }

        public string GetRegistrationHeading()
        {
            return driver.FindElement(registrationHeading).Text;
        }
        #endregion
    }
}