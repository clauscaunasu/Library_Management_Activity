using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;


namespace LibraryAutomatedTests.WindowObjects
{
    class MainWindowTest
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public MainWindowTest(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        
        public LoginPage GoToLoginPage()
        {
            var loginBtn = _driver.FindElementByAccessibilityId("LoginButton");
            loginBtn.Click();
            return new LoginPage(_driver);
        }
    }
}
