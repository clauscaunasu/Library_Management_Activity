using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LibraryApp_DAL;
using LibraryApp.BusinessLogic.Abstractions;
using Autofac.Extras.Moq;
using Autofac;
using System.Collections.Generic;
using LibraryApp.DataModel;
using System;

namespace LibraryApp.BusinessLogic.Tests
{
    [TestClass]
    public class LibraryFileTest1
    {
        #region Constants
        public AutoMock Mock { get; set; }
        #endregion


        #region SetUp
        [TestInitialize]
        public void TestInitialize()
        {
            Mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(new Mock<DConnectivity>()).As<Mock<DConnectivity>>());
            Mock.Create<Mock<DConnectivity>>();
        }
        #endregion


        #region Test Data
        List<LibraryFile> GetLibraryFilesList = new List<LibraryFile>
        {
            new LibraryFile
            {
                ID = 1,
                InventoryId = 1,
                ClientId = 3,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                ReturnDate = DateTime.Now.AddDays(7)
            },

            new LibraryFile
            {
                ID = 2,
                InventoryId = 1,
                ClientId = 5,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                ReturnDate = DateTime.Now.AddDays(7)
            },

            new LibraryFile
            {
                ID = 3,
                InventoryId = 1,
                ClientId = 7,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                ReturnDate = DateTime.Now.AddDays(7)
            },

            new LibraryFile
            {
                ID = 4,
                InventoryId = 1,
                ClientId = 8,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                ReturnDate = DateTime.Now.AddDays(7)
            }
        };


        List<Book> GetBorrowedBooksList = new List<Book>
        {
            new Book()
                {
                    Author = "Author1",
                    Editure = "Publisher1",
                    Genre = "Genre1",
                    ID = 1,
                    Title = "Title1",
                    UniqueCode = "100"
                },
                new Book()
                {
                    Author = "Author2",
                    Editure = "Publisher2",
                    Genre = "Genre2",
                    ID = 2,
                    Title = "Title2",
                    UniqueCode = "101"
                },
                new Book()
                {
                    Author = "Author3",
                    Editure = "Publisher3",
                    Genre = "Genre3",
                    ID = 3,
                    Title = "Title3",
                    UniqueCode = "102"
                },
                new Book()
                {
                    Author = "Author4",
                    Editure = "Publisher4",
                    Genre = "Genre4",
                    ID = 3,
                    Title = "Title4",
                    UniqueCode = "123"
                },
                new Book()
                {
                    Author = "Author5",
                    Editure = "Publisher5",
                    Genre = "Genre5",
                    ID = 3,
                    Title = "Book1",
                    UniqueCode = "123"
                }
        };
        #endregion


        #region Tests
        [TestMethod]
        public void GetLibraryFiles_Returns_LibraryFiles()
        {
            using (Mock)
            {
                Mock.Mock<ILibraryFileRepository>().Setup(x => x.GetLibraryFiles()).Returns(GetLibraryFilesList);

                var Cls = Mock.Create<ILibraryFileRepository>();

                var expected = GetLibraryFilesList;
                var actual = Cls.GetLibraryFiles();

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }

        [TestMethod]
        public void AddLibraryFile_Returns_TrueIfAddedSuccessfully()
        {
            using(Mock)
            {
                Mock.Mock<ILibraryFileRepository>().Setup(x => x.AddLibraryFile(It.IsAny<Client>(), It.IsAny<Book>(), It.IsAny<Branch>()))
                    .Returns(true);

                var Cls = Mock.Create<ILibraryFileRepository>();

                var result = Cls.AddLibraryFile(It.IsAny<Client>(), It.IsAny<Book>(), It.IsAny<Branch>());
                Assert.IsTrue(result);
            }
        }


        [TestMethod]
        public void AddLibraryFile_Returns_FalseIfNotAddedSuccessfully()
        {
            using (Mock)
            {
                Mock.Mock<ILibraryFileRepository>().Setup(x => x.AddLibraryFile(It.IsAny<Client>(), It.IsAny<Book>(), It.IsAny<Branch>()))
                    .Returns(false);

                var Cls = Mock.Create<ILibraryFileRepository>();

                var result = Cls.AddLibraryFile(It.IsAny<Client>(), It.IsAny<Book>(), It.IsAny<Branch>());
                Assert.IsFalse(result);
            }
        }


        [TestMethod]
        public void GetBorrowedBooks_Returns_BorrowedBooks()
        {
            using (Mock)
            {
                Mock.Mock<ILibraryFileRepository>().Setup(x => x.GetBorrowedBooks(It.IsAny<Client>())).Returns(GetBorrowedBooksList);

                var Cls = Mock.Create<ILibraryFileRepository>();

                var expected = GetBorrowedBooksList;
                var actual = Cls.GetBorrowedBooks(It.IsAny<Client>());

                Assert.IsTrue(actual != null);
                Assert.AreEqual(expected.Count, actual.Count);
            }
        }

        [TestMethod]
        public void IsReturned_Returns_TrueIfSuccesfully()
        {
            using (Mock)
            {
                Mock.Mock<ILibraryFileRepository>().Setup(x => x.IsReturned(It.IsAny<Client>(), It.IsAny<Book>())).Returns(true);
                var Cls = Mock.Create<ILibraryFileRepository>();

                var result = Cls.IsReturned(It.IsAny<Client>(), It.IsAny<Book>());

                Assert.IsTrue(result);
            }
        }
        #endregion
    }
}
