using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    public class Subject
    {
       public int Subject_Id {get;set;}
       public string Subject_name {get;set;}

       public Assessment Assessment { get; set; }

       public ICollection<Teacher_subject> Teacher_Subject { get; set; }

       public ICollection<Student_subject> Student_Subject { get; set; }

    }
}

