using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryApp_DAL
{
    public class DConectivity
    {
        private readonly string connection = "Server=DESKTOP-P607G92;Database=Library;Trusted_Connection=True;";
        SqlConnection dbConnection()
        {
            var sqlConnect = new SqlConnection(connection);
            sqlConnect.Open();
            return sqlConnect;
        }

        public SqlCommand dbCommand(String strProcedure)
        {
            var sqlCmd = new SqlCommand(strProcedure, dbConnection());
            sqlCmd.CommandType = CommandType.Text;
            return sqlCmd;
        }

    }
}
