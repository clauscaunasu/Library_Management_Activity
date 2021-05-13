using System.Collections.Generic;
using System.Linq;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

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
            return _booksList.Where(book => book.Genre.ToLower().Contains(term)).ToList().AsReadOnly();
        }
    }
}

