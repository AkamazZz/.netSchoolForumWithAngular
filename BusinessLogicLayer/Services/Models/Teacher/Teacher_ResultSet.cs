using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Models.Teacher{
    public class Teacher_ResultSet
    {
        public int teacher_id { get; set; }

        public int university_id { get; set; }

        public string teacher_name { get; set; }

        public string teacher_surname { get; set; }
    }
}
