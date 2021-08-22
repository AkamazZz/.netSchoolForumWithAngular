using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Main.Models.Assessment;

namespace Hierarchy.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController: ControllerBase
    {
        
        private IAssessment_Service _assessment_Service;

        
        public AssessmentController(IAssessment_Service assessment_Service)
        {
            _assessment_Service = assessment_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateGradeByStudentIdAndSubjectId(int grade, int student_id, int subject_id)
        {
            var result = await _assessment_Service.SetGradeByStudentIdAndSubjectId(grade, student_id, subject_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGradeByStudentIdAndSubjectId(int student_id, int subject_id)
        {
            var result = await _assessment_Service.GetGradeByStudentIdAndSubject(student_id, subject_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGradeByStudentId(int student_id)
        {
            var result = await _assessment_Service.GetGradeByStudentId(student_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateGrade(Assessment_Pass_Object grade)
        {
            var result = await _assessment_Service.CreateGrade(grade.student_id, grade.subject_id,grade.grade);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
