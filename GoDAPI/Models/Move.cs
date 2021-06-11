using Microsoft.EntityFrameworkCore;

namespace GoDAPI.Models
{
    [Keyless]
    public class Move
    {
        
        public string name { get; set; }
        public string beats { get; set; }
    }
}