using System;
    using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    public class Student_subject
    {
        public int Student_Id {get;set;}
        public int Subject_Id {get;set;}

        public Student Student { get; set; }

        public Subject Subject { get; set; }
    
    }
}
