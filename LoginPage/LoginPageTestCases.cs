using DemoCart_Automation_SoftwareTestingProject.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.LoginPage
{

    [TestClass]
    public class LoginPageTestCases
    {
        LoginPage loginpage = new LoginPage();
        BasePage basepage = new BasePage();

        #region Initializations and Cleanups

        public TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            //MessageBox.Show("Assembly Initialization");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //MessageBox.Show("Assembly CleanUp");
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            //MessageBox.Show("Class Initialization");
        }



        [ClassCleanup]
        public static void ClassCleanup()
        {
            //MessageBox.Show("Class CleanUp");
        }

        [TestInitialize]
        public void TestInit()
        {
            //MessageBox.Show("Test Initialization");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //MessageBox.Show("Test CleanUp");
        }

        #endregion

        [TestMethod]
        public void LoginPositiveTC()
        {
            basepage.SeleniumInit();
            loginpage.Login("mujtubasteam0333@gmail.com", "1337bht!@#$%");
            string txtdata = "My Account";
            var actual = BasePage.driver.FindElement(LoginPage.ReturnTxt).Text;
            Assert.AreEqual(txtdata, actual);
            basepage.DriverClose();

        }

        [TestMethod]
        public void LoginNegativeTC()
        {
            basepage.SeleniumInit();
            loginpage.Login("mujtubasteam0333@gmail.com", "jd!@#$%");
            string currentUrl = basepage.GetCurrentUrl();
            string expectedUrl = "https://demo.opencart.com/en-gb?route=account/login";
            Assert.AreEqual(expectedUrl, currentUrl);
            basepage.DriverClose();

        }

    }
}
