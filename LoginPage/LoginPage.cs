using DemoCart_Automation_SoftwareTestingProject.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCart_Automation_SoftwareTestingProject.LoginPage
{
    public class LoginPage : BasePage
    {
        #region locators
        public static By usernameTxt = By.Id("input-email");
        public static By passwordTxt = By.Id("input-password");
        public static By LoginBtn = By.CssSelector("button[type='submit']");
        public static By ReturnTxt = By.CssSelector(".row > #content > h2 ");

        #endregion

        #region methods
        public void Login(string username,string password)
        {
            driver.Url = "https://demo.opencart.com/en-gb?route=account/login";
            driver.FindElement(usernameTxt).SendKeys(username);
            IWebElement inputField = driver.FindElement(usernameTxt);
            inputField.SendKeys(OpenQA.Selenium.Keys.Tab);
            driver.FindElement(passwordTxt).SendKeys(password);
            IWebElement inputField2 = driver.FindElement(passwordTxt);
            inputField2.SendKeys(OpenQA.Selenium.Keys.Tab);
            IWebElement inputField3 = driver.FindElement(LoginBtn);
            inputField3.SendKeys(OpenQA.Selenium.Keys.Tab);
            Thread.Sleep(3000);
            driver.FindElement(LoginBtn).Click();
            Thread.Sleep(10000);
        }
        #endregion
    }
}
