using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace E_Survry.Model
{
    public static class Auth
    {
        public static User user { get; set; }


        public static void Login(int id, string name, bool isAdmin, string email)
        {
            user = new User();
            user.setData(id, name, isAdmin, email);
        }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isAdmin { get; set; }
        public string email { get; set; }

        public void setData(int id, string name, bool isAdmin, string email)
        {
            this.id = id;
            this.name = name;
            this.isAdmin = isAdmin;
            this.email = email;
        }

        public void setDataById(string id)
        {
            string connString;
            SqlConnection conn;
            connString = Global.connString;
            conn = new SqlConnection(connString);

            conn.Open();

            string sql = "SELECT * from users where id="+id;
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                this.id = dataReader.GetInt32(0);
                this.name = dataReader.GetString(1);
                this.email = dataReader.GetString(2);
                this.isAdmin = dataReader.GetString(3) == "admin";
                this.email = dataReader.GetString(4);

                break;
            }
        }
        
    }
}
