using System;

namespace DataAccessLayer.Entity
{
    class Subject
    {
       public int Subject_Id {get;set;}
       public string Subject_name {get;set;}

       public Assessment Assessment { get; set; }

       
    }
}

