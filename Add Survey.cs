using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Survry.Model;
using System.Windows.Forms;

namespace E_Survry
{
    public partial class Add_Survey : Form
    {
        public Add_Survey()
        {
            InitializeComponent();
        }

        private bool isValid()
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                System.Windows.Forms.MessageBox.Show("Name can't be empty!");
                return false;
            }

            return true;
        }

        private void addsurvey_Click(object sender, EventArgs e)
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


                sql = "INSERT INTO surveys (name, created_by) output INSERTED.ID VALUES (@name, @created_by)";
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", name.Text);
                command.Parameters.AddWithValue("@created_by", Auth.user.id);

                int insertedID = Convert.ToInt32(command.ExecuteScalar());


                E_Survry.Model.Survey survey = new E_Survry.Model.Survey(insertedID);
                Global.selectSurvey(survey);

                Add_Question q = new Add_Question();
                this.Hide();
                q.Show();
                

                conn.Close();
            }
        }

        private void survey_Click(object sender, EventArgs e)
        {
            Surveys s = new Surveys();
            s.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            d.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add_Question aq = new Add_Question();
            this.Hide();
            aq.Show();
        }
    }
}
