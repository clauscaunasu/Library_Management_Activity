using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic.SearchFilters
{
    public class SearchBranchByName
    {
        private readonly ICollection<Client> _clients;

        public SearchBranchByName(ICollection<Client> clients)
        {
            _clients = clients;
        }

        public IReadOnlyCollection<Client> Search(string term) 
        {
            return _clients.Where(book => book.FirstName.Contains(term)).ToList().AsReadOnly();
        }
    }
}
