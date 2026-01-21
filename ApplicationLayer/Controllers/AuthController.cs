using BLL.DTOs.User;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register/{orgId}")]
        public async Task<IActionResult> Register(int orgId, [FromBody] UserRegisterDTO dto)
        {
            try
            {
                var user = await _authService.Register(orgId, dto);
                return Ok(new
                {
                    message = "User registered successfully",
                    userId = user.Id,
                    FullName = user.FullName,
                    email = user.Email,
                    Org = user.Organizations, 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
        {
            var user = await _authService.login(dto.Email, dto.Password);
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });


            return Ok(new
            {
                message = "Login successful",
                userId = user.Id,
                email = user.Email
            });
        }
    }
}
