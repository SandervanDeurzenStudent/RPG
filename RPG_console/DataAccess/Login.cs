using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace RPG_console.Data_access
{
    class Login
    {
        public bool checkLogin(string usr, string pwd)
        {
            DB db = new DB();

            db.OpenConnection();
            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username = @usn and password = @pass", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = usr;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pwd;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            using (MySqlDataReader getUserId = adapter.SelectCommand.ExecuteReader())
            {
                if (getUserId.HasRows)
                {
                    while (getUserId.Read())
                    {
                        if (table.Rows.Count > 0)
                        {
                            DAL.Player.name = Convert.ToString(getUserId["username"]);
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool Register(string username, string password)
        {
            DB db = new DB();
            db.OpenConnection();
            if (username != string.Empty || password != string.Empty || username != string.Empty)
            {
                
                
                   MySqlCommand cmd = new MySqlCommand("select * from users where username='" + username + "'", db.GetConnection());
                   MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    db.CloseConnection();
                    Console.WriteLine("Username Already exist, please try another ");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    dr.Close();
                    
                    cmd = new MySqlCommand("insert into users values(@username,@password)", db.GetConnection());
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                   
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Your Account is created . Please login now.", "Done");
                    Console.ReadLine();
                    return true;

                }
            }
            else
            {
                Console.WriteLine("Please enter value in all field.");
                Console.ReadLine();
                return false;
            }
            return false;
        }
    }
}
