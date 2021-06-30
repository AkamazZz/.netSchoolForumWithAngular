using System;
using University_hierarchy.Interface;

namespace University_hierarchy.Entity
{
    class Student : IStudent
    {
        public int Id {get;set;}

         public int Speciality_Id {get;set;}

          public int Faculty_Id {get;set;}

        public int Group_Id {get;set;}

        public string FirstName {get; set;}

        public string LastName {get; set;}

        
    }
}
