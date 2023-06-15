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
    public partial class Enter : Form
    {
        public string Login { get; set; }
        public string Password { get; set; }


        public Enter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.log.Text) || string.IsNullOrEmpty(this.password.Text))
                return;

            Login = this.log.Text;
            Password = this.password.Text;

            try
            {
                DB dB = new DB();
                dB.openConnection();
                string insertQuery = $"SELECT * FROM Users WHERE login = @log AND password = @pass";
                NpgsqlDataAdapter NpAdapter = new NpgsqlDataAdapter();
                var cmd = NpAdapter.InsertCommand = new NpgsqlCommand(insertQuery, dB.getConnection());
                cmd.Parameters.AddWithValue("log", Login);
                cmd.Parameters.AddWithValue("pass", Password);
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    this.log.Text = default;
                    this.password.Text = default;
                    MessageBox.Show("Успешно");
                    return;
                }

                MessageBox.Show("Неправилный логин или пароль");



                dB.closeConnection();


               
            }
            catch (Exception)
            {

                MessageBox.Show("что то пошло не так");
            }

        }
    }
}
