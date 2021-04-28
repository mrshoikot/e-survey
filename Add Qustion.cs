using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_Survry.Model;
using System.Data.SqlClient;

namespace E_Survry
{
    public partial class Add_Question : Form
    {
        public Add_Question()
        {
            InitializeComponent();
            surveyName.Text = Global.SelectedSurvey.name;
            options.Hide();
            label1.Hide();
        }

        private bool isValid()
        {
            if (string.IsNullOrEmpty(question.Text))
            {
                System.Windows.Forms.MessageBox.Show("Question can't be empty!");
                return false;
            }
            else if (string.IsNullOrEmpty(type.Text))
            {
                System.Windows.Forms.MessageBox.Show("Question type can't be empty!");
                return false;
            }

            if(type.Text == "Dropdown")
            {
                if (string.IsNullOrEmpty(options.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Options can't be empty!");
                    return false;
                }
            }


            return true;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                Model.Question q = new Model.Question();
                q.question = question.Text;
                q.type = type.Text;
                q.creator = Auth.user;
                q.options = new string[] { };
                q.survey_id = Global.SelectedSurvey.id.ToString();
                q.options = options.Text.Split(',');
                q.Save();

                question.Clear();
                type.SelectedIndex = 0;
            }
        }

        private void survey_Click(object sender, EventArgs e)
        {
            Surveys s = new Surveys();
            this.Hide();
            s.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type.SelectedIndex > -1)
            {
                if (type.Text== "Dropdown")
                {
                    options.Show();
                    label1.Show();
                }
                else
                {
                    options.Hide();
                    label1.Hide();
                }
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
