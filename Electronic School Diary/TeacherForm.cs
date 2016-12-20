using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ElectronicSchoolDiary.Models;
using ElectronicSchoolDiary.Repos;

namespace ElectronicSchoolDiary
{  
    public partial class TeacherForm : Form
    {
        private User CurrentUser;
        private Teacher CurrentTeacher;

        public void Warning()
        {
            MessageBox.Show("Polja ne mogu biti prazna !");
        }

        public TeacherForm(User user, Teacher teacher)
        {
            InitializeComponent();
            this.Text = "Nastavnik : " + teacher.Name + " " + teacher.Surname;
            CurrentUser = user;
            CurrentTeacher = teacher;

          
        }
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            PasswordPanel.Hide();
            ControlBox = false;
            TrueFalseAbsentComboBox.SelectedIndex = 1;
            AbsentHourComboBox.SelectedIndex = 0;
            PopulateStudentsComboBox();
            PopulateCoursesComboBox();
            FillStudentInfoLabels();
            FillParentInfoLabels();
        }
        private void PopulateStudentsComboBox()
        {
            string Name = StudentRepository.GetNameQuery();
            string Surname = StudentRepository.GetSurnameQuery();
            Lists.FillDropDownList2(Name, "Name", Surname, "Surname", StudentsBox);
        }
   
        private void PopulateCoursesComboBox()
        {
            string Title = CoursesRepository.GetQuery();
            Lists.FillDropDownList1(Title, "Title", CoursesBox);
        }
        private Student CurrentStudent()
        {
            Student student;
            string currentStudentName;
            string currentStudentSurname;
         
                string[] parts = StudentsBox.Text.Split('-');
                 currentStudentName = parts[0];
                 currentStudentSurname = parts[1];

           
                student = StudentRepository.GetStudentByName(currentStudentName, currentStudentSurname);
            
            return student;
        }
        private Parent CurrentParent()
        {
            Parent parent;
            Student student = CurrentStudent();
            int studentId = StudentRepository.GetIdByJmbg(student.Jmbg);
            parent = ParentRepository.GetParentByStudentId(studentId);
            return parent;
        }
        private void FillStudentInfoLabels()
        {
            Student student = CurrentStudent();
            int departmentId = StudentRepository.GetDepartmentIdByStudent(student);
            int departmentTitle = DepartmentsRepository.GetTitleById(departmentId);
            StudentNameLabel.Text = student.Name;
            StudentSurnameLabel.Text = student.Surname;
            StudentJmbgLabel.Text = student.Jmbg.ToString();
            StudentAddressLabel.Text = student.Address;
            StudentPhoneLabel.Text = student.Phone_number;
            DepartmentLabel.Text = departmentTitle.ToString();
        }
        private void FillParentInfoLabels()
        {
            Parent parent = CurrentParent();
            ParentNameLabel.Text = parent.Name;
            ParentSurnameLabel.Text = parent.Surname;
            ParentAddressLabel.Text = parent.Address;
            ParentEmailLabel.Text = parent.Email;
            ParentPhoneLabel.Text = parent.Phone_number;
        }
        private void LogOutUserButton_Click(object sender, EventArgs e)
        {
                Form form = new LoginForm();
                form.Show();
                this.Close();
        }

        private void UserSettingsButton_Click(object sender, EventArgs e)
        {
            PasswordPanel.Show();
        }

        private void MarksLabel_Click(object sender, EventArgs e)
        {

        }

        private void JustifiedAbsentLabel_Click(object sender, EventArgs e)
        {

        }

        private void UnjustifiedAbsentLabel_Click(object sender, EventArgs e)
        {

        }

        private void PrintStatisticTeacherRoundedButton_Click(object sender, EventArgs e)
        {
             //TODO Dodati ovde da se pojavi da biramo statistiku po ucenicima, predmetima itd...
        }

        private void ControlTableButton_Click(object sender, EventArgs e)
        {
            PasswordPanel.Hide();
        }

        private void AddTeacherPasswordButton_Click(object sender, EventArgs e)
        {
            if (OldPassTextBox.Text.Length == 0 ||
                 NewPassTextBox.Text.Length == 0 ||
                 ConfirmedNewPassTextBox.Text.Length == 0)
            {
                Warning();
            }
            else
            {
                if (OldPassTextBox.Text == NewPassTextBox.Text)
                {
                    MessageBox.Show("Unesite novu lozinku koja se razlikuje od stare !");
                }
                else if (OldPassTextBox.Text == CurrentUser.Password && NewPassTextBox.Text == ConfirmedNewPassTextBox.Text)
                {
                   bool isChanged = UsersRepository.ChangePassword(CurrentUser.Id, OldPassTextBox.Text, NewPassTextBox.Text, ConfirmedNewPassTextBox.Text);
                  if(isChanged == true)
                    {
                        PasswordPanel.Hide();
                        UserSettingsButton.Hide();
                    }
                }
                else if (NewPassTextBox.Text != ConfirmedNewPassTextBox.Text)
                    MessageBox.Show("Nove lozinke se ne poklapaju !");
                else MessageBox.Show("Pogrešna lozinka !");

            }
        }

        private void AddMarkButton_Click(object sender, EventArgs e)
        {
            if (MarkTextBox.Text.Length == 0 )
            {
                MessageBox.Show("Polje ne moze biti prazno");
            }
        }

        private void StudentsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudentInfoLabels();
            FillParentInfoLabels();
        }
    }
}