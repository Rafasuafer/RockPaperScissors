﻿using GoDAPI.Models;
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

        public BattlesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            movesController = new MovesController(configuration);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Battle>> newBattle(Battle battle)
        {

            battle.winner = movesController.getWinner(battle.MoveOne, battle.MoveTwo);
            _context.Battles.Add(battle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattle", new { id = battle.Id }, battle);
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