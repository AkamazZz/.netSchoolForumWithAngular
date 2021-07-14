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

        public async Task<Dictionary<int, double>> GetTop()
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    
                    List<Student> Student = await context.Students.ToListAsync(); // from db
                    var student_id = from st in Student // after saved in memory , not in db
                                     select st.Student_Id;
                    double gpa;
                    Dictionary<int, double> student_gpa = new Dictionary<int, double>();
                    foreach (var st_id in student_id)
                    {
                        gpa =  _aspec.GPA(st_id);
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
