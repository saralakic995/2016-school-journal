using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TeachersId { get; set; }
        public int ClassesId { get; set; }

        public Department(int id, string title, int teachersId, int classesId)
        {
            Id = id;
            Title = title;
            TeachersId = teachersId;
            ClassesId = classesId;
        }
    }
}
