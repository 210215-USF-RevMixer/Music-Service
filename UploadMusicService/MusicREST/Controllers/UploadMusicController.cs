using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicBL;
using MusicModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UploadMusicREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadMusicController : Controller
    {
        private readonly IUploadMusicBL _mixerBL;
        public UploadMusicController(IUploadMusicBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        // GET: api/<UploadMusicController>
        [HttpGet]
        public async Task<IActionResult> GetUploadedMusicAsync()
        {
            return Ok(await _mixerBL.GetUploadedMusicAsync());
        }
        // GET api/<UploadMusicController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUploadedMusicByIDAsync(int id)
        {
            var uploadedMusic = await _mixerBL.GetUploadedMusicByIDAsync(id);
            if (uploadedMusic == null) return NotFound();
            return Ok(uploadedMusic);
        }

        //GET api/<UploadMusicController>/uploadedmusic/userid
        [HttpGet]
        [Route("/api/UploadMusic/User/{userID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUploadedMusicByUserIDAsync(int userID)
        {
            var uploadedMusic = await _mixerBL.GetUploadedMusicByUserIDAsync(userID);
            if (uploadedMusic == null) return NotFound();
            return Ok(uploadedMusic);
        }

        // POST api/<UploadMusicController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUploadedMusicAsync([FromBody] UploadMusic uploadedMusic)
        {
            try
            {

                await _mixerBL.AddUploadedMusicAsync(uploadedMusic);
                Log.Logger.Information($"new song with ID {uploadedMusic.Id} created");
                return CreatedAtAction("AddUploadedMusic", uploadedMusic);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown uploading music: {e.Message}");
                return Ok(e.Message);
            }
        }
        // PUT api/<UploadMusicController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUploadedMusicAsync(int id, [FromBody] UploadMusic uploadedMusic)
        {
            try
            {
                await _mixerBL.UpdateUploadedMusicAsync(uploadedMusic);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<UploadMusicController>/5
        [HttpDelete("{uploadedMusicID}")]
        public async Task<IActionResult> DeleteUploadedMusicAsync(int uploadedMusicID)
        {
            try
            {
                await _mixerBL.DeleteUploadedMusicAsync(await _mixerBL.GetUploadedMusicByIDAsync(uploadedMusicID));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
