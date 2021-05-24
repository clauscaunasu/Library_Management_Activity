using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.Moq;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using Moq;

namespace LibraryApp.BusinessLogic.Tests
{
    [TestClass]
    public class SearchLogicTests
    {
        [TestMethod]
        public void SearchBookAfterTitle_Returns_OnlyBooksThatContainsStringInTitle()
        {
            var searchEngine = new SearchEngine(BookList());
            var filter = new SearchFilter { Name = DataModel.Enums.Filters.Title, Term = "title" };
            var result = searchEngine.Search(filter);

            
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void SearchBookAfterTitle_Returns_Nothing()
        {
            var searchEngine = new SearchEngine(BookList());
            var filter = new SearchFilter { Name = DataModel.Enums.Filters.Title, Term = "asddd" };
            var result = searchEngine.Search(filter);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SearchBookAfterAuthor_Returns_OnlyBooksThatContainsStringInTitle()
        {
            var searchEngine = new SearchEngine(BookList());
            var filter = new SearchFilter { Name = DataModel.Enums.Filters.Author, Term = "author" };

            var result = searchEngine.Search(filter);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }

        private static List<Book> BookList()
        {
            var bookList = new List<Book>()
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
                    ID = 4,
                    Title = "Title4",
                    UniqueCode = "123"
                },
                new Book()
                {
                    Author = "Author5",
                    Editure = "Publisher5",
                    Genre = "Genre5",
                    ID = 5,
                    Title = "Book1",
                    UniqueCode = "123"
                }
            };
            return bookList;
        }
    }
}
