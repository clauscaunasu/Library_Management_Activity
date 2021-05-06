using System.Collections.Generic;
using System.Linq;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic.SearchFilters
{
    public class SearchClientByName
    {
        private readonly ICollection<Client> _clients;

        public SearchClientByName(ICollection<Client> clients)
        {
            _clients = clients;
        }

        public IReadOnlyCollection<Client> Search(string term) 
        {
            return _clients.Where(client=> client.Username.Contains(term)).ToList().AsReadOnly();
        }
    }
}
