using System;
using DataAccessLayer.Functions.Interfaces;
using DataAccessLayer.Functions.Specific;
using DataAccessLayer.Functions.CRUD;
using DataAccessLayer.Entity;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Models;
using BusinessLogicLayer.Services.Models.Assessment;
using BusinessLogicLayer.Services.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services.Implementation
{
    public class Assessment_Service : IAssessment_Service
    {
        private IAssessmentSpecific _iss= new AssessmentSpecific();
        private ICRUD _crud = new CRUD();
        public async Task<Generic_ResultSet<Assessment_ResultSet>> SetGradeByStudentIdAndSubjectId(int mark, int student_id, int subject_id)
        {
            Generic_ResultSet<Assessment_ResultSet> result = new Generic_ResultSet<Assessment_ResultSet>();
            try
            {
                Assessment gradeUpdate = await _iss.UpdateGradeByStudentIdAndSubjectId(mark,student_id,subject_id);

                Assessment_ResultSet assessmentReturned = new Assessment_ResultSet
                {
                    assessment_id = gradeUpdate.Assessment_Id,
                    student_id = gradeUpdate.Student_Id,
                    subject_id = gradeUpdate.Subject_Id,
                    grade = gradeUpdate.Grade,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format($"You have set a new grade");
                result.internalMessage = "SetGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id) method executed successfully.";
                result.result_set = assessmentReturned;
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
            return result;
        }
        public async Task<Generic_ResultSet<Assessment_ResultSet>> GetGradeByStudentIdAndSubject(int student_id, int subject_id)
        {
            Generic_ResultSet<Assessment_ResultSet> result = new Generic_ResultSet<Assessment_ResultSet>();
            try
            {
                Assessment grade = await _iss.GetAssessmentByStudentIdAndSubjectId(student_id, subject_id);

                Assessment_ResultSet assessmentReturned = new Assessment_ResultSet
                {
                    assessment_id = grade.Assessment_Id,
                    student_id = grade.Student_Id,
                    subject_id = grade.Subject_Id,
                    grade = grade.Grade,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format($"Grade is given of {student_id}");
                result.internalMessage = "GetGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id) method executed successfully.";
                result.result_set = assessmentReturned;
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
            return result;
        }

        public async Task<Generic_ResultSet<List<Assessment_ResultSet>>> GetGradeByStudentId(int student_id)
        {
            Generic_ResultSet<List<Assessment_ResultSet>> result = new Generic_ResultSet<List<Assessment_ResultSet>>();
            try
            {
                List<Assessment> grade = await _iss.GetAssessmentByStudentId(student_id);

               
                result.result_set = new List<Assessment_ResultSet>();
                grade.ForEach(s =>
                {
                    {
                        result.result_set.Add(new Assessment_ResultSet
                        {
                            assessment_id = s.Assessment_Id,
                            student_id = s.Student_Id,
                            subject_id = s.Subject_Id,
                            grade = s.Grade,
                        });
                    }
                });
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format($"Grade is given of {student_id}");
                result.internalMessage = "GetGradeByStudentId( int student_id) method executed successfully.";
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
            return result;
        }
        public async Task<Generic_ResultSet<Assessment_ResultSet>> CreateGrade(int student_id, int subject_id, int grade)
        {
            if (grade > 100)
            {
                grade = 100;
            }else if (grade < 0)
            {
                grade = 0;
            }
            Generic_ResultSet<Assessment_ResultSet> result = new Generic_ResultSet<Assessment_ResultSet>();
            try
            {
                var check = await _iss.GetAssessmentByStudentIdAndSubjectId(student_id, subject_id);
                if (object.ReferenceEquals(null,check))
                {
                    Assessment mark = new Assessment
                    {
                        Student_Id = student_id,
                        Subject_Id = subject_id,
                        Grade = grade
                    };
                    mark = await _crud.Create<Assessment>(mark);
                    Assessment_ResultSet markReturned = new Assessment_ResultSet
                    {
                        assessment_id = mark.Assessment_Id,
                        student_id = mark.Student_Id,
                        subject_id = mark.Subject_Id,
                        grade = mark.Grade
                    };
                    result.userMessage = string.Format($"Grade is given of {student_id}");
                    result.internalMessage = "CreateGrade(int grade, int student_id, int subject_id) method executed successfully.";
                    result.result_set = markReturned;
                    result.success = true;
                }
                else
                {
                    result.userMessage = string.Format($"Grade is given of {student_id}");
                    result.internalMessage = "CreateGrade(int grade, int student_id, int subject_id) method executed successfully, but grade has already existed.";
                    result.success = false;
                }

                
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "This faculty doesn't exist";
                result.internalMessage = string.Format("{0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}

