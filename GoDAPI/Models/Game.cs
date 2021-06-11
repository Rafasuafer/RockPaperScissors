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

        [Column(TypeName = "varchar(50)")]
        public string Winner { get; set; }

        [Required]
        public int ScoreOne { get; set; }

        [Required]
        public int ScoreTwo { get; set; }

        public List<Battle> Battles { get; set; }
    }
}