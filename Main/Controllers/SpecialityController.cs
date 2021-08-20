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
    public class SpecialityController: ControllerBase
    {
        private ISpeciality_Service _speciality_Service ;
        
        public SpecialityController(ISpeciality_Service speciality_Service)
        {
            _speciality_Service = speciality_Service;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetEachSpeciality()
        {
            var result = await _speciality_Service.GetAllSpecialities();
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
        public async Task<IActionResult> GetTopBySpeciality(int speciality_id)
        {
            var result = await _speciality_Service.GetTopByGpaInSpeciality(speciality_id);
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
        public async Task<IActionResult> GetSpecialityNameById(int speciality_id)
        {
            var result = await _speciality_Service.GetSpecilaityNameBySpecilaityId(speciality_id);
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
        public async Task<IActionResult> GetFacultyIdById(int speciality_id)
        {
            var result = await _speciality_Service.GetFacultyIdBySpecilaityId(speciality_id);
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
