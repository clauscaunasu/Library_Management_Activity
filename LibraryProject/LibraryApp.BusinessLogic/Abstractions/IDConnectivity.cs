using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel.Annotations;

namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface IDConnectivity
    { 
        SqlConnection DbConnection();
        SqlCommand DbCommand([NotNull] string strProcedure);
    }
}
