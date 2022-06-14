using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public AlbumsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            if (await _dbService.CheckIfAlbumExists(id))
                return BadRequest();


            await _dbService.GetAlbum(id);

            return Ok();
        }
    }
}
