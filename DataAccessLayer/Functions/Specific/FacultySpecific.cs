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
    public class FacultySpecific: IFacultySpecific
    {
        public async Task<Dictionary<int,double>> GetTopFromFaculty(int faculty_id)
        {
            IAssessmentSpecific _aspec = new AssessmentSpecific();
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    
                    List<int>Student = await context.Students.Where(f => f.Faculty_Id == faculty_id).Select(x => x.Student_Id).ToListAsync();
                    
                    double gpa;
                    Dictionary<int, double> student_gpa = new Dictionary<int, double>();
                    foreach (var student in Student)
                    {
                        gpa =  _aspec.GPA(student);
                        student_gpa.Add(student, gpa);
                    }
                   var st =  student_gpa.OrderByDescending(key => key.Value).ToDictionary(x => x.Key, x=> x.Value); // sorted
                   
                    return st;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
