using System;
using System.Collections.Generic;

namespace Hierarchy.Models.Student
{
    public class Student_Update_Object
    {
        public int student_id { get; set; }
        public int speciality_id { get; set; }
        public string speciality_name { get; set; }

        public int faculty_id { get; set; }

        public string faculty_name { get; set; }

        public int group_id { get; set; }

        public string group_name { get; set; }

        public string student_name { get; set; }

        public string student_surname { get; set; }


    }
}
