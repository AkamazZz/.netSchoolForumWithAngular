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
    public class FacultyController: ControllerBase
    {
        private IFaculty_Service _faculty_Service;

        public FacultyController(IFaculty_Service faculty_Service)
        {
            _faculty_Service = faculty_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEachFaculty()
        {
            var result = await _faculty_Service.GetAllFaculties();
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
        public async Task<IActionResult> GetTopByFaculty(int faculty_id)
        {
            var result = await _faculty_Service.GetTopByGpaInFaculty(faculty_id);
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
        public async Task<IActionResult> GetFacultyNameById(int faculty_id)
        {
            var result = await _faculty_Service.GetFacultyNameByFacultyId(faculty_id);
            if(result != null && result.success)
            {
                return Ok(result) ;
            }
            else
            {
                return StatusCode(500, result);
            }
        }
    }
}
