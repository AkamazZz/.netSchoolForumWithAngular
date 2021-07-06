using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Functions.Interfaces
{
    public interface IAssessmentSpecific
    {
        public Task<int> GPA(int student_id);

        public Task<Assessment> UpdateGradeByStudentIdAndSubjectId(int grade,int student_id, int subject_id);

    }
}
