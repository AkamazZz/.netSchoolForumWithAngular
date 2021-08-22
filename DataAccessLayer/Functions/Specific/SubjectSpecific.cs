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
    public class SubjectSpecific: ISubjectSpecific
    { 
        public async Task<List<Subject>> SubjectsOfStudent(int student_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    var list = await context.Student_Subjects.Include(s => s.Subject).Where(x => x.Student_Id == student_id).Select(z => z.Subject).ToListAsync();
                    
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteSubjectFromStudent(int student_id, int subject_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {

                    var deleteObject = await context.Student_Subjects
                        .Where(x => x.Student_Id == student_id)
                        .Where(y => y.Subject_Id == subject_id)
                        .FirstOrDefaultAsync();
                    var deleteGrades = await context.Assessments
                        .Where(x => x.Student_Id == student_id)
                        .Where(y => y.Subject_Id == subject_id)
                        .ToListAsync();
                    if (deleteObject != null)
                    {
                        context.Remove(deleteObject);
                        await context.SaveChangesAsync();
                        context.Remove(deleteGrades);
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
        public async Task<Student_subject> AddSubjectToStudent(int student_id, int subject_id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    if (!await context.Student_Subjects
                        .AnyAsync(x => x.Student_Id == student_id && x.Subject_Id ==subject_id ))
                    {
                        Student_subject subject = new Student_subject
                        {
                            Student_Id = student_id,
                            Subject_Id = subject_id
                        };
                        if(!await context.Assessments.AnyAsync(x => x.Student_Id == student_id && x.Subject_Id == subject_id))
                        {
                            Assessment grade = new Assessment
                            {
                                Student_Id = student_id,
                                Subject_Id = subject_id,
                                Grade = 0,
                            };
                            await context.AddAsync<Assessment>(grade);
                            await context.SaveChangesAsync();
                        }
                        await context.AddAsync<Student_subject>(subject);
                        await context.SaveChangesAsync();
                        return subject;
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
