using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bal = LibraryApp_BAL;



namespace LibraryApp_DAL
{
    public class DConectivity
    {
        private string connection = "Server=DESKTOP-CG65E95;Database=Library;Trusted_Connection=True;";
        SqlConnection dbConnection()
        {
            SqlConnection sqlConnect = new SqlConnection(connection);
            sqlConnect.Open();
            return sqlConnect;
        }

        public SqlCommand dbCommand(String strProcedure)
        {
            SqlCommand sqlCmd = new SqlCommand(strProcedure, dbConnection());
            sqlCmd.CommandType = CommandType.Text;
            return sqlCmd;
        }
    }
}
