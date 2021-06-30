using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    public class Student 
    {
        public int Student_Id {get;set;}

        public int University_Id { get; set; }

        public University University{ get; set; }

        public int Speciality_Id {get;set;}

        public virtual Speciality Speciality { get; set; }

        public int Faculty_Id {get;set;}

        public virtual Faculty Faculty { get; set; }

        public int Group_Id {get;set;}
        public  Group Group { get; set; }

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public ICollection<Student_subject> Student_Subject { get; set; }

        public ICollection<Assessment> Assessment { get; set; }


    }
}
