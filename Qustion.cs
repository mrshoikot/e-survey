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
    public partial class Question : Form
    {
        private Dictionary<string, string> answers = new Dictionary<string, string>();
        public Question()
        {
            InitializeComponent();

            string connString;
            SqlConnection conn;
            connString = Model.Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand("select * from questions where survey_id=" + 12, conn);
            SqlDataReader reader = command.ExecuteReader();

            int init = 191;
            int count = 1;

            while (reader.Read())
            {
                answers.Add(reader.GetInt32(0).ToString(), null);
                if (reader.GetString(2) == "Yes/No")
                {
                    yesno(init, reader.GetString(1), count, reader.GetInt32(0).ToString());
                }else if(reader.GetString(2) == "5 Point Scale")
                {
                    fivepoint(init, reader.GetString(1), count, reader.GetInt32(0).ToString());
                }else if(reader.GetString(2) == "Dropdown")
                {
                    string[] items = ("Choose one,"+reader.GetString(3)).Split(',');
                    dropdown(init, reader.GetString(1), count, reader.GetInt32(0).ToString(), items);
                }
                count++;
                init += 120;
            }

        }

        private bool validate()
        {
            foreach (KeyValuePair<string, string> kvp in answers)
                if(kvp.Value == null)
                {
                    return false;
                }
            return true;
        }


        private void SubmitHandler(object sender, EventArgs e)
        {
            if (validate())
            {
                foreach (KeyValuePair<string, string> kvp in answers)
                {
                    Model.Answer ans = new Model.Answer();
                    Model.Question q = new Model.Question();
                    q.setDataById(kvp.Key);
                    ans.answer = kvp.Value;
                    ans.question_id = q.id.ToString();
                    ans.user = Model.Auth.user;
                    ans.Save();
                }
            }
            else
            {
                MessageBox.Show("Please answer all the questions");
            }
        }

        private void surveysgo(object sender, EventArgs e)
        {
            Surveys s = new Surveys();
            this.Hide();
            s.Show();
        }

        private void RadioHandler(object sender, EventArgs e)
        {
            string id = ((RadioButton)sender).Tag.ToString();
            answers[id] = ((RadioButton)sender).Text;
            foreach (KeyValuePair<string, string> kvp in answers)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
        }

        private void DropHandler(object sender, EventArgs e)
        {
            string id = ((ComboBox)sender).Tag.ToString();
            string selection = ((ComboBox)sender).SelectedValue.ToString();
            if (selection == "Choose one")
            {
                answers[id] = null;
            }
            else
            {
                answers[id] = selection;
            }
        }




        private void yesno(int y, string q, int count, string id)
        {
            RadioButton radioButton1 = new RadioButton();
            GroupBox Q = new GroupBox();
            RadioButton radioButton3 = new RadioButton();
            TextBox QTitle = new TextBox();


            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton1.Location = new System.Drawing.Point(30, 60);
            radioButton1.Name = "yes";
            radioButton1.Size = new System.Drawing.Size(48, 20);
            radioButton1.TabIndex = 40;
            radioButton1.TabStop = true;
            radioButton1.Text = "Yes";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Tag = id;
            radioButton1.CheckedChanged += new EventHandler(RadioHandler);
            // 
            // Qustion
            // 
            Q.Controls.Add(radioButton3);
            Q.Controls.Add(QTitle);
            Q.Controls.Add(radioButton1);
            Q.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Q.Location = new System.Drawing.Point(80, y);
            Q.Name = id;
            Q.Size = new System.Drawing.Size(519, 101);
            Q.TabIndex = 41;
            Q.TabStop = false;
            Q.Text = "Qustion  "+count;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton3.Location = new System.Drawing.Point(100, 60);
            radioButton3.Name = "no";
            radioButton3.Size = new System.Drawing.Size(42, 20);
            radioButton3.TabIndex = 46;
            radioButton3.TabStop = true;
            radioButton3.Text = "No";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.Tag = id;
            radioButton3.CheckedChanged += new EventHandler(RadioHandler);
            // 
            // QTitle
            // 
            QTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            QTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            QTitle.Location = new System.Drawing.Point(110, y+25);
            QTitle.Name = id;
            QTitle.Size = new System.Drawing.Size(368, 22);
            QTitle.TabIndex = 44;
            QTitle.Text = q;


            this.Controls.Add(QTitle);
            this.Controls.Add(Q);
        }

        private void fivepoint(int y, string q, int count, string id)
        {
            RadioButton radioButton1 = new RadioButton();
            RadioButton radioButton2 = new RadioButton();
            GroupBox Q = new GroupBox();
            RadioButton radioButton3 = new RadioButton();
            RadioButton radioButton4 = new RadioButton();
            RadioButton radioButton5 = new RadioButton();
            TextBox QTitle = new TextBox();


            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton1.Location = new System.Drawing.Point(30, 60);
            radioButton1.Name = "sdisagree";
            radioButton1.Size = new System.Drawing.Size(48, 20);
            radioButton1.TabIndex = 40;
            radioButton1.TabStop = true;
            radioButton1.Text = "Strongly Disagree";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += new EventHandler(RadioHandler);
            radioButton1.Tag = id;
            // 
            // Qustion
            // 
            Q.Controls.Add(radioButton3);
            Q.Controls.Add(radioButton2);
            Q.Controls.Add(radioButton4);
            Q.Controls.Add(radioButton5);
            Q.Controls.Add(QTitle);
            Q.Controls.Add(radioButton1);
            Q.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Q.Location = new System.Drawing.Point(80, y);
            Q.Name = id;
            Q.Size = new System.Drawing.Size(519, 101);
            Q.TabIndex = 41;
            Q.TabStop = false;
            Q.Text = "Qustion  " + count;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton2.Location = new System.Drawing.Point(170, 60);
            radioButton2.Name = "disagree";
            radioButton2.Size = new System.Drawing.Size(42, 20);
            radioButton2.TabIndex = 46;
            radioButton2.TabStop = true;
            radioButton2.Text = "Disagree";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += new EventHandler(RadioHandler);
            radioButton2.Tag = id;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton3.Location = new System.Drawing.Point(250, 60);
            radioButton3.Name = "neutral";
            radioButton3.Size = new System.Drawing.Size(42, 20);
            radioButton3.TabIndex = 46;
            radioButton3.TabStop = true;
            radioButton3.Text = "Neutral";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += new EventHandler(RadioHandler);
            radioButton3.Tag = id;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton4.Location = new System.Drawing.Point(320, 60);
            radioButton4.Name = "agree";
            radioButton4.Size = new System.Drawing.Size(42, 20);
            radioButton4.TabIndex = 46;
            radioButton4.TabStop = true;
            radioButton4.Text = "Agree";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += new EventHandler(RadioHandler);
            radioButton4.Tag = id;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radioButton5.Location = new System.Drawing.Point(380, 60);
            radioButton5.Name = "sAgree";
            radioButton5.Size = new System.Drawing.Size(42, 20);
            radioButton5.TabIndex = 46;
            radioButton5.TabStop = true;
            radioButton5.Text = "Strongly Agree";
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.CheckedChanged += new EventHandler(RadioHandler);
            radioButton5.Tag = id;
            // 
            // QTitle
            // 
            QTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            QTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            QTitle.Location = new System.Drawing.Point(110, y + 25);
            QTitle.Name = id;
            QTitle.Size = new System.Drawing.Size(368, 22);
            QTitle.TabIndex = 44;
            QTitle.Text = q;


            this.Controls.Add(QTitle);
            this.Controls.Add(Q);
        }


        private void dropdown(int y, string q, int count, string id, Array items)
        {
            ComboBox combo = new ComboBox();
            GroupBox Q = new GroupBox();
            TextBox QTitle = new TextBox();


            // 
            // combo
            // 
            combo.DataSource = items;
            combo.Location = new System.Drawing.Point(30, 60);
            combo.SelectedIndexChanged += new EventHandler(DropHandler);
            combo.Tag = id;
            // 
            // Qustion
            // 
            Q.Controls.Add(QTitle);
            Q.Controls.Add(combo);
            Q.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Q.Location = new System.Drawing.Point(80, y);
            Q.Name = id;
            Q.Size = new System.Drawing.Size(519, 101);
            Q.TabIndex = 41;
            Q.TabStop = false;
            Q.Text = "Qustion  " + count;
            // 
            // QTitle
            // 
            QTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            QTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            QTitle.Location = new System.Drawing.Point(110, y + 25);
            QTitle.Name = id;
            QTitle.Size = new System.Drawing.Size(368, 22);
            QTitle.TabIndex = 44;
            QTitle.Text = q;


            this.Controls.Add(QTitle);
            this.Controls.Add(Q);
        }
    }
}
