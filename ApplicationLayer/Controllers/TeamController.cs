using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        TeamService _teamService;
        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("create")]

        public async Task<IActionResult> Create([FromForm] TeamDTO team)
        {
            string defaultPath = "/images/team-logos/default.png";
            if (team.Logo != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(team.Logo.FileName);
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/teamLogo");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                var savePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/images/teamLogo", fileName);
                using var Stream = new FileStream(savePath, FileMode.Create);
                await team.Logo.CopyToAsync(Stream);

                team.LogoUrl = "/images/teamLogo/" + fileName;



            }
            else
            {
                team.LogoUrl = defaultPath;
            }
            var data = await _teamService.Create(team);
            return Ok(data);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromForm] TeamDTO team, int id)
        {
           

            if (team.Logo != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(team.Logo.FileName);
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/teamLogo");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                var savePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/images/teamLogo", fileName);
                using var Stream = new FileStream(savePath, FileMode.Create);
                await team.Logo.CopyToAsync(Stream);

                team.LogoUrl = "/images/teamLogo/" + fileName;




            }
            var data = await _teamService.Update(team, id);
            return Ok(data);



        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _teamService.GetById(id);
            return Ok(data);
        }
        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var data = await _teamService.GetAll();
            return Ok(data);
        }
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _teamService.Delete(id);
            return Ok(data);
        }
    }
}
