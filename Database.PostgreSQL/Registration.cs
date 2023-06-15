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
        public string Login { get; set; }
        public string Password { get; set; }

        public Registration()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.log.Text) || string.IsNullOrEmpty(this.password.Text))
               return;

            Login = this.log.Text;
            Password = this.password.Text;


            try
            {
                DB dB = new DB();
                dB.openConnection();
                string insertQuery = "INSERT INTO Users (login, password) VALUES (@log, @pass)";
                NpgsqlDataAdapter NpAdapter = new NpgsqlDataAdapter();
                var cmd = NpAdapter.InsertCommand = new NpgsqlCommand(insertQuery, dB.getConnection());
                cmd.Parameters.AddWithValue("log", Login);
                cmd.Parameters.AddWithValue("pass", Password);
                cmd.ExecuteNonQuery();
                dB.closeConnection();


                this.log.Text = default;
                this.password.Text = default;
                MessageBox.Show("Успешно");
            }
            catch (Exception)
            {

                MessageBox.Show("что то пошло не так");
            }

        }
    }
}


   
