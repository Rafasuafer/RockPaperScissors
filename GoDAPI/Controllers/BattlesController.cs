using GoDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattlesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private MovesController movesController;
        private GamesController gamesController;

        public BattlesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            movesController = new MovesController(configuration);
            gamesController = new GamesController(context);

        }

        // GET: api/Battles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattles()
        {
            return await _context.Battles.ToListAsync();
        }

        // GET: api/Battles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Battle>> GetBattle(int id)
        {
            var battle = await _context.Battles.FindAsync(id);

            if (battle == null)
            {
                return NotFound();
            }

            return battle;
        }

        // PUT: api/Battles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> updateBattle(int id, Battle battle)
        {
            if (id != battle.Id)
            {
                return BadRequest();
            }

            _context.Entry(battle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleExists(id))
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

        // POST: api/Battles
        [HttpPost]
        public async Task<ActionResult<Battle>> newBattle(DTOBattle dtoBattle)
        {

            Battle nBattle = new Battle()
            {
                GameId = dtoBattle.gameId,
                mOne = dtoBattle.moveOne,
                mTwo = dtoBattle.moveTwo,
                MoveOne = movesController.Get(dtoBattle.moveOne).Value,
                MoveTwo = movesController.Get(dtoBattle.moveTwo).Value
            };
            
            try
            {
                if (gamesController.GameExists(dtoBattle.gameId))
                {
                    
                    List<Move> moves = new List<Move>();
                    moves.Add(nBattle.MoveOne);
                    moves.Add(nBattle.MoveTwo);
                    
                    nBattle.winner = movesController.getWinner(moves);

                    _context.Battles.Add(nBattle);
                    await _context.SaveChangesAsync();
                    gamesController.addBattleResult(nBattle.GameId, nBattle.winner);

                    return CreatedAtAction("GetBattle", new { id = nBattle.Id }, nBattle);
                }
                return NotFound("#ERROR: Game not found");
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        // DELETE: api/Battles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Battle>> DeleteBattle(int id)
        {
            var battle = await _context.Battles.FindAsync(id);
            if (battle == null)
            {
                return NotFound();
            }

            _context.Battles.Remove(battle);
            await _context.SaveChangesAsync();

            return battle;
        }

        private bool BattleExists(int id)
        {
            return _context.Battles.Any(e => e.Id == id);
        }
    }
}