using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests.WindowObjects
{
    class MyProfileWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public MyProfileWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public EditProfileWindow Edit()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var editProfileBtn = _driver.FindElementByAccessibilityId("EditProfileBtn");
            editProfileBtn.Click();
            return new EditProfileWindow(_driver);
        }

        public string GetPhoneNumber()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var phoneNumberTextBox = _driver.FindElementByAccessibilityId("PhoneTextBox");
            return phoneNumberTextBox.Text;
        }
    }
}
