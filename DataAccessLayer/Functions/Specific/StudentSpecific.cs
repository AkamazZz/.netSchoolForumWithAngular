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
   public  class StudentSpecific: IStudentSpecific
    {
        private IAssessmentSpecific _aspec = new AssessmentSpecific();

        public async Task<Student> GetStudentIdByFullName(string name, string surname)
        {
            using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {

                Student Student = await context.Students.Where(n => n.FirstName == name).Where(s => s.LastName == surname).FirstAsync();

                return Student;
            }
        }

        public async Task<Dictionary<int,double>> GetTop()
        {

            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    
                    List<int> student_id = await context.Students.Select(x => x.Student_Id).ToListAsync(); // from db
                    
                    double gpa;
                    Dictionary<int, double> student_gpa = new Dictionary<int, double>();
                    foreach (var student in student_id)
                    {
                        gpa = _aspec.GPA(student);
                        student_gpa.Add(student, gpa);
                    }
                    var st = (from stud in student_gpa orderby stud.Value descending select stud).ToDictionary(x => x.Key, x => x.Value); // sorted
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
