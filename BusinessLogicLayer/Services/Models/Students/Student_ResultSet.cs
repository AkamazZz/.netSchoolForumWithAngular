using System;

namespace BusinessLogicLayer.Services.Models.Students
{
    public class Student_ResultSet
    {
        public int student_id { get; set; }

        public int university_id { get; set; }

        public int speciality_id { get; set; }
        public string speciality_name { get; set; }

        public int faculty_id { get; set; }

        public string faculty_name { get; set; }

        public int group_id { get; set; }

        public string group_name { get; set; }

        public string student_name{ get; set; }

        public string student_surname { get; set; }

        
    }
}