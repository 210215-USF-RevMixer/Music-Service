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
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IUploadMusicBL _mixerBL;

        public CommentsController(IUploadMusicBL mixerBL)
        {
            _mixerBL = mixerBL;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync()
        {
            return Ok(await _mixerBL.GetCommentsAsync());
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByMusicIDAsync(int id)
        {

            return Ok(await _mixerBL.GetCommentsByMusicIDAsync(id));
        }

        // POST api/<CommentsController>
        [HttpPost]
        public async Task<IActionResult> AddCommentAsync([FromBody] Comments comment)
        {
            try
            {
                await _mixerBL.AddCommentAsync(comment);
                Log.Logger.Information($"comment from user with ID of {comment.Id} posted");
                return CreatedAtAction("AddComment", comment);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                return Ok(e.Message);

            }
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentAsync(int id, [FromBody] Comments comment)
        {
            if (comment.Comment.Length < 1)
            {
                return StatusCode(400);
            }
            try
            {
                await _mixerBL.UpdateCommentAsync(comment);
                Log.Logger.Information($"comment by user with ID {comment.UserId} updated to have the content: {comment.Comment}");
                return NoContent();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                return StatusCode(500);
            }
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            try
            {
                await _mixerBL.DeleteCommentAsync(await _mixerBL.GetCommentByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
