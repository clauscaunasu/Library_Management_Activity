using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests2
{
    class AdminHomeTest
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public AdminHomeTest(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ViewBranchWindow ViewBranches()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var expanderBranch = _driver.FindElementByAccessibilityId("ExpanderBranch");
            expanderBranch.Click();
            var viewBranches = _driver.FindElementByAccessibilityId("ViewBranchesBtn");
            viewBranches.Click();
            return new ViewBranchWindow(_driver);
        }
    }
}
