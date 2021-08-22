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
        public async Task<List<Student>> GetAllStudents()
        {
            using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {

                // var s = context.Students.Select(dp => Tuple.Create(dp.Student_Id, dp.Speciality_Id,
                  //  dp.Faculty_Id, dp.Group_Id, dp.University_Id, dp.FirstName, dp.LastName));
                var Student = await context.Students.Select(dp => new { Student_Id = dp.Student_Id,  Faculty_Id = dp.Faculty_Id,
                Speciality_Id = dp.Speciality_Id, Group_Id = dp.Group_Id, Name = dp.FirstName, Surname = dp.LastName}).ToListAsync();
                List<Student> st = new List<Student>();
                foreach(var s in Student)
                {
                    st.Add(new Student
                    {
                        Student_Id = s.Student_Id,
                        Faculty_Id = s.Faculty_Id,
                        Speciality_Id = s.Speciality_Id,
                        Group_Id = s.Group_Id,
                        FirstName = s.Name,
                        LastName = s.Surname,

                    }

                        );
                }

                return st;
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
        public async Task<bool> DeleteStudent(int student_id)
        {

            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var toDelete = await context.Students.Where(x => x.Student_Id == student_id).FirstOrDefaultAsync();
                    if (toDelete != null) {

                        var deleteAssessments = await context.Assessments.Where(x => x.Student_Id == student_id).ToListAsync();
                        if (deleteAssessments != null)
                        {
                            foreach (var assessment in deleteAssessments)
                            {
                                context.Remove(assessment);
                                await context.SaveChangesAsync();
                            }
                        }
                        var deleteSubjects = await context.Student_Subjects.Where(x => x.Student_Id == student_id).ToListAsync();
                        if(deleteSubjects != null)
                        {
                            foreach (var subject in deleteSubjects) {
                                context.Remove(subject);
                                await context.SaveChangesAsync();
                            }
                        }
                        
                        context.Remove(toDelete);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
