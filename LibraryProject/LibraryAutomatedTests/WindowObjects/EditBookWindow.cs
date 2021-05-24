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
    class EditBookWindow
    {
        private readonly WindowsDriver<WindowsElement> _driver;
        public EditBookWindow(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string title, string author, string isbn, string publisher)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var publisherBox = _driver.FindElementByAccessibilityId("PublisherId");
            var authorBox = _driver.FindElementByAccessibilityId("AuthorId");
            var titleBox = _driver.FindElementByAccessibilityId("TitleId");
            var isbnBox = _driver.FindElementByAccessibilityId("IsbnId");
            var genreBox = _driver.FindElementByAccessibilityId("GenresId");
            var saveBtn = _driver.FindElementByAccessibilityId("SaveButton");

            titleBox.Clear();
            titleBox.SendKeys(title);
            isbnBox.Clear();
            isbnBox.SendKeys(isbn);
            authorBox.Clear();
            authorBox.SendKeys(author);
            publisherBox.Clear();
            publisherBox.SendKeys(publisher);
            genreBox.SendKeys(Keys.Down);
            genreBox.SendKeys(Keys.Down);
            genreBox.SendKeys(Keys.Enter);

            saveBtn.Click();
        }
    }
}
