using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PostgreSQL
{

    public class DB
    {
        public string connectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=123;";
        public NpgsqlConnection npgsqlConnection = new NpgsqlConnection();
        public NpgsqlCommand npgsqlCommand;

        public DB()
        {
            npgsqlConnection.ConnectionString = connectionString;
        }

        public void openConnection()
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Closed)
                npgsqlConnection.Open();
        }

        public void closeConnection()
        {
            if (npgsqlConnection.State == System.Data.ConnectionState.Open)
                npgsqlConnection.Close();
        }

        public NpgsqlConnection getConnection()
        {
            return npgsqlConnection;
        }
    }
}
