using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    class Student 
    {
        public int Id {get;set;}

        public int University_Id { get; set; }

        public University University{ get; set; }

        public int Speciality_Id {get;set;}

        public virtual Speciality Speciality { get; set; }

        public int Faculty_Id {get;set;}

        public virtual Faculty Faculty { get; set; }

        public int Group_Id {get;set;}
        public virtual Group Group { get; set; }

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public ICollection<Student_subject> Student_Subject { get; set; }


    }
}
