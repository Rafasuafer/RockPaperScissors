using GoDAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MovesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        // GET: api/<MovesController>
        [HttpGet]
        public ActionResult<IEnumerable<Move>> Get()
        {
            List<Move> moves = new List<Move>();
            IEnumerable<KeyValuePair<string, string>> settingsMoves = GetSettingMoves();

            foreach (KeyValuePair<string, string> m in settingsMoves)
            {
                if (m.Key != "Moves")
                {
                    Move move = new Move()
                    {
                        name = m.Key.Replace("Moves:", ""),
                        beats = m.Value
                    };
                    moves.Add(move);
                }
            }
            return moves;
        }

        public IEnumerable<KeyValuePair<string, string>> GetSettingMoves()
        {
            IEnumerable<KeyValuePair<string, string>> config = _configuration.GetSection("Moves").AsEnumerable();

            return config;
        }

        public string getWinner(Move moveOne, Move moveTwo)
        {
            string winner = "Draw";
            if (moveOne.beats == moveTwo.name && moveTwo.beats != moveOne.name)
            {
                winner = "p1";
            }
            else if (moveTwo.beats == moveOne.name && moveOne.beats != moveTwo.name)
            {
                winner = "p2";
            }

            return winner;
        }
    }
}