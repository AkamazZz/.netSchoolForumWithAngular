using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.DataContext;
using DataAccessLayer.Functions.Interfaces;

namespace DataAccessLayer.Functions.Specific
{
    class GroupSpecific
    {
        public async Task<Dictionary<int,int>> GetTop5FromGroup(int group_id)
        {
            IAssessmentSpecific _aspec = new AssessmentSpecific();
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    
                    List<Student> Student = await context.Students.Where(f => f.Group_Id == group_id).ToListAsync();
                    var student_id = from st in Student
                                     select st.Student_Id;
                    List<AssessmentSpecific> Spec = new List<AssessmentSpecific>();
                    int gpa;
                    Dictionary<int, int> student_gpa = new Dictionary<int, int>();
                    foreach (var st_id in student_id)
                    {
                        gpa = await _aspec.GPA(st_id);
                        student_gpa.Add(st_id, gpa);
                    }
                    student_gpa.OrderByDescending(key => key.Value); // sorted
                    return student_gpa;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
