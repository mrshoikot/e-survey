using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Survry.Model;

namespace E_Survry
{
    public partial class Surveys : Form
    {
        public Surveys()
        {
            InitializeComponent();

            if (!Auth.user.isAdmin)
            {
                button8.Hide();
                button9.Hide();
            }
        }

        private void load()
        {
            try
            {
                surveyTable.Columns.RemoveAt(2);
                surveyTable.Columns.RemoveAt(2);
                surveyTable.Columns.RemoveAt(2);
            }
            catch { }


            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * from surveys", conn);
            SqlDataReader reader = command.ExecuteReader();
            List<Model.Survey> surveys = new List<Model.Survey>();


            while (reader.Read())
            {
                Model.Survey survey = new Model.Survey(reader.GetInt32(0));
                surveys.Add(survey);
            }

            surveyTable.DataSource = surveys.Select(s => new { s.id, s.name }).ToArray();

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "\0";
            btn.Name = "questionsBtn";
            btn.Text = "Questions";
            btn.UseColumnTextForButtonValue = true;
            surveyTable.Columns.Add(btn);

            if (Auth.user.isAdmin)
            {
                btn = new DataGridViewButtonColumn();
                btn.HeaderText = "\0";
                btn.Name = "addQBtn";
                btn.Text = "Add Question";
                btn.UseColumnTextForButtonValue = true;
                surveyTable.Columns.Add(btn);

                btn = new DataGridViewButtonColumn();
                btn.HeaderText = "\0";
                btn.Name = "deleteBtn";
                btn.Text = "Delete";
                btn.UseColumnTextForButtonValue = true;
                surveyTable.Columns.Add(btn);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add_Survey s = new Add_Survey();
            this.Hide();
            s.Show();
        }

        private void Surveys_Load(object sender, EventArgs e)
        {
            load();

        }

        private void surveyTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selection = surveyTable.Rows[e.RowIndex].Cells["id"].Value.ToString();

            Model.Survey s = new Model.Survey(int.Parse(selection));
            Global.selectSurvey(s);

            if (e.ColumnIndex == 2)
            {
                Question q = new Question();
                this.Hide();
                q.Show();
            }
            else if (e.ColumnIndex == 3 && Auth.user.isAdmin)
            {
                Add_Question q = new Add_Question();
                this.Hide();
                q.Show();
            }
            else if (e.ColumnIndex == 4 && Auth.user.isAdmin)
            {
                s.Delete();
                load();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
