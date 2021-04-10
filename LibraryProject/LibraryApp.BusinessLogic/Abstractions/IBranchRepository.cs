using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel;
using System.Data;

namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface IBranchRepository
    {
        bool AddBranch(Branch branch);
        List<Branch> ListOfBranches(DataTable dt);
        List<Branch> GetBranches();

    }
}
