using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Academia.Data.Database
{
    public class Adapter
    {
        private SqlConnection sqlConnection;

        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString ="ConnStringLocal";

        public SqlConnection sqlConn
        {
            get => sqlConnection;
            set => sqlConnection = value;
        }

        protected void OpenConnection()
        {
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
