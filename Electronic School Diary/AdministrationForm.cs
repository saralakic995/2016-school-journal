using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary
{
    public partial class AdministrationForm : Form
    {
      
        public void warning()
        {
            MessageBox.Show("Polja ne mogu biti prazna !");
        }
        public AdministrationForm()
        {
            InitializeComponent();
        }

        private void AdministrationForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
            ControlBox = false;
            UserBox.SelectedIndex = 2;
            ClassNumberComboBox.SelectedIndex = 0;
        }
        private string selectedUser()
        {
            return UserBox.Text;
        }
        private void UserBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            try
            {
                string current = selectedUser();
              if(current == "Administratora")
                {
                    AdministratorPanel.Show();
                    label2.Show();
                    UserBox.Show();
                    StudentPanel.Hide();
                    TeachersPanel.Hide();
                    PasswordPanel.Hide();
                    DepartmentPanel.Hide();
                }
            if (current == "Nastavnika")
            {
                TeachersPanel.Show();
                label2.Show();
                UserBox.Show();
                StudentPanel.Hide();
                AdministratorPanel.Hide();
                PasswordPanel.Hide();
                DepartmentPanel.Hide();
            }
            if (current == "Ucenika i roditelja")
            {
                StudentPanel.Show();
                label2.Show();
                UserBox.Show();
                TeachersPanel.Hide();
                AdministratorPanel.Hide();
                PasswordPanel.Hide();
                DepartmentPanel.Hide();
            }
           
                if (current == "Odjeljenja i razrednici")
                {
                    DepartmentPanel.Show();
                    label2.Show();
                    UserBox.Show();
                    StudentPanel.Hide();
                    TeachersPanel.Hide();
                    AdministratorPanel.Hide();
                    PasswordPanel.Hide();
                }


            }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }

        }

        private void UserSettingsButton_Click(object sender, EventArgs e)
        {
            UserBox.SelectedIndex = 2;
            PasswordPanel.Show();
            StudentPanel.Hide();
            TeachersPanel.Hide();
            AdministratorPanel.Hide();
            DepartmentPanel.Hide();
            label2.Hide();
            UserBox.Hide();

        }

        private void LogOutUserButton_Click(object sender, EventArgs e)
        {
            Form form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void AddAdminButton_Click(object sender, EventArgs e)
        {
            if( AdminUserNameTextBox.Text.Length == 0 || AdminPasswordTextBox.Text.Length == 0)
            {
                warning();
            }
        }

         private void ChangePassAdminButton_Click(object sender, EventArgs e)
        {
            
            if (OldPassTextBox.Text.Length == 0 ||
                NewPassTextBox.Text.Length == 0 ||
                ConfirmedNewPassTextBox.Text.Length == 0)
            {
                warning();
            }
        }

        private void AddParentButton_Click(object sender, EventArgs e)
        {
            if (ParentNameTextBox.Text.Length == 0 ||
             ParentSurnameTextBox.Text.Length == 0 )
            {
                warning();
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentNameTextBox.Text.Length == 0 ||
            StudentSurnameTextBox.Text.Length == 0 ||
            StudentJmbgTextBox.Text.Length == 0 )
            {
                warning();
            }
        }

        private void AddTeacherButton_Click(object sender, EventArgs e)
        {

           if (TeacherNameTextBox.Text.Length == 0 ||
              TeacherSurnameTextBox.Text.Length == 0 ||
              TeacherPasswordTextBox.Text.Length == 0)
            {
                warning();
            }
        }

        private void ControlTableButton_Click(object sender, EventArgs e)
        {
            StudentPanel.Show();
            label2.Show();
            UserBox.Show();
            TeachersPanel.Hide();
            AdministratorPanel.Hide();
            DepartmentPanel.Hide();
            PasswordPanel.Hide();
        }

        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            if(CourseTextBox.Text.Length == 0)
            {
                warning();
            }
        }

        private void AddDepartmentAndClassTeacherButton_Click(object sender, EventArgs e)
        {
            if(StudentNameTextBox.Text.Length == 0 ||
               StudentSurnameTextBox.Text.Length == 0 ||
               StudentNameTextBox.Text.Length == 0 ||
               StudentJmbgTextBox.Text.Length == 0 ||
               ParentNameTextBox.Text.Length == 0 ||
               ParentSurnameTextBox.Text.Length == 0 ||
               StudentNameTextBox.Text.Length == 0
                )
            {
                warning();
            }
        }
    }
}