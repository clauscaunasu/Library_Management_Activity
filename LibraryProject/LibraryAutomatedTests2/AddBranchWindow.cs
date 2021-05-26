using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests2
{
    class AddBranchWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public AddBranchWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string name, string address)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var nameBox = _driver.FindElementByAccessibilityId("BranchNameTextBox");
            var addressBox = _driver.FindElementByAccessibilityId("AddressTextBox");
            var addBranchBtn = _driver.FindElementByAccessibilityId("AddBranchBtn");
            nameBox.Clear();
            nameBox.SendKeys(name);
            addressBox.Clear();
            addressBox.SendKeys(address);
            addBranchBtn.Click();

           
        }
    }
}
