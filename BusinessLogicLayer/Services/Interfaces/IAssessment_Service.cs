using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Assessment;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAssessment_Service
    {
        Task<Generic_ResultSet<Assessment_ResultSet>> SetGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id);

        Task<Generic_ResultSet<Assessment_ResultSet>> GetGradeByStudentIdAndSubject(int student_id, int subject_id);
        Task<Generic_ResultSet<Assessment_ResultSet>> CreateGrade(int student_id, int subject_id, int grade);

        Task<Generic_ResultSet<List<Assessment_ResultSet>>> GetGradeByStudentId(int student_id);




    }
}
