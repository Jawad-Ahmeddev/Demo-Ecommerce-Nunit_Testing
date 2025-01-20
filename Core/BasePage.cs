using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCart_Automation_SoftwareTestingProject.Core
{
    public class BasePage
    {
        public static IWebDriver driver;

        public void SeleniumInit()
        {
            var myDriver = new ChromeDriver();
            driver = myDriver;

        }

        public string GetCurrentUrl()
        {
            return driver.Url; // Fetch the current URL
        }

        public void DriverClose()
        {
            driver.Close();

        }
    }
}
