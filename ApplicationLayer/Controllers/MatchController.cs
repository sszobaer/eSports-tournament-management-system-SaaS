using BLL.DTOs.Match;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly MatchService _service;

        public MatchController(MatchService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(MatchCreateDTO dto) {
            var data = await _service.Create(dto);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.Get(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MatchUpdateDTO dto) => Ok(await _service.Update(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.Delete(id));

        [HttpPost("submit-result")]
        public async Task<IActionResult> SubmitResult([FromBody] MatchResultSubmitDTO dto)
        {
            try
            {
                var data = await _service.SubmitMatchResult(dto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
