using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using E_Survry.Model;

namespace E_Survry
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private bool isValid()
        {
            Console.WriteLine(passRegister.Text);
            if (string.IsNullOrEmpty(passRegister.Text))
            {
                System.Windows.Forms.MessageBox.Show("Password can't be empty!");
                return false;
            }
            else if (string.IsNullOrEmpty(name.Text))
            {
                System.Windows.Forms.MessageBox.Show("Name can't be empty!");
                return false;
            }
            else if (string.IsNullOrEmpty(emailRegister.Text))
            {
                System.Windows.Forms.MessageBox.Show("Email can't be empty!");
                return false;
            }

            return true;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string connString;
                SqlConnection conn;
                connString = Global.connString;
                conn = new SqlConnection(connString);

                conn.Open();

                string sql;
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT name from users where email='" + emailRegister.Text + "'";
                command = new SqlCommand(sql, conn);
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    MessageBox.Show("This email already exist");
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();

                    sql = "INSERT INTO users (name, email, role, password) VALUES (@name, @email, 'user', @password)";
                    command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@name", name.Text);
                    command.Parameters.AddWithValue("@email", emailRegister.Text);
                    command.Parameters.AddWithValue("@password", passRegister.Text);

                    int result = command.ExecuteNonQuery();

                    if (result != 1)
                    {
                        System.Windows.Forms.MessageBox.Show("Error registering user!");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Success");
                    }
                }
            }
        }

    }
}
