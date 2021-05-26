using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;

namespace LibraryAutomatedTests.WindowObjects
{
    internal class AdminHomeTest
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public AdminHomeTest(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public AddBookWindow AddBook()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var addBookBtn = _driver.FindElementByAccessibilityId("AddBookButton");
            addBookBtn.Click();
            return new AddBookWindow(_driver);
        }

        public bool BookExists(string bookTitle)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var bookList = _driver.FindElementsByAccessibilityId("BookControlTitle");
            return bookList.Count(b => b.Text.Equals(bookTitle)) > 0;
        }

        public EditBookWindow EditBook()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var expander = _driver.FindElementByAccessibilityId("ExpanderID");
            expander.Click();
            var updateBtn = _driver.FindElementByAccessibilityId("UpdateBtnId");
            updateBtn.Click();
            return new EditBookWindow(_driver);
        }

        public MyProfileWindow EditProfile()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var myProfileBtn = _driver.FindElementByAccessibilityId("MyProfileBtn");
            myProfileBtn.Click();
            return new MyProfileWindow(_driver);
        }
    }
}
