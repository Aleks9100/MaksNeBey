﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaksNeBey.Data;
using Microsoft.AspNetCore.Mvc;
using MaksNeBey.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaksNeBey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameAPIController : ControllerBase
    {
        private readonly GameDataBase _db;

        public GameAPIController(GameDataBase db) 
        {
            _db = db;
        }

        [HttpGet("/api/games/favorite")]
        public async Task<ActionResult<IEnumerable<Game>>>  Getgame() 
        {
            var games = await _db.GetGames();
            return Ok(games.Select(game => new GameViewModel()
            {
                GameID = game.GameID,
                Price = game.Price,
                Title = game.Title
            })) ;
        }

        // GET api/<GameAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}