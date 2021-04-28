using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Survry.Model;

namespace E_Survry
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private bool isValid()
        {
            if (string.IsNullOrEmpty(emailLogin.Text))
            {
                System.Windows.Forms.MessageBox.Show("Email can't be empty!");
                return false;
            }
            else if (string.IsNullOrEmpty(passLogin.Text))
            {
                System.Windows.Forms.MessageBox.Show("Password can't be empty!");
                return false;
            }

            return true;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string connString;
                SqlConnection conn;
                connString = Global.connString;
                conn = new SqlConnection(connString);

                conn.Open();

                string sql = "SELECT * from users where email='" + emailLogin.Text + "' AND password='" + passLogin.Text + "'";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32(0);
                        string name = dataReader.GetString(1);
                        string email = dataReader.GetString(2);
                        bool isAdmin = dataReader.GetString(3) == "admin";

                        Auth.Login(id, name, isAdmin, email);
                    }

                    if (Auth.user.isAdmin)
                    {
                        Dashboard s = new Dashboard();
                        s.Show();
                    }
                    else
                    {
                        Surveys s = new Surveys();
                        s.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }

                conn.Close();

            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            this.Hide();
            r.Show();
        }
    }
}
