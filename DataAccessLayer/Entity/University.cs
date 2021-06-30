using System;

namespace DataAccessLayer.Entity
{
    class University
    {
        public int University_Id{get;set;}

        public string University_Name{get;set;}

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }
    }
}
