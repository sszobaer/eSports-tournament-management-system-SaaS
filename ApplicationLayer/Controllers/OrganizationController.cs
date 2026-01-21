using BLL.DTOs.Organization;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        OrganizationService _orgService;
        public OrganizationController(OrganizationService orgService)
        {
            _orgService = orgService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] OrganizationCreateDTO org)
        {
            var data = await _orgService.Create(org);
            return Ok(data);
        }
        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var data = await _orgService.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _orgService.GetById(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _orgService.Delete(id);

            if (data) {
                return Ok(new {Message = "Organization Deleted Successfully!"});
            }
            return BadRequest(new { Message = "Organization Deletion Failed" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] OrganizationUpdateDTO org)
        {
            var data = await _orgService.Update(id, org);
            if (data) {
                return Ok(new {Message = "Organization Updated Successfully!"});
            }
            return BadRequest(new { Message = "Organization Update Failed" });
        }

    }
}
