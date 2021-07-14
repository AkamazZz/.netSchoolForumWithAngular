using BusinessLogicLayer.Services.Implementation;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hierarchy.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController: ControllerBase
    {
        private ISubject_Service _subject_Service;

        public SubjectController(ISubject_Service subject_Service)
        {
            _subject_Service = subject_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetSubjectNameBySubjectId(int subject_id)
        {
            var result = await _subject_Service.GetSubjectBySubjectId(subject_id);
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
        public async Task<IActionResult> GetSubjectsNameByStudentId(int student_id)
        {
            var result = await _subject_Service.GetSubjectsByStudentId(student_id);
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

