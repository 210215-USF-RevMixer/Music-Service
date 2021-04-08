using Microsoft.AspNetCore.Mvc;
using MusicBL;
using MusicModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicREST.Controllers
{
    /// <summary>
    /// Rest API for MusicController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MusicPlaylistController : Controller
    {
        private readonly IUploadMusicBL _mixerBL;
        public MusicPlaylistController(IUploadMusicBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        //GET api/<MusicPlaylistController>
        [HttpGet]
        public async Task<IActionResult> GetAllMusicPlaylists()
        {
            return Ok(await _mixerBL.GetMusicPlaylistsAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPlaylistByIDAsync(int id)
        {
            var mp = await _mixerBL.GetMusicPlaylistByIDAsync(id);
            if (mp == null) return NotFound();
            return Ok(mp);
        }

        // POST api/<MusicPlaylistController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddMusicPlaylist([FromBody] MusicPlaylist musicPlaylist)
        {
            try
            {

                await _mixerBL.AddMusicPlaylistAsync(musicPlaylist);
                Log.Logger.Information($"new music playlist with ID {musicPlaylist.Id} created");
                return CreatedAtAction("AddMusicPlaylist", musicPlaylist);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                return StatusCode(400);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayListAsync(int id)
        {
            try
            {
                await _mixerBL.DeleteMusicPlaylistAsync(await _mixerBL.GetMusicPlaylistByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayListAsynchAsync(int id, [FromBody] MusicPlaylist musicPlaylist)
        {
            try
            {
                await _mixerBL.UpdateMusicPlaylistAsync(musicPlaylist);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
