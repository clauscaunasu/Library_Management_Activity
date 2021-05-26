using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests2
{
    class UpdateBranchWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public UpdateBranchWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string name, string address)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var nameBox = _driver.FindElementByAccessibilityId("BranchNameTextBox");
            var addressBox = _driver.FindElementByAccessibilityId("AddressTextBox");
            var updateBranchBtn = _driver.FindElementByAccessibilityId("UpdateBranchBtn");
            nameBox.Clear();
            nameBox.SendKeys(name);
            addressBox.Clear();
            addressBox.SendKeys(address);
            updateBranchBtn.Click();


        }
    }
}
