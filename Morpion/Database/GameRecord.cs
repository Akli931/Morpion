using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Morpion.Database
{
    [Table("games")]
    public class GameRecord
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("played_at")]
        public DateTimeOffset PlayedAt { get; set; }

        [Column("game_mode")]
        public string GameMode { get; set; } = "";

        [Column("result")]
        public string? Result { get; set; }

        [Column("is_finished")]
        public bool IsFinished { get; set; }

        [Column("board_state")]
        public string? BoardState { get; set; }
    }
}