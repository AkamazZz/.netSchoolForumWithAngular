using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity
{
    public class Faculty
    {
        public int Faculty_Id {get; set;}
        public string Faculty_name {get; set;}

        public virtual Student Student{ get; set; }
        public ICollection<Speciality> Speicality { get; set; }
    }
}
