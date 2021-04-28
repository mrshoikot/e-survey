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

namespace E_Survry
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class rowItem
    {
        public string Question { get; set; }
        public object Answers { get; set; }

        public rowItem(string q, string a)
        {
            this.Question = q;
            this.Answers = a;
        }
    }

    public partial class Dashboard : Form
    {
        int init = 191;
        int count = 1;
        public List<GroupBox> gbxs { get; set; }
        public List<TextBox> tboxs { get; set; }

        public Dashboard()
        {

            this.gbxs = new List<GroupBox>();
            this.tboxs = new List<TextBox>();


            InitializeComponent();

            string connString;
            SqlConnection conn;
            connString = Model.Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand("select * from surveys", conn);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = reader.GetString(1);
                item.Value = reader.GetInt32(0).ToString();
                surveyCombo.Items.Add(item);
            }
            if (surveyCombo.Items.Count > 0)
            {
                surveyCombo.SelectedIndex = 0;
            }

        }

        private void load(string id)
        {

            foreach(GroupBox bx in this.gbxs)
            {
                bx.Hide();
            }

            foreach (TextBox tx in this.tboxs)
            {
                tx.Hide();
            }


            this.gbxs = new List<GroupBox>();
            this.tboxs = new List<TextBox>();

            this.init = 191;
            this.count = 1;

            Model.Survey survey = new Model.Survey(int.Parse(id));

            List<List<string>> rows = new List<List<string>> { };

            foreach (Model.Question q in survey.questions)
            {

                List<string> row = new List<string> { q.question };

                string result = yesno(this.init, q, this.count);
                row.Add(result);
                rows.Add(row);
                this.init += 120;
                count++;
            }

            dataTable.DataSource = rows.Select(row => new rowItem(row[0], row[1])).ToList();

        }

        private string yesno(int y, Model.Question q, int count)
        {
            GroupBox Q = new GroupBox();
            TextBox QTitle = new TextBox();
            string result = "";

            // 
            // Qustion
            // 
            Q.Controls.Add(QTitle);
            Q.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Q.Location = new System.Drawing.Point(290, y);
            Q.Name = q.id.ToString();
            Q.Size = new System.Drawing.Size(550, 121);
            Q.TabIndex = 41;
            Q.TabStop = false;
            Q.Text = "Qustion  " + count;
            // 
            // QTitle
            // 
            QTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            QTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            QTitle.Location = new System.Drawing.Point(330, y + 25);
            QTitle.Name = q.id.ToString();
            QTitle.TabIndex = 44;
            QTitle.Text = q.question;

            int init = 0;

            

            foreach(Model.Option option in q.optionData)
            {
                TextBox op = new TextBox();
                op.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
                op.Location = new System.Drawing.Point(670, y +init+15);
                op.Name = q.id.ToString();
                op.Size = new System.Drawing.Size(150, 20);
                op.TabIndex = 45;
                if (q.type == "5 Point Scale")
                {
                    op.Text = option.Count + "% " + option.Text;
                }
                else
                {
                    op.Text = option.Count + " " + option.Text;
                }
                init += 20;
                result += Environment.NewLine + op.Text;
                this.Controls.Add(op);
                this.tboxs.Add(op);


            }

            this.gbxs.Add(Q);
            this.tboxs.Add(QTitle);

            this.Controls.Add(QTitle);
            this.Controls.Add(Q);

            return result;
        }

        private void survey_Click(object sender, EventArgs e)
        {
            Surveys s = new Surveys();
            this.Hide();
            s.Show();
        }

        private void print_click(object sender, EventArgs e)
        {
            if(dataTable.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for(int i = 1;i < dataTable.Columns.Count+1; i++)
                {
                    xcelApp.Cells[1, i] = dataTable.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataTable.Columns.Count + 1; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dataTable.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add_Survey s = new Add_Survey();
            this.Hide();
            s.Show();
        }
        

        private void logout_Click(object sender, EventArgs e)
        {
            Login s = new Login();
            this.Hide();
            s.Show();
        }



        private void surveyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            load(((ComboboxItem)surveyCombo.SelectedItem).Value.ToString());
        }
    }
}
