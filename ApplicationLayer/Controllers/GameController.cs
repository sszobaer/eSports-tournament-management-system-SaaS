using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        GameService _gameService;
        public GameController(GameService gameService) {
            _gameService = gameService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> All() { 
            var  data=await _gameService.GetAll();
            return Ok(data);

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(GameDTO game)
        {
            var data = await _gameService.Create(game);
            return Ok(data);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data =await _gameService.GetById(id);
            return Ok(data);
        }

       

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(GameDTO game,int id)
        {
            var data =await _gameService.Update(game, id);
            return Ok(data);
        }
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data =await _gameService.Delete(id);
            return Ok(data);
        }






    }
}
