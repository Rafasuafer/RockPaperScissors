using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoDAPI.Models
{
    public class Battle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int GameId { set; get; }

        [Column(TypeName = "varchar(50)")]
        public string mOne { set; get; }

        [Column(TypeName = "varchar(50)")]
        public string mTwo { set; get; }
        [Required]
        public int winner { get; set; }

        [NotMapped]
        public Move MoveOne { set; get; }

        [NotMapped]
        public Move MoveTwo { set; get; }
    }
}