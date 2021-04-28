using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace E_Survry.Model
{
    public class Answer
    {
        public int id { get; set; }
        public string question_id { get; set; }
        public string answer { get; set; }
        public User user { get; set; }

        public void Save()
        {
            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            string sql = "INSERT INTO answers (answer, question_id, user_id) VALUES (@answer, @question_id, @user_id)";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@answer", this.answer);
            Console.WriteLine(this.answer);
            command.Parameters.AddWithValue("@question_id", this.question_id);
            command.Parameters.AddWithValue("@user_id", this.user.id);

            command.ExecuteNonQuery();
        }

        public void setDataById(string id)
        {
            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            string sql = "SELECT * from answers where id=" + id;
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                this.id = dataReader.GetInt32(0);
                this.question_id = dataReader.GetString(1);
                this.answer = dataReader.GetString(2);
                User user = new User();
                user.setDataById(dataReader.GetInt32(3).ToString());
                this.user = user;

                break;
            }

        }
    }

   
}
