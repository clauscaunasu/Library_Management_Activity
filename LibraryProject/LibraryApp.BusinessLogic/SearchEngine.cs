using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic
{
    public class SearchEngine<T>
    {
        private IDictionary<string, ISearchStrategy<T>> searchStrategies = new Dictionary<string, ISearchStrategy<T>>();

        public SearchEngine(ICollection<Book> collection)
        {
            searchStrategies["title"] = new SearchBookByTitle(collection); 
            searchStrategies["author"] = new SearchBookByAuthor(collection);
            searchStrategies["genre"] = new SearchBookByGenre(collection);
        }

        public void RegisterStrategy(string strategyName, ISearchStrategy<T> searchStrategy)
        {
            searchStrategies[strategyName] = searchStrategy;
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
                new List<Book>().AsReadOnly();
            }
        }
    }

}
