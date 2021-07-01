using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Models.Student
{
    public class Student_ResultSet
    {
        public int student_id { get; set; }

        public int university_id { get; set; }

        public int speciality_id { get; set; }


        public int faculty_id { get; set; }


        public int group_id { get; set; }

        public string student_name{ get; set; }

        public string student_surname { get; set; }
    }
}