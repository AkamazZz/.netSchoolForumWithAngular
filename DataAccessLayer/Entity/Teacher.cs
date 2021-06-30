using System;

namespace DataAccessLayer.Entity
{
    class Teacher
    {
        public int Teacher_Id {get;set;}

        public int University_Id {get; set;}

        public string FirstName {get;set;}

        public string LastName {get;set;}

        public Teacher_subject Teacher_Subject { get; set; }

    }
}
