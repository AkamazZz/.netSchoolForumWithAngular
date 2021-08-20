using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Models.Assessment
{
    public class Assessment_ResultSet
    {
        public int assessment_id { get; set; }
        public int student_id { get; set; }
        public int subject_id { get; set; }
        public int grade { get; set; }
    }
}
