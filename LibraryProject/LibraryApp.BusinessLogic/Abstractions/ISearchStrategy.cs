using System.Collections.Generic;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface ISearchStrategy<T>
    {
        IReadOnlyCollection<Book> Search(string term);
    }
}
