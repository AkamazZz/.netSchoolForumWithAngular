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
    public class AssessmentSpecific: IAssessmentSpecific
    { // Don't forger to add a function which will take list of subjects which have student, but before that make function where will be taken subject_id from student_subject entity
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
                  
                    return sum/iteration;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
