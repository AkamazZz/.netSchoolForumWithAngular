using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    class University
    {
        public int University_Id{get;set;}

        public string University_Name{get;set;}

        public ICollection<Student> Student { get; set; }

        public ICollection<Teacher> Teacher { get; set; }
    }
}
