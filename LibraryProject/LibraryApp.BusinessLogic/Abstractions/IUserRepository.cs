using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel;


namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface IUserRepository
    {
        bool Add(Client client);
        List<Client> GetUserById(int id);
        Client GetUserByNameAndPassword(string name, string password);

        List<Client> GetClients();

        bool EditMember(Client client);

        bool DeleteMember(Client client);

        Client GetClient(Client client);

        bool IsValidUsername(string username);

        bool IsDesired(Client client);
    }
}
