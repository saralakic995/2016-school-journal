using ElectronicSchoolDiary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Repos
{
    class TeacherRepository
    {
        public static Teacher GetById(int id)
        {
            SqlCeConnection Connection = DataBaseConnection.Instance.Connection;

            SqlCeCommand teachercommand = new SqlCeCommand(@"SELECT * FROM Teachers WHERE UsersId =@LoggedId", Connection);
            teachercommand.Parameters.AddWithValue("@LoggedId", id);
            SqlCeDataReader reader = teachercommand.ExecuteReader(); 

            reader.Read();

            Teacher result = new Teacher((int)reader["Id"], (string)reader["Name"], (string)reader["Surname"],(string)reader["Address"],(string)reader["Phone_number"], (int)reader["UsersId"]);

            reader.Close();

            return result;
        }
    }
}
