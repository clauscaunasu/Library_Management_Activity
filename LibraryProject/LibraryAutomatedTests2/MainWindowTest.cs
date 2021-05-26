using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;

namespace LibraryAutomatedTests2
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

