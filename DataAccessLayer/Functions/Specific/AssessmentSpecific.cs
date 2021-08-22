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
    public class AssessmentSpecific : IAssessmentSpecific
    {
        public double GPA(int student_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var numberSubjects = context.Student_Subjects.Where(s => s.Student_Id == student_id).Count(sub => sub.Subject_Id == sub.Subject_Id);
                    if (numberSubjects > 0)
                    {
                        double grade = context.Assessments.Where(g => g.Student_Id == student_id).Average(g => g.Grade);


                        return grade;
                    }
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<Assessment> UpdateGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    var mark = await context.Assessments.Where(g => g.Student_Id == student_id).Where(s => s.Subject_Id == subject_id).FirstOrDefaultAsync();

                    if (mark != null)
                    {
                        mark.Grade = grade;
                        await context.SaveChangesAsync();
                        return mark;
                    }
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
            public async Task<Assessment> GetAssessmentByStudentIdAndSubjectId(int student_id, int subject_id)
            {
                try
                {
                    using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                    {

                        var mark = await context.Assessments.Where(g => g.Student_Id == student_id).Where(s => s.Subject_Id == subject_id).FirstOrDefaultAsync();
                        if(mark == null) {

                        mark = new Assessment
                        {
                            Student_Id = student_id,
                            Subject_Id = subject_id,
                            Grade = 0

                        };
                        await context.AddAsync<Assessment>(mark);
                        await context.SaveChangesAsync();
                    }
                        return mark;
                    }
                }
                catch
                {
                    throw;
                }
            }
        public async Task<List<Assessment>> GetAssessmentByStudentId(int student_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    var mark = await context.Assessments.Where(g => g.Student_Id == student_id).ToListAsync();
                    
                    return mark;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

