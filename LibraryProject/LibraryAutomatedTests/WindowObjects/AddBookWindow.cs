using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using SeleniumExtras.PageObjects;


namespace LibraryAutomatedTests.WindowObjects
{
    class AddBookWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public AddBookWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string title, string isbn, string author, string publisher, string copies)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var titleBox = _driver.FindElementByAccessibilityId("TitleTextBox");
            var isbnBox = _driver.FindElementByAccessibilityId("IsbnTextBox");
            var authorBox = _driver.FindElementByAccessibilityId("AuthorTextBox");
            var publisherBox = _driver.FindElementByAccessibilityId("PublisherTextBox");
            var copiesBox = _driver.FindElementByAccessibilityId("CopiesTextBox");
            var branchBox = _driver.FindElementByAccessibilityId("BranchComboBox");
            var genreBox = _driver.FindElementByAccessibilityId("GenreComboBox");
            var saveBtn = _driver.FindElementByAccessibilityId("SaveButton");

            titleBox.Clear();
            titleBox.SendKeys(title);
            isbnBox.Clear();
            isbnBox.SendKeys(isbn);
            authorBox.Clear();
            authorBox.SendKeys(author);
            publisherBox.Clear();
            publisherBox.SendKeys(publisher);
            copiesBox.Clear();
            copiesBox.SendKeys(copies);
            branchBox.SendKeys(Keys.Down);
            branchBox.SendKeys(Keys.Enter);
            genreBox.SendKeys(Keys.Down);
            genreBox.SendKeys(Keys.Enter);

            saveBtn.Click();
        }

    }
}
