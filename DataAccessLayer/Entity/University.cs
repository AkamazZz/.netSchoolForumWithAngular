using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    public class University
    {
        public int University_Id{get;set;}

        public string University_Name{get;set;}

        public ICollection<Student> Students { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
