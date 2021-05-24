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
    public class LoginPage
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public LoginPage(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Login(string username, string password)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var usernameTextBox = _driver.FindElementByAccessibilityId("UsernameTextBox");
            usernameTextBox.Clear();
            usernameTextBox.SendKeys(username);
            var passwordTextBox = _driver.FindElementByAccessibilityId("PasswordTextBox");
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(password);
            _driver.FindElementByAccessibilityId("LoginButton2").Click();
            
        }

    }
}
