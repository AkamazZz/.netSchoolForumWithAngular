using System;

namespace DataAccessLayer.Entity
{
    class Group
    {
        public int Group_Id { get; set;}
        public string Group_Name {get;set;}
 
        public virtual Student Student { get; set; }

        public Speciality Speciality { get; set; }
    }
}
