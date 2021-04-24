using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface ISearchStrategy<T>
    {
        IReadOnlyCollection<Book> Search(string term);
    }
}
