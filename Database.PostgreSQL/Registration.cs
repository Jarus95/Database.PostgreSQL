using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.PostgreSQL
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            dB.openConnection();
            string insertQuery = "INSERT INTO Users (login, password) VALUES (@log, @pass)";
            NpgsqlDataAdapter NpAdapter = new NpgsqlDataAdapter();
            var cmd = NpAdapter.InsertCommand = new NpgsqlCommand(insertQuery, dB.getConnection());
            cmd.Parameters.AddWithValue("log", "jfi");
            cmd.Parameters.AddWithValue("pass", "err");
            cmd.ExecuteNonQuery();
            dB.closeConnection();
        }
    }
}


   
