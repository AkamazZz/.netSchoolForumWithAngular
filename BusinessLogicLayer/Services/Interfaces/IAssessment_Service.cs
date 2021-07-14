using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Assessment;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAssessment_Service
    {
        Task<Generic_ResultSet<Assessment_ResultSet>> SetGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id);
        

    
    }
}
