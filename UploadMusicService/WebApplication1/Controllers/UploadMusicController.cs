﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UploadMusicService.Controllers
{
    /// <summary>
    /// Rest API for uploading music 
    /// </summary>
    /// 
    [Route("api/[controller]")]
    [ApiController]
    public class UploadMusicController : Controller
    {
        // GET: api/<UploadMusicController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UploadMusicController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UploadMusicController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UploadMusicController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UploadMusicController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
