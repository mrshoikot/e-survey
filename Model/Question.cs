using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace E_Survry.Model
{
    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public string survey_id { get; set; }
        public User creator { get; set; }
        public string type { get; set; }
        public Array options { get; set; }
        public List<Option> optionData { get; set; }
        public List<Answer> answers { get; set; }

        public Question(){
            this.answers = new List<Answer>();
            this.optionData = new List<Option>();
        }

        public void Save()
        {
            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            List<string> list = new List<string>();

            foreach (string item in this.options)
            {
                list.Add(item);
            }


            string sql = "INSERT INTO questions (question, type, survey_id, created_by, options) VALUES (@question, @type, @survey_id, @created_by, @options)";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@question", this.question);
            command.Parameters.AddWithValue("@type", this.type);
            command.Parameters.AddWithValue("@survey_id", this.survey_id);
            command.Parameters.AddWithValue("@created_by", this.creator.id);
            command.Parameters.AddWithValue("@options", String.Join(",", list));

            command.ExecuteNonQuery();

            
        }

        private int Count(string option)
        {
            int count = 0;
            foreach (Answer ans in this.answers)
            {
                
                if (ans.answer == option)
                {
                    count++;
                }
            }
            return count;
        }

        public void setDataById(string id)
        {
            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            string sql = "SELECT * from questions where id=" + id;
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                this.id = dataReader.GetInt32(0);
                this.question = dataReader.GetString(1);
                this.type = dataReader.GetString(2);
                this.options = dataReader.GetString(3).Split(',');
                this.survey_id = dataReader.GetInt32(4).ToString();

                break;
            }

            if (this.type == "Yes/No")
            {
                this.options = "Yes,No".Split(',');
            }else if(this.type == "5 Point Scale")
            {
                this.options = "Highly Disagree,Disagree,Neutral,Agree,Highly Agree".Split(',');
            }


            conn.Close();
            conn.Open();

            sql = "SELECT * from answers where question_id=" + this.id;
            command = new SqlCommand(sql, conn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Answer a = new Answer();
                a.setDataById(dataReader.GetInt32(0).ToString());
                this.answers.Add(a);
            }

            if (this.type == "Yes/No" || this.type == "Dropdown")
            {
                foreach (string op in this.options)
                {
                    Option option = new Option();
                    option.Text = op;
                    option.Count = Count(op);
                    this.optionData.Add(option);
                }
            }
            else
            {
                foreach (string op in this.options)
                {
                    Option option = new Option();
                    option.Text = op;
                    if (this.answers.Count == 0)
                    {
                        option.Count = 0;
                    }
                    else
                    {
                        option.Count = (Count(op) / this.answers.Count) * 100;
                    }
                    this.optionData.Add(option);
                }
            }
        }
    }

    public class Option
    {
        public string Text { get; set; }
        public float Count { get; set; }
    }

}
