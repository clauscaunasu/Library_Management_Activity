using System.Collections.Generic;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.BusinessLogic.SearchFilters;
using LibraryApp.DataModel;
using Filters = LibraryApp.DataModel.Enums.Filters;

namespace LibraryApp.BusinessLogic
{
    public class SearchEngine
    {
        private readonly IDictionary<Filters, ISearchStrategy<Book>> searchStrategies = new Dictionary<Filters, ISearchStrategy<Book>>();

        public SearchEngine(ICollection<Book> books)
        {
            searchStrategies[Filters.Title] = new SearchBookByTitle(books); 
            searchStrategies[Filters.Author] = new SearchBookByAuthor(books);
            searchStrategies[Filters.Genre] = new SearchBookByGenre(books);
        }
        public IReadOnlyCollection<Book> Search(SearchFilter filter)
        {
            if (searchStrategies.ContainsKey(filter.Name))
            {
                var strategy = searchStrategies[filter.Name];
                return strategy.Search(filter.Term);
            }
            else
            {
                return new List<Book>().AsReadOnly();
            }
        }
    }
}
