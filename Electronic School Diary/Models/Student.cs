using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Jmbg { get; set; }
        public string Address { get; set; }
        public string Phone_number { get; set; }
        public int DepartmentsId { get; set; }


        public Student(int id, string name, string surname, int jmbg, string address, string phone_number, int departmentsId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            Address = address;
            Phone_number = phone_number;
            DepartmentsId = departmentsId;
        }
    }
}
