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
    public class GroupController: ControllerBase
    {
        private IGroup_Service _group_Service ;

        public GroupController(IGroup_Service group_Service)
        {
            _group_Service = group_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTopByGroup(int group_id)
        {
            var result = await _group_Service.GetTopByGpaInGroup(group_id);
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
        public async Task<IActionResult> GetGroupByGroupId(int group_id)
        {
            var result = await _group_Service.GetGroupNameByGroupId(group_id);
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
        public async Task<IActionResult> GetEachGroup()
        {
            var result = await _group_Service.GetAllGroups();
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
