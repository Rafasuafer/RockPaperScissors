using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDAPI.Models
{
    [Keyless]
    public class DTOPlayers
    {
        public string p1 { set; get; }
        public string p2 { set; get; }
    }
}
