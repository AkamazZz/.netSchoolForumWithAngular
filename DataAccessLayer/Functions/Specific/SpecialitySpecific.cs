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
    public class SpecialitySpecific: ISpecialitySpecific
    {
        public async Task<Dictionary<int, double>> GetTopFromSpeciliaty(int speciality_id)
        {
            IAssessmentSpecific _aspec = new AssessmentSpecific();
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    List<int> student_id = await context.Students.Where(f => f.Speciality_Id == speciality_id).Select(st => st.Student_Id).ToListAsync();
                    double gpa;
                    Dictionary<int, double> student_gpa = new Dictionary<int, double>();
                    foreach (var st_id in student_id)
                    {
                        gpa =  _aspec.GPA(st_id);
                        student_gpa.Add(st_id, gpa);
                    }
                    var students = student_gpa.OrderByDescending(key => key.Value).ToDictionary(x => x.Key, x => x.Value); // sorted

                    return students;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
