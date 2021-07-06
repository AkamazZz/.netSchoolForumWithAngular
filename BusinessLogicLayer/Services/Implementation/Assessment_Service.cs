using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.Specific;
using DataAccessLayer.Entity;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Assessment;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Assessment_Service : IAssessment_Service
    {
        private IAssessmentSpecific _iss= new AssessmentSpecific();
        public async Task<string> SetGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id)
        {
            Generic_ResultSet<Assessment_ResultSet> result = new Generic_ResultSet<Assessment_ResultSet>();
            try
            {
                Assessment faculty = await _iss.UpdateGradeByStudentIdAndSubjectId(grade,student_id,subject_id);

                

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("s");
                result.internalMessage = "SetGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id) method executed successfully.";
                result.result_set = null;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This faculty doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return "The grade has been changed";
        }
    }
}

