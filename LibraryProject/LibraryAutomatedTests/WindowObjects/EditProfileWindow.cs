using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests.WindowObjects
{
    class EditProfileWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public EditProfileWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string newPhoneNumber)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var phoneNumberTextBox = _driver.FindElementByAccessibilityId("PhoneTextBox");
            phoneNumberTextBox.Clear();
            phoneNumberTextBox.SendKeys(newPhoneNumber);
            var saveBtn = _driver.FindElementByAccessibilityId("SaveButton");
            saveBtn.Click();

        }

    }
}
