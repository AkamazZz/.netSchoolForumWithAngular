using System;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Assessment;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IAssessment_Service
    {
        Task<string> SetGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id);
        

    
    }
}
