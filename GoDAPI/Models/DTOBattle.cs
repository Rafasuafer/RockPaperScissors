using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDAPI.Models
{
    [Keyless]
    public class DTOBattle
    {
        public int gameId { get; set; }
        public string moveOne { get; set; }
        public string moveTwo { get; set; }
    }
}
