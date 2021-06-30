using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    public class Teacher
    {
        public int Teacher_Id {get;set;}

        public University University { get; set; }

        public int University_Id {get; set;}

        public string FirstName {get;set;}

        public string LastName {get;set;}

        public ICollection<Teacher_subject> Teacher_Subject { get; set; }

    }
}
