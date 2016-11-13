using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ElectronicSchoolDiary
{
    class Credentials
    {
        bool flag = false;

        public bool isNewFormOpened()
        {
            return flag;
        }
        public void  CheckLogin(TextBox Username, TextBox Password)
        {
            LoginForm logf = new LoginForm();
            string Dir = logf.GetHomeDirectory();
            string connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString + "Data Source ='" + @Dir + "\\DataBase.sdf'";

            using (SqlCeConnection Connection = new SqlCeConnection())
            {   if (Username.TextLength > 0 && Password.TextLength > 0)
                {
                    try
                    {
                        Connection.ConnectionString = connectionString;
                        Connection.Open();
                        SqlCeCommand logincommand = new SqlCeCommand(@"SELECT Id,UserName,Password FROM Users
                                        WHERE UserName=@uname and  Password=@pass", Connection);
                        logincommand.Parameters.AddWithValue("@uname", Username.Text);
                        logincommand.Parameters.AddWithValue("@pass", Password.Text);
                        SqlCeDataReader loginReader = logincommand.ExecuteReader();

                        if (loginReader.Read() &&
                            loginReader["UserName"].ToString() == Username.Text &&
                            loginReader["Password"].ToString() == Password.Text)
                        {
                            SqlCeCommand admincommand = new SqlCeCommand(@"SELECT Name,Surname,UsersId FROM Administration
                                                             WHERE UsersId =@LoggedId", Connection);
                            admincommand.Parameters.AddWithValue("@LoggedId", loginReader["Id"]);
                            SqlCeDataReader adminReader = admincommand.ExecuteReader(); //ADMIN

                            SqlCeCommand teachercommand = new SqlCeCommand(@"SELECT Name,Surname,UsersId FROM Teachers
                                                             WHERE UsersId =@LoggedId", Connection);
                            teachercommand.Parameters.AddWithValue("@LoggedId", loginReader["Id"]);
                            SqlCeDataReader teacherReader = teachercommand.ExecuteReader(); //TEACHER

                            SqlCeCommand directorcommand = new SqlCeCommand(@"SELECT Name,Surname,UsersId FROM Directors
                                                             WHERE UsersId =@LoggedId", Connection);
                            directorcommand.Parameters.AddWithValue("@LoggedId", loginReader["Id"]);
                            SqlCeDataReader directorReader = directorcommand.ExecuteReader(); //DIRECTOR

                            if (adminReader.Read() && loginReader["Id"].ToString() == adminReader["UsersId"].ToString())
                            {
                                 flag = true;
                                 Form newform = new AdministrationForm();
                                 newform.Show();
                            }
                            else if (teacherReader.Read() && loginReader["Id"].ToString() == teacherReader["UsersId"].ToString())
                            {
                                flag = true;
                                Form newform = new TeacherForm();
                                newform.Show();
                            }
                            else if (directorReader.Read() && loginReader["Id"].ToString() == directorReader["UsersId"].ToString())
                            {
                                flag = true;
                                Form newform = new DirectorForm();
                                newform.Show();
                            }
                            else
                            {
                                flag = false;
                                MessageBox.Show("Netacni podaci");
                            }
                        }
                        else
                        {
                            flag = false;
                            MessageBox.Show("Netacni podaci");
                            Username.Text = "";
                            Password.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                        MessageBox.Show("Neočekivana greška:" + ex.Message);
                    }
                }
            }
           
        }
    }                         
}
