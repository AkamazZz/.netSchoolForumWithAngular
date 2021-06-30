using System;

namespace DataAccessLayer.Entity
{
    class Teacher_subject
    {
        
        public int Teacher_Id {get;set;}

        public  int Subject_Id {get;set;}

        public Subject Subject { get; set; }
   
    }
}
