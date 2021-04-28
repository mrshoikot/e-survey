using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace E_Survry.Model
{
    public class Survey
    {

        public int id { get; set; }
        public string name { get; set; }
        public User creator { get; set; }
        public List<Question> questions { get; set; }

        public Survey(int id)
        {
            this.questions = new List<Question>();
            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            string sql = "SELECT * from surveys where id=" + id;
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                this.id = dataReader.GetInt32(0);
                this.name = dataReader.GetString(1);
                User user = new User();
                user.setDataById(dataReader.GetInt32(2).ToString());
                this.creator = user;

                break;
            }

            conn.Close();
            conn.Open();

            sql = "SELECT * from questions where survey_id=" + this.id;

            
            command = new SqlCommand(sql, conn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Question q = new Question();
                q.setDataById(dataReader.GetInt32(0).ToString());
                this.questions.Add(q);
            }
        }

        public void Delete()
        {
            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand command = new SqlCommand("delete from surveys where id=" + this.id, conn);
            command.ExecuteReader();

        }

    }
}
