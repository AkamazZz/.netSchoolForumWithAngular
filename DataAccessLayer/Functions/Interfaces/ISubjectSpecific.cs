using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface ISubjectSpecific
    {
        public Task<List<Subject>> SubjectsOfStudent(int student_id);
    }
}
