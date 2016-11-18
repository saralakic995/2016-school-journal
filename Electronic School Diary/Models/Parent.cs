using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public int StudentsId { get; set; }


        public Parent(int id, string name, string surname, string address,string email, string phone_number, int studentsId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            Email = email;
            Phone_number = phone_number;
            StudentsId = studentsId;
        }
    }
}
