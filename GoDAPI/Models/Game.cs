using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoDAPI.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string POne { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PTwo { get; set; }

        [Required]
        public int Winner { get; set; }

        [Required]
        public int ScoreOne { get; set; }

        [Required]
        public int ScoreTwo { get; set; }

        public List<Battle> Battles { get; set; }
        public enum Winners
        {
            none = 0,
            p1 = 1,
            p2 = 2
        }

    }
}