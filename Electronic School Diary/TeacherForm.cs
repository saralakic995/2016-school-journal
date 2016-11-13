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

namespace ElectronicSchoolDiary
{  
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        public void warning()
        {
            MessageBox.Show("Polja ne mogu biti prazna !");
        }
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            PasswordPanel.Hide();
            ControlBox = false;
            TrueFalseAbsentComboBox.SelectedIndex = 1;
            AbsentHourComboBox.SelectedIndex = 0;
        }

        private void LogOutUserButton_Click(object sender, EventArgs e)
        {
            Form form = new LoginForm();
            form.Show();
            this.Hide();
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
                warning();
            }
        }

        private void AddMarkButton_Click(object sender, EventArgs e)
        {
            if (MarkTextBox.Text.Length == 0 )
            {
                MessageBox.Show("Polje ne moze biti prazno");
            }
        }
    }
}