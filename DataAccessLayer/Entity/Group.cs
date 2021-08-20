using System;

namespace DataAccessLayer.Entity
{
    public class Group
    {
        public int Group_Id { get; set;}
        public string Group_Name {get;set;}
 
        public Student Student { get; set; }
    }
}
