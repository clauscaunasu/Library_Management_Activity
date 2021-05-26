using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests2
{
    class DeleteBranchWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public DeleteBranchWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var deleteBranchBtn = _driver.FindElementByAccessibilityId("DeleteBranchBtn");
            deleteBranchBtn.Click();


        }
    }
}
