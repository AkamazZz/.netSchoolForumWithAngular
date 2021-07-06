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
        public async Task<int> GPA(int student_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    List<Assessment> grade = await context.Assessments.Where(g => g.Student_Id == student_id).ToListAsync();
                    var assessment = from g in grade
                                     select g.Grade;
                    int sum = 0;
                    int iteration = 0;
                    foreach (var a in assessment)
                    {
                        sum += a;
                        ++iteration;
                    }

                    return sum / iteration;
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

                    var mark = await context.Assessments.Where(g => g.Student_Id == student_id).Where(s => s.Subject_Id == subject_id).ToListAsync();

                    if (mark.Count == 1)
                    {
                        mark.ElementAt(0).Grade = grade;
                        var trackingApplicant = await context.Assessments.AddAsync(mark.ElementAt(0));
                        await context.SaveChangesAsync();
                        return mark.ElementAt(0);
                    }
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

