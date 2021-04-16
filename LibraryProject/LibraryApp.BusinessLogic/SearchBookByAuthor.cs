using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic
{
    class SearchBookByAuthor : ISearchStrategy<Book>
    {
        private List<Book> _booksList;
        public SearchBookByAuthor(List<Book> books)
        {
            _booksList = books;
        }
        public IReadOnlyCollection<Book> Search(string term)
        {
            return _booksList.Where(book => book.Author.Contains(term)).ToList().AsReadOnly();
        }
    }

}
}
