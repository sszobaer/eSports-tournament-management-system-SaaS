using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        PlayerService _playerService;
        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PlayerDTO player)
        {
            var result = await _playerService.Create(player);
            if (!result.Success )
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

    }
}
