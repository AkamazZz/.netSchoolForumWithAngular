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

        public async Task<Dictionary<Student , double>> GetTop()
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    
                    List<Student> student_id = await context.Students.ToListAsync(); // from db
                    
                    double gpa;
                    Dictionary<Student, double> student_gpa = new Dictionary<Student, double>();
                    foreach (var student in student_id)
                    {
                        gpa = _aspec.GPA(student.Student_Id);
                        student_gpa.Add(student, gpa);
                    }
                    var st = student_gpa.OrderByDescending(key => key.Value).ToDictionary(x => x.Key, x => x.Value); // sorted

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
