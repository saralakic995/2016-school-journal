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
    class UsersRepository
    {
        public static void ChangeAdminPassword(int id, string oldPassword, string newPassword, string confirmedNewPassword)
        {
            try
            {
                using (SqlCeConnection Connection = DataBaseConnection.Instance.Connection)

                {
                    SqlCeCommand command = new SqlCeCommand(@"UPDATE Users SET Password = @pass WHERE Id=@LoggedId;", Connection);
                    command.Parameters.AddWithValue("@LoggedId", id);
                    command.Parameters.AddWithValue("@pass", newPassword);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    { 
                    MessageBox.Show("Lozinka je uspješno promijenjena !");
                      
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
