using System;
using System.Data;
using System.Data.SqlClient;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel.Annotations;
using Moq;

namespace LibraryApp_DAL
{
    public class DConnectivity:IDConnectivity
    {
        private readonly string _connection = "Server=DESKTOP-CG65E95;Database=Library;Trusted_Connection=True;";

        public SqlConnection DbConnection()
        {
            var sqlConnect = new SqlConnection(_connection);
            sqlConnect.Open();
            return sqlConnect;
        }

        public SqlCommand DbCommand([NotNull] string strProcedure)
        {
            if (strProcedure == null) throw new ArgumentNullException(nameof(strProcedure));
            var sqlCmd = new SqlCommand(strProcedure, DbConnection()) {CommandType = CommandType.Text};
            return sqlCmd;
        }


        public static implicit operator Mock<object>(DConnectivity v)
        {
            throw new NotImplementedException();
        }

    }
}
