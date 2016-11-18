using ElectronicSchoolDiary.Models;
using ElectronicSchoolDiary.Repos;
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
        private User CurrentUser;
        private Admin CurrentAdmin;
        public bool isPasswordChanged = false;

        public void warning()
        {
            MessageBox.Show("Polja ne mogu biti prazna !");
        }
        public AdministrationForm(User user, Admin admin)
        {
            InitializeComponent();
            this.Text = "Administrator : " + admin.Name + " "  + admin.Surname;
            CurrentUser = user;
            CurrentAdmin = admin;
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
            if (isPasswordChanged == false)
            {
                Form form = new LoginForm();
                form.Show();
                this.Close();
            }
            else
            {
                Environment.Exit(0);
                Close();
            }
        }

        private void AddAdminButton_Click(object sender, EventArgs e)
        {
            if (AdminNameTextBox.Text.Length == 0 || AdminSurnameTextBox.Text.Length == 0 || UserNameTextBox.Text.Length == 0)
            {
                warning();
            }
            else
            {
               
                AdminRepository.AddAdmin(AdminNameTextBox.Text, AdminSurnameTextBox.Text, UserNameTextBox.Text, AdminNameTextBox.Text + AdminSurnameTextBox.Text);
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
            else
            {
                if (OldPassTextBox.Text == NewPassTextBox.Text)
                {
                    MessageBox.Show("Unesite novu lozinku koja se razlikuje od stare !");
                }
                else if (OldPassTextBox.Text == CurrentUser.Password && NewPassTextBox.Text == ConfirmedNewPassTextBox.Text)
                {
                    UsersRepository.ChangeAdminPassword(CurrentUser.Id, OldPassTextBox.Text, NewPassTextBox.Text, ConfirmedNewPassTextBox.Text);
                    isPasswordChanged = true;
                    OldPassTextBox.Text = "";
                    NewPassTextBox.Text = "";
                    ConfirmedNewPassTextBox.Text = "";
                }
                else if(NewPassTextBox.Text != ConfirmedNewPassTextBox.Text)
                MessageBox.Show("Nove lozinke se ne poklapaju !");
                else MessageBox.Show("Pogrešna lozinka !");

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