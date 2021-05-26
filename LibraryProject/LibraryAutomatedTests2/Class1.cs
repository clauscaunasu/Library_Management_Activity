using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace LibraryAutomatedTests2
{
    [TestClass]
    public class Class1
    {
        protected const string WindowsApplicationDriveUrl = "http://127.0.0.1:4723/";
        private const string WpfAppId =
            @"C:\Users\Claudia\Documents\GitHub\Library_Management_Activity\LibraryProject\LibraryApp\bin\Debug\LibraryApp.exe";
        protected static WindowsDriver<WindowsElement> Session;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            if (Session == null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                appiumOptions.AddAdditionalCapability("DESKTOP-P607G92", "WindowsPC");
                Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriveUrl), appiumOptions);
                var mainWindow = new MainWindowTest(Session);
                var loginPage = mainWindow.GoToLoginPage();
                loginPage.Login("clau2", "12345");
            }
        }

        [TestMethod]
        public void AddBranchTest()
        {
            var mainWindow = new MainWindowTest(Session);
            Thread.Sleep(2000);
            var loginPage = mainWindow.GoToLoginPage();
            loginPage.Login("clau2", "12345");
            Thread.Sleep(2000);
            var adminHomeWindow = new AdminHomeTest(Session);
            Thread.Sleep(2000);
            var viewBranchWindow = adminHomeWindow.ViewBranches();
            var addBranch = viewBranchWindow.AddBranch();

            var randomNumber = new Random();
            var name = $"name {randomNumber.Next(10, 100)}";
            var address = $"address {randomNumber.Next(10, 100)}";
            addBranch.Save(name,address);
            Thread.Sleep(3000);
            Assert.IsTrue(viewBranchWindow.BranchExists(name));
        }

        [TestMethod]
        public void UpdateBranchTest()
        {
            using (Session)
            {

                var adminHomeWindow = new AdminHomeTest(Session);
                Thread.Sleep(3000);
                var viewBranchesWindow = adminHomeWindow.ViewBranches();
                var randomNumber = new Random();
                var name = $"name {randomNumber.Next(100, 200)}";
                viewBranchesWindow.EditBranch().Save(name, "address123");
                Thread.Sleep(3000);
                Assert.IsTrue(viewBranchesWindow.BranchExists(name));
            }

        }

        [TestMethod]
        public void DeleteBranchTest()
        {
            using (Session)
            {

                var adminHomeWindow = new AdminHomeTest(Session);
                Thread.Sleep(3000);
                var viewBranchesWindow = adminHomeWindow.ViewBranches();
                var name = viewBranchesWindow.GetBranchName();
                viewBranchesWindow.DeleteBranch().Save();
                Thread.Sleep(3000);
                Assert.IsFalse(viewBranchesWindow.BranchExists(name));
            }

        }
    }
}
