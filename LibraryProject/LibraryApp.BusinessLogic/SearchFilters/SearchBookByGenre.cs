using System;
using System.Collections.Generic;
using System.Linq;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp.DataModel.Enums;

namespace LibraryApp.BusinessLogic.SearchFilters
{
    public class SearchBookByGenre : ISearchStrategy<Book>
    {
        private readonly ICollection<Book> _booksList;
        public SearchBookByGenre(ICollection<Book> books)
        {
            _booksList = books;
        }
        public IReadOnlyCollection<Book> Search(string term)
        {
            var genre = (Genres) Enum.Parse(typeof(Genres), term);
            return _booksList.Where(book => book.Genre == genre).ToList().AsReadOnly();
        }
    }
}

