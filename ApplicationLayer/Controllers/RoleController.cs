using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var data = await _roleService.GetAll();
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(RoleDTO role)
        {
            var data = await _roleService.Create(role);
            if(data)
            {
                return Ok(new { message = "Role created successfully" });
            }
            else
            {
                return BadRequest(new { message = "Role creation failed" });
            }
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDTO role)
        {
            var data = await _roleService.Update(role, id);

            if (data) return Ok(new { message = "Role updated successfully" });
            
            return BadRequest(new { message = "Role update failed" });
        }


        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _roleService.Delete(id);
            if(data)
            {
                return Ok(new { message = "Role deleted successfully" });
            }
            else
            {
                return BadRequest(new { message = "Role deletion failed" });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _roleService.GetById(id);
            return Ok(data);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await _roleService.GetByName(name);
            return Ok(data);
        }
    }
}
