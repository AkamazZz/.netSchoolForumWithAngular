using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Subject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ISubject_Service
    {
        Task<Generic_ResultSet<Subject_ResultSet>> GetSubjectBySubjectId(int subject_id);
        Task<Generic_ResultSet<List<Subject_ResultSet>>> GetSubjectsByStudentId(int student_id);
        Task<Generic_ResultSet<List<Subject_ResultSet>>> GetSubjects();

        Task<Generic_ResultSet<Subject_ResultSet>> DeleteSubjectByStudent(int student_id, int subject_id);
        Task<Generic_ResultSet<Subject_ResultSet>> AddSubjectToStudent(int student_id, int subject_id);


    }
}
