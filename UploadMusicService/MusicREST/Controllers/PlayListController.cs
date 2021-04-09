using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicBL;
using MusicModels;
using Serilog;

namespace MusicREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListController : Controller
    {
        private readonly IUploadMusicBL _mixerBL;

            public PlayListController(IUploadMusicBL mixerBL)
            {
                _mixerBL = mixerBL;
            }

            // GET: api/<ValuesController>
            [HttpGet]
            public async Task<IActionResult> GetPlayListsAsync()
            {
                return Ok(await _mixerBL.GetPlayListsAsync());
            }

            // GET api/<ValuesController>/5
            [HttpGet("{id}")]
            [Produces("application/json")]
            public async Task<IActionResult> GetPlaylistByIDAsync(int id)
            {
                var playlist = await _mixerBL.GetPlayListByIDAsync(id);
                if (playlist == null) return NotFound();
                return Ok(playlist);
            }

            // POST api/<ValuesController>
            [HttpPost]
            [Consumes("application/json")]
            public async Task<IActionResult> AddPlaylistAsync([FromBody] PlayList playlist)
            {
                try
                {
                    Log.Logger.Information($"new music playlist with ID {playlist.Id} created");
                    await _mixerBL.AddPlayListAsync(playlist);
                    return CreatedAtAction("AddPlaylist", playlist);
                }
                catch (Exception e)
                {
                    Log.Logger.Error($"Error thrown: {e.Message}");
                    return StatusCode(400);
                }
            }

            // PUT api/<ValuesController>/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePlayListAsync(int id, [FromBody] PlayList playList)
            {
                try
                {
                    await _mixerBL.UpdatePlayListAsync(playList);
                    return NoContent();
                }
                catch
                {
                    return StatusCode(500);
                }
            }

            // DELETE api/<ValuesController>/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePlayListAsync(int id)
            {
                try
                {
                    await _mixerBL.DeletePlayListAsync(await _mixerBL.GetPlayListByIDAsync(id));
                    return NoContent();
                }
                catch
                {
                    return StatusCode(500);
                }
            }
        }
    }

