using GoDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> updateGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> newGame(DTOPlayers dtoP)
        {
            Game newGame = new Game()
            {
            POne = dtoP.p1,
            PTwo = dtoP.p2,
            Winner = (int)Game.Winners.none,
            ScoreOne = 0,
            ScoreTwo = 0
             };

            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = newGame.Id }, newGame);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }

        public async Task addBattleResult(int gameId, int result) 
        {
            Game GameBeingPlayed = GetGame(gameId).Result.Value;
            if (GameBeingPlayed.Winner == (int)Game.Winners.none)
            {
                switch (result)
                {
                    case (int)Game.Winners.p1:
                        GameBeingPlayed.ScoreOne++;
                        break;
                    case (int)Game.Winners.p2:
                        GameBeingPlayed.ScoreTwo++;
                        break;
                }
                if (GameBeingPlayed.ScoreOne == 3)
                {
                    GameBeingPlayed.Winner = (int)Game.Winners.p1;
                }
                else if(GameBeingPlayed.ScoreTwo == 3)
                {
                    GameBeingPlayed.Winner = (int)Game.Winners.p2;
                }
                await updateGame(gameId, GameBeingPlayed);
            }
        }

    }
}