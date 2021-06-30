using System;

namespace DataAccessLayer.Entity
{
    public class Speciality
    {
       public int Speciality_Id {get;set;}

       public int Faculty_Id {get;set;}

       public string Speciality_name {get; set;}

        public virtual Student Student { get; set; }

        public Faculty Faculty{ get; set; }
    }
}
