using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface ISubjectSpecific
    {
        public Task<List<string>> SubjectsOfStudent(int student_id);
    }
}
