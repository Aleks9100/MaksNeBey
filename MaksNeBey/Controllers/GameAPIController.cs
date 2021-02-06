using System;
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
        [HttpPost ("/api/games/add")]
        public IActionResult Post([FromBody] GameViewModel model)
        {
            _db.GameAdd(model.Title,model.Price);
            return Ok(model);
        }

        // PUT api/<GameAPIController>/5
        [HttpPut("/api/games/{id}")]
        public IActionResult Put([FromBody] GameViewModel model, int id)
        {
            _db.GameEdit(id, model.Title, model.Price);
            return Ok(model);
        }

        // DELETE api/<GameAPIController>/5
        [HttpDelete("/api/games/{id}")]
        public IActionResult Delete(int id)
        {
            _db.GameRemove(id);
            return Ok();
        }
    }
}
