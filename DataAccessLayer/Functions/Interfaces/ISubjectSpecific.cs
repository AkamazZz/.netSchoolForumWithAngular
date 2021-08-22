using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface ISubjectSpecific
    {
        public Task<List<Subject>> SubjectsOfStudent(int student_id);
        public Task<bool> DeleteSubjectFromStudent(int student_id, int subject_id);
        public Task<Student_subject> AddSubjectToStudent(int student_id, int subject_id);

    }
}
