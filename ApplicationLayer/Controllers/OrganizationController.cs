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
        public async Task<IActionResult> Create([FromForm]OrganizationCreateDTO org)
        {
            var data =  await _orgService.Create(org);
            return Ok(data);
        }
    }
}
