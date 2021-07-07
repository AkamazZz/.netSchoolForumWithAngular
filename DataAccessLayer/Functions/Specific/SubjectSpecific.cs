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
    public class SubjectSpecific: ISubjectSpecific
    { 
        public async Task<List<string>> SubjectsOfStudent(int student_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    List<string> list = await context.Student_Subjects.Include(s => s.Subject).Where(x => x.Student_Id == student_id).Select(y => y.Subject.Subject_name).ToListAsync();
                    
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}