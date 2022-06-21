using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestTemplate.Services;

namespace TestTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DBController : ControllerBase
    {
        private readonly IDBService _service;

        public DBController(IDBService service)
        {
            _service = service;
        }

        

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetTeam( int idTeam)
        {

            if (await _service.DoesTeamExist(idTeam) == false)
            {
                return NotFound();
            }

            return Ok( await _service.GetTeam(idTeam) );   
        }

        
    }
}
