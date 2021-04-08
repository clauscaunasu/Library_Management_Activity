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
        Client GetUserById(int id);
        Client GetUserByNameAndPassword(string name, string password);
    }
}
