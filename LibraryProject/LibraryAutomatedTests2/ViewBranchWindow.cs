using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests2
{
    class ViewBranchWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public ViewBranchWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public AddBranchWindow AddBranch()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            Thread.Sleep(1000);
            var expanderBranch = _driver.FindElementByAccessibilityId("ExpanderBranch");
            expanderBranch.Click();
            var addBranchBtn = _driver.FindElementByAccessibilityId("AddBranchBtn");
            addBranchBtn.Click();
            return new AddBranchWindow(_driver);
        }

        public bool BranchExists(string name)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var branchList = _driver.FindElementsByAccessibilityId("BranchNameControl");
            return branchList.Count(b => b.Text.Equals(name)) > 0;
        }

        public UpdateBranchWindow EditBranch()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var expander = _driver.FindElementByAccessibilityId("ExpanderBranch2"); 
            expander.Click(); 
            var updateBtn = _driver.FindElementByAccessibilityId("UpdateBranchBtn"); 
            updateBtn.Click(); 
            return new UpdateBranchWindow(_driver);
        }

        public string GetBranchName()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var branchList = _driver.FindElementsByAccessibilityId("BranchNameControl");
            return branchList.ElementAt(0).Text;

        }

        public DeleteBranchWindow DeleteBranch()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var expander = _driver.FindElementByAccessibilityId("ExpanderBranch2");
            expander.Click();
            var deleteBtn = _driver.FindElementByAccessibilityId("DeleteBranchBtn");
            deleteBtn.Click();
            return new DeleteBranchWindow(_driver);
        }


    }

}
