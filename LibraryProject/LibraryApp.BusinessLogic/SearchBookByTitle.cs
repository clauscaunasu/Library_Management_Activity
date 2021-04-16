using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic
{
    public class SearchBookByTitle: ISearchStrategy<Book>
    {
        private ICollection<Book> _booksList;
        public SearchBookByTitle(ICollection<Book> books)
        {
            _booksList = books;
        }
        public IReadOnlyCollection<Book> Search(string term)
        {
            return _booksList.Where(book => book.Title.Contains(term)).ToList().AsReadOnly();
        }
    }
}
