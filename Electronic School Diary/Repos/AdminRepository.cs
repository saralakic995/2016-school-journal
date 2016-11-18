using ElectronicSchoolDiary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary.Repos
{
    class AdminRepository
    {
        public static void AddAdmin(string AdminName, string AdminSurname,string AdminUserName,string Password)
        {
            try
            {
                using (SqlCeConnection Connection = DataBaseConnection.Instance.Connection)

                {
                    SqlCeCommand command1 = new SqlCeCommand(@"INSERT INTO Users(Name,Password)
                    VALUES(@name, @password)", Connection);
                    command1.Parameters.AddWithValue("@name", AdminUserName);
                    command1.Parameters.AddWithValue("@password", Password);

                    SqlCeCommand command2 = new SqlCeCommand(@"SELECT Id FROM Users WHERE UserName = @name,Password = @password ",Connection);
                    command1.Parameters.AddWithValue("@name", AdminUserName);
                    command1.Parameters.AddWithValue("@password", Password);
                    SqlCeDataReader reader = command2.ExecuteReader();
                    reader.Read();
                    
                    SqlCeCommand command = new SqlCeCommand(@"INSERT INTO Administration(Name,Surname,UsersId)
                    VALUES(@name, @surname, @usersId)", Connection);
                    command.Parameters.AddWithValue("@name", AdminName);
                    command.Parameters.AddWithValue("@surname", AdminSurname);
                    command.Parameters.AddWithValue("@usersId", reader["Id"]);
                    
                    int result = command.ExecuteNonQuery();
                    int result1 = command1.ExecuteNonQuery();
                    if (result > 0 && result1 > 0)
                    {
                        MessageBox.Show("Administrator uspješno dodat !");

                    }
                    else
                    {
                        MessageBox.Show("Administrator nije  dodat !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
