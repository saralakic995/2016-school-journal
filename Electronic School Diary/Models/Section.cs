using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicSchoolDiary.Models
{
    class Section
    {
        public int Id { get; set; }
        public string Description { get; set; }
       


        public Section(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
