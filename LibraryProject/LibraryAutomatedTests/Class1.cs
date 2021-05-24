using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibraryApp.View;
using LibraryAutomatedTests.WindowObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace LibraryAutomatedTests
{
    [TestClass]
    public class Class1
    {
        protected const string WindowsApplicationDriveUrl = "http://127.0.0.1:4723/";

        private const string WpfAppId =
            @"C:\Users\Cristi\source\repos\Library_Management_Activity\LibraryProject\LibraryApp\bin\Debug\LibraryApp.exe";
        protected static WindowsDriver<WindowsElement> Session;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            if (Session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                appiumOptions.AddAdditionalCapability("DESKTOP-CG65E95", "WindowsPC");
                Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriveUrl), appiumOptions);
            }
        }

        [TestMethod]
        public void AddBookTest()
        {
            var mainWindow = new MainWindowTest(Session);
            var loginPage = mainWindow.GoToLoginPage();
            loginPage.Login("rucarr","rucarr");

            var adminHomeWindow = new AdminHomeTest(Session);
            var addBookWindow = adminHomeWindow.AddBook();
            var randomNumber = new Random();
            var title = $"titlu {randomNumber.Next(10, 100)}";
            addBookWindow.Save(title, $"{randomNumber.Next(1000,9999)}", "autor", "editura", "1");

            Assert.IsTrue(adminHomeWindow.BookExists(title));
        }

        [TestMethod]
        public void EditBookTest()
        {
            var mainWindow = new MainWindowTest(Session);
            var loginPage = mainWindow.GoToLoginPage();
            loginPage.Login("rucarr", "rucarr");

            var adminHomeWindow = new AdminHomeTest(Session);
            var updateBookWindow = adminHomeWindow.EditBook();
            var randomNumber = new Random();
            var title = $"titlu {randomNumber.Next(10, 100)}";
            updateBookWindow.Save(title, "autor nou", $"{randomNumber.Next(1000, 9999)}", "publisher nou");

            Thread.Sleep(3000);
            Assert.IsTrue(adminHomeWindow.BookExists(title));
        }

        /*[TestCleanup]
        public void Cleanup()
        {
            Session.Close();
        }*/
    }
}
