using System.Linq;
using OpenQA.Selenium.Appium.Windows;


namespace LibraryAutomatedTests.WindowObjects
{
    class MainWindowTest
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public MainWindowTest(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        
        public LoginPage GoToLoginPage()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
            var loginBtn = _driver.FindElementByAccessibilityId("LoginButton");
            loginBtn.Click();
            return new LoginPage(_driver);
        }
    }
}
