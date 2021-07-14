﻿using System;
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
        public async Task<Dictionary<Student, double>> GetTopFromSpeciliaty(int speciality_id)
        {
            IAssessmentSpecific _aspec = new AssessmentSpecific();
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    var student_id = await context.Students.Where(f => f.Speciality_Id == speciality_id).ToListAsync();
                  
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
