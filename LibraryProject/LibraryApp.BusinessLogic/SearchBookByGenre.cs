using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic
{
    public class SearchBookByGenre : ISearchStrategy<Book>
    {
        private List<Book> _booksList;
        public SearchBookByGenre(List<Book> books)
        {
            _booksList = books;
        }
        public IReadOnlyCollection<Book> Search(string term)
        {
            return _booksList.Where(book => book.Genre.Contains(term)).ToList().AsReadOnly();
        }
    }
}

